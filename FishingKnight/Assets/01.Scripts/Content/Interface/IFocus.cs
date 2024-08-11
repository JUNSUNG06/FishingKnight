using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFocus
{
    public void StartFocus(Entity performer);
    public void EndFocus(Entity performer);
}
