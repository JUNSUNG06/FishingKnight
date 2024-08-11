using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFSM : CharacterComponent
{
    [SerializeField] private FSMState defaultState;
    [SerializeField] private FSMState currentState;

    private List<FSMState> states;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        states = new List<FSMState>();
        foreach(Transform child in transform.Find("States"))
        {
            if(child.TryGetComponent<FSMState>(out FSMState state))
                states.Add(state);
        }
    }

    public override void PostInitializeComponent()
    {
        base.PostInitializeComponent();

        foreach(var state in states)
        {
            state.Initialize(Character);
        }

        ChangeState(defaultState);
    }

    public override void UpdateComponent()
    {
        base.UpdateComponent();

        currentState?.UpdateState();
    }

    public void ChangeState(FSMState nextState)
    {
        if (currentState == nextState)
            return;

        currentState?.ExitState();
        currentState = nextState;
        currentState.EnterState();
    }
}