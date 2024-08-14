using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputDecision : FSMDecision
{
    [Space]
    [SerializeField] private PlayInputSO input;
    [SerializeField] private PlayInputActionType type;

    [Space]
    [SerializeField] private bool onStarted;
    [SerializeField] private bool onCanceled;
    private bool started;
    private bool canceled;

    public override void EnterState()
    {
        base.EnterState();

        started = false;
        canceled = false;

        input.RegistAction(type, CheckInput);
    }

    public override void Satisfy()
    {
        result = (onStarted && started) || (onCanceled && canceled);

        started = false;
        canceled = false;
    }

    public override void ExitState()
    {
        base.ExitState();

        input.UnregistAction(type, CheckInput);
    }

    private void CheckInput(CallbackContext context)
    {
        if (context.started && onStarted)
        {
            started = true;
        }
        else if (context.canceled && onCanceled)
        {
            canceled = true;
        }
    }
}