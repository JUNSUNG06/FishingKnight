using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterMovement : CharacterComponent
{
    private Rigidbody rb;

    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float acceleation;
    private Coroutine accelerationCo;
    private float moveSpeed;
    private Vector3 moveDir;
    private Vector3 prevMoveDir;
    public float MoveSpeed
    {
        get { return moveSpeed; } 
        set
        {
            OnMoveSpeedChanged?.Invoke(moveSpeed, value);

            moveSpeed = value;
        }
    }
    public float MaxMoveSpeed => maxMoveSpeed;
    public Vector3 MoveDirection => moveDir;
    public Vector3 PrevMoveDirection => prevMoveDir;

    public Action<float, float/*prev, new*/> OnMoveSpeedChanged;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        Vector3 velocity = Vector3.zero;

        if(MoveDirection == Vector3.zero)
        {
            if (MoveSpeed != 0)
                velocity = PrevMoveDirection * MoveSpeed;
        }
        else
        {
            velocity = MoveDirection * MoveSpeed;
        }

        rb.velocity = velocity;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        prevMoveDir = moveDir;
        moveDir = direction.normalized;
    }

    public void SetMoveSpeed(float moveSpeedWeight, bool acceleation = true)
    {
        moveSpeedWeight = Mathf.Clamp01(moveSpeedWeight);
        float speed = maxMoveSpeed * moveSpeedWeight;

        if(acceleation)
        {
            if(accelerationCo != null)
                StopCoroutine(accelerationCo);
            accelerationCo = StartCoroutine(AccelerationCo(speed));
        }
        else
        {
            MoveSpeed = speed;
        }
    }

    private IEnumerator AccelerationCo(float speed)
    {
        float changeValue = Mathf.Abs(speed - moveSpeed);
        int sign = (int)Mathf.Sign(speed - moveSpeed);
        float progressValue = 0;

        while(changeValue > progressValue)
        {
            progressValue += acceleation * Time.deltaTime;
            MoveSpeed += acceleation * Time.deltaTime * sign;

            yield return null;
        }
        MoveSpeed = speed;

        accelerationCo = null;
    }
}
