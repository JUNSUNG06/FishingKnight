using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : CharacterComponent
{
    //move
    [SerializeField] protected float maxMoveSpeed;
    [SerializeField] protected float acceleation;
    protected Coroutine accelerationCo;
    protected float moveSpeed;
    protected Vector3 moveDir;
    protected Vector3 prevMoveDir;
    protected Vector3 velocity;

    protected bool enableGravity;

    public float MoveSpeed
    {
        get { return moveSpeed; } 
        private set
        {
            float prev = moveSpeed;
            moveSpeed = value;

            OnMoveSpeedChanged?.Invoke(prev, moveSpeed);
        }
    }
    public float MaxMoveSpeed => maxMoveSpeed;
    public Vector3 MoveDirection
    {
        get { return moveDir; }
        private set
        {
            prevMoveDir = moveDir;
            moveDir = value;

            OnMoveDirectionChanged?.Invoke(PrevMoveDirection, MoveDirection);
        }
    }
    public Vector3 PrevMoveDirection => prevMoveDir;

    public Action<float, float/*prev, new*/> OnMoveSpeedChanged;
    public Action<Vector3, Vector3/*prev, new*/> OnMoveDirectionChanged;

    //turn
    [SerializeField] private float turnSpeed;
    private Coroutine turnCo;

    public virtual void Move()
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
        velocity.y = this.velocity.y;

        this.velocity = velocity;
    }

    public void Stop()
    {
        SetMoveDirection(Vector3.zero);
        SetMoveSpeed(0f, false);
        velocity = Vector3.zero;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        MoveDirection = direction.normalized;
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

    public void LookMoveDirection()
    {
        Turn(MoveDirection);
    }

    public void Turn(Vector3 direction)
    {
        if (!gameObject.activeSelf)
            return;

        direction.Normalize();

        if (direction != Vector3.zero)
        {
            if (turnCo != null)
                StopCoroutine(turnCo);
            turnCo = StartCoroutine(TurnCo(direction));
        }
        else
        {
            if (turnCo != null)
                StopCoroutine(turnCo);
        }
    }

    private IEnumerator TurnCo(Vector3 direction)
    {
        float t = 0f;
        Quaternion start = transform.rotation;
        Quaternion end = Quaternion.AngleAxis(Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, Vector3.up);

        while (t < 1f)
        {
            t += Time.deltaTime * turnSpeed;
            transform.rotation = Quaternion.Lerp(start, end, t);

            yield return null;
        }
        transform.rotation = end;

        turnCo = null;
    }

    public virtual void EnableGravity(bool value)
    {
        enableGravity = value;
    }
}
