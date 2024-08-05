using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterMovement : CharacterComponent
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;
    private Vector3 moveDir;
    public Vector3 MoveDirection => moveDir;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        rb.velocity = MoveDirection * moveSpeed;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        moveDir = direction.normalized;
    }
}
