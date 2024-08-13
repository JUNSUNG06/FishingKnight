using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Stuff
{
    [SerializeField] private Transform sitPoint;
    [SerializeField] private string sitStateaName;

    private Character interacter;

    public override void Interact(Entity performer)
    {
        base.Interact(performer);

        if(performer.TryGetComponent<Character>(out Character character))
        {
            interacter = character;
            interacter.FSM.SetNextState("Sit");
            interacter.transform.SetPositionAndRotation(sitPoint.position, sitPoint.rotation);
            interacter.Anim.Event.RegistEvent(AnimationEventType.Start, RegistChangeState);
        }
    }

    private void RegistChangeState()
    {
        interacter.Anim.Event.UnregistEvent(AnimationEventType.Start, RegistChangeState);
        interacter.Anim.Event.RegistEvent(AnimationEventType.End, ChangeState);
    }

    private void ChangeState()
    {
        if(string.IsNullOrEmpty(sitStateaName) == false)
        {
            interacter.FSM.SetNextState(sitStateaName);
        }

        interacter.Anim.Event.UnregistEvent(AnimationEventType.End, ChangeState);
    }
}