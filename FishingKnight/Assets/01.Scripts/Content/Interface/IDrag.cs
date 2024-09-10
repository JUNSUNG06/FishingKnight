using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDrag
{
    public Transform GetTransform();
    public void OnStrtDrag();
    public void OnEndDrag();
}