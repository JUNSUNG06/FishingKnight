using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMTransition : FSMObject
{
    [SerializeField] private FSMState nextState;

    private List<FSMDecision> decisions;

    public override void Initialize(Character owner)
    {
        base.Initialize(owner);

        decisions = new List<FSMDecision>();
        GetComponents<FSMDecision>(decisions);
        foreach (FSMDecision decision in decisions)
        {
            decision.Initialize(owner);
        }
    }

    public override void EnterState()
    {
        foreach (FSMDecision decision in decisions)
        {
            decision.EnterState();
        }
    }

    public override void UpdateState()
    {
        bool result = false;

        foreach (FSMDecision decision in decisions)
        {
            decision.UpdateState();
            result |= decision.IsSatisfy();
        }

        if (result)
            owner.FSM.ChangeState(nextState);
    }

    public override void ExitState()
    {
        foreach (FSMDecision decision in decisions)
        {
            decision.ExitState();
        }
    }
}
