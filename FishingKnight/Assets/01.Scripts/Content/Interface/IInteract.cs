using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    public Entity GetEntity();
    public void Interact(Entity performer);
    public void UnInteract(Entity performer);
}
