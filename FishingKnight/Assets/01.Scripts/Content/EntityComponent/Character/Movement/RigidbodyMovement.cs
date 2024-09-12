using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class RigidbodyMovement : CharacterMovement
{
    private Rigidbody rb;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner); 

        rb = GetComponent<Rigidbody>();
    }

    public override void Move()
    {
        base.Move();

        velocity.y = rb.velocity.y;

        rb.velocity = velocity;
    }

    public override void EnableGravity(bool value)
    {
        base.EnableGravity(value);

        rb.useGravity = value;
    }
}
