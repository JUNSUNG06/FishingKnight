using OMG.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : Entity, IDamage
{
    private CharacterHealth healthComp;
    private CharacterMove movement;

    [SerializeField] private PlayInputSO input;

    protected override void PostInitializeComponent()
    {
        base.PostInitializeComponent();

        healthComp = GetEntityComponent<CharacterHealth>();
        movement = GetEntityComponent<CharacterMove>();


        //test
        InputManager.ChangeInputMap(InputMapType.Play);
        input.RegistAction(PlayInputActionType.Move, Move);
    }

    //test
    private void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 cameraForward = Camera.main.transform.eulerAngles.y * Vector3.up;
        Vector3 moveDir = Quaternion.Euler(cameraForward) * new Vector3(input.x, 0, input.y).normalized;

        movement.Move(moveDir);
    }

    public void OnDamaged(Entity attacker, float power, Vector3 point,
        Vector3 direction = default, Vector3 normal = default)
    {
        healthComp.RemoveHealth(power);
    }
}