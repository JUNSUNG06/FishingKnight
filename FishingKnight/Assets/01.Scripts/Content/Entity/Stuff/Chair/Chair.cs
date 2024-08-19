using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Stuff
{
    [SerializeField] protected Transform sitPoint;

    protected Character interacter;

    public override void Interact(Entity performer)
    {
        base.Interact(performer);

        if(performer.TryGetComponent<Character>(out Character character))
        {
            interacter = character;
            interacter.GetEntityComponent<CharacterFSM>().SetNextState("Sit");
            interacter.transform.SetPositionAndRotation(sitPoint.position, sitPoint.rotation);
        }
    }
}