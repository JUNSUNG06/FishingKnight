using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFSM : CharacterComponent
{
    [SerializeField] private FSMState defaultState;

    private Dictionary<Type, FSMState> states;

    private FSMState currentState;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        states = new Dictionary<Type, FSMState>();
        foreach(Transform child in transform)
        {
            if(child.TryGetComponent<FSMState>(out FSMState state))
                states.Add(state.GetType(), state);
        }
    }

    public override void PostInitializeComponent()
    {
        base.PostInitializeComponent();

        foreach(var pair in states)
        {
            pair.Value.Initialize(owner);
        }

        ChangeState(defaultState);
    }

    public override void UpdateComponent()
    {
        base.UpdateComponent();

        currentState.UpdateState();
    }

    public void ChangeState(FSMState nextState)
    {
        currentState?.ExitState();
        currentState = nextState;
        currentState.EnterState();
    }

    public void ChangeState(Type nextStateType)
    {
        FSMState nextState = states[nextStateType];

        currentState?.ExitState();
        currentState = nextState;
        currentState.EnterState();
    }
}