using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FSMState : FSMObject
{
    private List<FSMAction> actions;
    private List<FSMTransition> transitions;

    public override void Initialize(Character owner)
    {
        base.Initialize(owner);

        actions = new List<FSMAction>();
        GetComponents<FSMAction>(actions);
        foreach (FSMAction action in actions)
        {
            action.Initialize(owner);
        }

        transitions = new List<FSMTransition>();
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<FSMTransition>(out FSMTransition transition))
            {
                transitions.Add(transition);
                transition.Initialize(owner);
            }
        }
    }

    public override void EnterState()
    {
        foreach (FSMAction action in actions)
        {
            action.EnterState();
        }

        foreach (FSMTransition transition in transitions)
        {
            transition.EnterState();
        }
    }

    public override void UpdateState()
    {
        foreach (FSMAction action in actions)
        {
            action.UpdateState();
        }

        foreach (FSMTransition transition in transitions)
        {
            transition.UpdateState();
        }
    }

    public override void ExitState()
    {
        foreach (FSMAction action in actions)
        {
            action.ExitState();
        }

        foreach (FSMTransition transition in transitions)
        {
            transition.ExitState();
        }
    }
}
