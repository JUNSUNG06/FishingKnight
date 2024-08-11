using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : FSMAction
{
    [Range(0f, 1f)][SerializeField] private float moveSpeedWeight;

    public override void EnterState()
    {
        character.Movement.OnMoveSpeedChanged += OnMoveSpeedChange;
        character.Movement.SetMoveSpeed(moveSpeedWeight);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        character.Movement.Move();
    }

    public override void ExitState()
    {
        character.Movement.OnMoveSpeedChanged -= OnMoveSpeedChange;
    }

    private void OnMoveSpeedChange(float prev, float next)
    {
        float threshold = next / character.Movement.MaxMoveSpeed;
        character.Anim.Animator.SetFloat("move_speed", threshold);
    }
}
