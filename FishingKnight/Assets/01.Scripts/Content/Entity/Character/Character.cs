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

    public CharacterMovement Movement => movement;
    public CharacterHealth Health => health;
    public CharacterFSM FSM => fsm;

    [SerializeField] private PlayInputSO input;

    protected override void PostInitializeComponent()
    {
        base.PostInitializeComponent();

        health = GetEntityComponent<CharacterHealth>();
        movement = GetEntityComponent<CharacterMovement>();
        fsm = GetEntityComponent<CharacterFSM>();

        //test
        InputManager.ChangeInputMap(InputMapType.Play);
    }

    public void OnDamaged(Entity attacker, float power, Vector3 point,
        Vector3 direction = default, Vector3 normal = default)
    {
        health.RemoveHealth(power);
    }
}