using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : FSMAction
{
    [Range(0f, 1f)][SerializeField] private float moveSpeedWeight;
    [SerializeField] private bool turn = true;

    private CharacterMovement movement;
    private EntityAnimation anim;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        movement = character.GetEntityComponent<CharacterMovement>();
        anim = character.GetEntityComponent<EntityAnimation>();
    }

    public override void EnterState()
    {
        movement.OnMoveSpeedChanged += OnMoveSpeedChange;
        movement.SetMoveSpeed(moveSpeedWeight);

        movement.OnMoveDirectionChanged += OnMoveDirectionChanged;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        movement.Move();
    }

    public override void ExitState()
    {
        movement.OnMoveSpeedChanged -= OnMoveSpeedChange;
        movement.OnMoveDirectionChanged -= OnMoveDirectionChanged;
    }

    private void OnMoveSpeedChange(float prev, float next)
    {
        float threshold = next / movement.MaxMoveSpeed;
        anim.Animator.SetFloat("move_speed", threshold);
    }

    private void OnMoveDirectionChanged(Vector3 prev, Vector3 next)
    {
        if(turn)
        {
            movement.LookMoveDirection();
        }
    }
}
