using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArrangement
{
    public Transform GetTransform();
    public void OnArrangement(HexGrid grid);
    public void OnUnArrangement();
}