using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<PawnSO> holdingPawns;
    public List<PawnSO> HoldingPawns => holdingPawns;

    private void Awake()
    {
        holdingPawns = new List<PawnSO>();
    }

    public void AddHoldingPawn(PawnSO info)
    {
        holdingPawns.Add(info);
    }
}
