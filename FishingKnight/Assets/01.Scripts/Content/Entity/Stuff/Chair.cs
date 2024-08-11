using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Stuff
{
    [SerializeField] private Transform sitPoint;

    public override void Interact(Entity performer)
    {
        base.Interact(performer);

        if(performer.TryGetComponent<Character>(out Character character))
        {
            character.FSM.SetNextState("Sit");
            character.transform.SetPositionAndRotation(sitPoint.position, sitPoint.rotation);
        }
    }
}
