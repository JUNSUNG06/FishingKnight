using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SetColliderAction : FSMAction
{
    [SerializeField] private bool active;

    public override void EnterState()
    {
        base.EnterState();

        character.Collider.enabled = active;
    }

    public override void ExitState()
    {
        base.ExitState();

        character.Collider.enabled = !active;
    }
}
