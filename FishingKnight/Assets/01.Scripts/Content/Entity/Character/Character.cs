using OMG.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : Entity, IDamage
{
    private CharacterMovement movement;
    private CharacterHealth health;
    private CharacterFSM fsm;
    private EntityAnimation anim;
    private CharacterInteract interact;
    private Collider col;

    public CharacterMovement Movement => movement;
    public CharacterHealth Health => health;
    public CharacterFSM FSM => fsm;
    public EntityAnimation Anim => anim;
    public CharacterInteract Interact => interact;
    public Collider Collider => col;

    protected override void Awake()
    {
        base.Awake();
        
        health = GetEntityComponent<CharacterHealth>();
        movement = GetEntityComponent<CharacterMovement>();
        fsm = GetEntityComponent<CharacterFSM>();
        anim = GetEntityComponent<EntityAnimation>();
        interact = GetEntityComponent<CharacterInteract>();
        col = GetComponent<Collider>();

        //test
        InputManager.ChangeInputMap(InputMapType.Play);
    }

    public void OnDamaged(Entity attacker, float power, Vector3 point,
        Vector3 direction = default, Vector3 normal = default)
    {
        health.RemoveHealth(power);
    }
}