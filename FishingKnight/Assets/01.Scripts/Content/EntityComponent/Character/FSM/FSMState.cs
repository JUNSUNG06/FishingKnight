using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState : FSMObject
{
    private List<FSMTransition> transitions;

    public override void Initialize(Character owner)
    {
        base.Initialize(owner);

        transitions = new List<FSMTransition>();
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<FSMTransition>(out FSMTransition transition))
                transitions.Add(transition);
        }
    }

    public override void EnterState()
    {
        foreach (FSMTransition transition in transitions)
        {
            transition.EnterState();
        }
    }

    public override void UpdateState()
    {
        foreach (FSMTransition transition in transitions)
        {
            transition.UpdateState();
        }
    }

    public override void ExitState()
    {
        foreach (FSMTransition transition in transitions)
        {
            transition.ExitState();
        }
    }
}
