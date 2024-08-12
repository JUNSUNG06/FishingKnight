using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFSM : CharacterComponent
{
    [SerializeField] private FSMState defaultState;
    [SerializeField] private FSMState currentState;
    [SerializeField] private FSMState nextState;

    public FSMState CurretState => currentState;
    public FSMState NextState => nextState;

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

    public override void PostInitialize()
    {
        base.PostInitialize();

        foreach(var state in states)
        {
            state.Initialize(Character);
        }

        SetNextState(defaultState);
        ChangeState();
    }

    public override void UpdateComponent()
    {
        base.UpdateComponent();

        if (currentState != nextState)
            ChangeState();
       
        currentState?.UpdateState();
    }

    public void SetNextState(string name)
    {
        SetNextState(states.Find(s => s.name == $"{name}State"));
    }

    public void SetNextState(FSMState nextState)
    {
        if (nextState == null)
            return;
        if (currentState == nextState)
            return;

        this.nextState = nextState;
    }

    private void ChangeState()
    {
        currentState?.ExitState();
        currentState = nextState;
        currentState.EnterState();
    }
}