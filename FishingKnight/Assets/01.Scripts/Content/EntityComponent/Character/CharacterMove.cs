using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterMove : CharacterComponent
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveDirection)
    {
        rb.velocity = moveDirection * moveSpeed;
    }
}
