using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FSMState : FSMObject
{
    private List<FSMAction> actions;
    private List<FSMTransition> transitions;

    [SerializeField] private List<string> playAnimations;
    [SerializeField] private bool applyRootMotion;
    [SerializeField] private bool resetRootMotion;
    [SerializeField] private bool alignToRootMotion;
    public List<string> PlayAnimations => playAnimations;

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
        for(int i = 0; i < actions.Count; i++)
        {
            actions[i].EnterState();
        }

        for (int i = 0; i < transitions.Count; i++)
        {
            transitions[i].EnterState();
        }

        if (resetRootMotion)
            character.Anim.ResetRootMotion();
        else if(alignToRootMotion)
            character.Anim.AlignToRootMotion();
        character.Anim.Animator.applyRootMotion = applyRootMotion;

        for(int i = 0; i <  playAnimations.Count; i++)
        {
            if (character.FSM.PrevState != null && !character.FSM.PrevState.PlayAnimations.Contains(playAnimations[i]))
                character.Anim.Animator.SetTrigger(playAnimations[i]);
        }
    }

    public override void UpdateState()
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].UpdateState();
        }


        for (int i = 0; i < transitions.Count; i++)
        {
            transitions[i].UpdateState();
        }
    }

    public override void ExitState()
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].ExitState();
        }


        for (int i = 0; i < transitions.Count; i++)
        {
            transitions[i].ExitState();
        }
    }
}
