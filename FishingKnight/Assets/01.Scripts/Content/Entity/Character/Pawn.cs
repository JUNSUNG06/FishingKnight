using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Character
{
    [SerializeField] private PawnSO info;
    public PawnSO Info => info;
}