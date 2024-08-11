using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : FSMAction
{
    [Range(0f, 1f)][SerializeField] private float moveSpeedWeight;
    [SerializeField] private bool turn = true;

    public override void EnterState()
    {
        character.Movement.OnMoveSpeedChanged += OnMoveSpeedChange;
        character.Movement.SetMoveSpeed(moveSpeedWeight);

        character.Movement.OnMoveDirectionChanged += OnMoveDirectionChanged;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        character.Movement.Move();
    }

    public override void ExitState()
    {
        character.Movement.OnMoveSpeedChanged -= OnMoveSpeedChange;
        character.Movement.OnMoveDirectionChanged -= OnMoveDirectionChanged;
    }

    private void OnMoveSpeedChange(float prev, float next)
    {
        float threshold = next / character.Movement.MaxMoveSpeed;
        character.Anim.Animator.SetFloat("move_speed", threshold);
    }

    private void OnMoveDirectionChanged(Vector3 prev, Vector3 next)
    {
        if(turn)
        {
            character.Movement.LookMoveDirection();
        }
    }
}
