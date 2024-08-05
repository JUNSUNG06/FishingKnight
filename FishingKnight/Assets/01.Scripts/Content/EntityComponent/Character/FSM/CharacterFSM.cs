using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFSM : CharacterComponent
{
    [SerializeField] private FSMState defaultState;

    private List<FSMState> states;

    private FSMState currentState;

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
        currentState?.ExitState();
        currentState = nextState;
        currentState.EnterState();
    }

    public void ChangeState(Type type)
    {
        FSMState nextState = states.Find(x => x.GetType() == type);

        currentState?.ExitState();
        currentState = nextState;
        currentState.EnterState();
    }
}