using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SetColliderAction : FSMAction
{
    [SerializeField] private bool active;

    private Collider characterCol;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        characterCol = character.GetComponent<Collider>();
    }

    public override void EnterState()
    {
        base.EnterState();

        characterCol.enabled = active;
    }

    public override void ExitState()
    {
        base.ExitState();

        characterCol.enabled = !active;
    }
}
