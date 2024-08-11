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
        for (int i = 0; i < decisions.Count; i++)
        {
            decisions[i].EnterState();
        }
    }

    public override void UpdateState()
    {
        for (int i = 0; i < decisions.Count; i++)
        {
            decisions[i].UpdateState();
        }
        for (int i = 0; i < decisions.Count; i++)
        {
            if (decisions[i].IsSatisfy() == false)
                return;
        }

        character.FSM.ChangeState(nextState);
    }

    public override void ExitState()
    {
        for (int i = 0; i < decisions.Count; i++)
        {
            decisions[i].ExitState();
        }
    }
}
