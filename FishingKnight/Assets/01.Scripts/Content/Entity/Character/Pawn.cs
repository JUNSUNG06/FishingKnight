using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Character, IDrag, IArrangement
{
    [SerializeField] private PawnSO info;
    public PawnSO Info => info;

    public void OnStrtDrag()
    {
        
    }

    public void OnEndDrag()
    {
        
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void OnArrangement(HexGrid grid)
    {
        
    }

    public void OnUnArrangement()
    {
        
    }
}