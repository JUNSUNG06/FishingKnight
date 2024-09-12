using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : CharacterMovement
{
    private NavMeshAgent nav;

    private bool isMove;

    private Vector3 destination;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        nav = entity.GetComponent<NavMeshAgent>();
        nav.speed = MaxMoveSpeed;
        nav.acceleration = acceleation;
        nav.angularSpeed = turnSpeed;
    }

    public override void Move()
    {
        nav.SetDestination(destination);
        isMove = true;
    }

    public override void Stop()
    {
        base.Stop();

        nav.SetDestination(transform.position);
        isMove = false;
    }

    public void SetDestination(Vector3 dest)
    {
        destination = dest;
    }
}