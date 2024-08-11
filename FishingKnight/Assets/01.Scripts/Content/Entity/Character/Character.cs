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

    public CharacterMovement Movement => movement;
    public CharacterHealth Health => health;
    public CharacterFSM FSM => fsm;
    public EntityAnimation Anim => anim;

    protected override void PostInitializeComponent()
    {
        health = GetEntityComponent<CharacterHealth>();
        movement = GetEntityComponent<CharacterMovement>();
        fsm = GetEntityComponent<CharacterFSM>();
        anim = GetEntityComponent<EntityAnimation>();

        base.PostInitializeComponent();

        //test
        InputManager.ChangeInputMap(InputMapType.Play);
    }

    public void OnDamaged(Entity attacker, float power, Vector3 point,
        Vector3 direction = default, Vector3 normal = default)
    {
        health.RemoveHealth(power);
    }
}