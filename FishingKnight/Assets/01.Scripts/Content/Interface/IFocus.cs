using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFocus
{
    public Entity GetEntity();
    public void StartFocus(Entity performer);
    public void EndFocus(Entity performer);
}
