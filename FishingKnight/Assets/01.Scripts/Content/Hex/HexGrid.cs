using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    private Pawn standingPawn;
    public Pawn StandingPawn => standingPawn;

    public void SetPawn(Pawn pawn)
    {
        standingPawn = pawn;
        pawn.transform.position = transform.position;
    }
}
