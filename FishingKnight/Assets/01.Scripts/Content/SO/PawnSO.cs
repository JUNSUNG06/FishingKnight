using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pawn")]
public class PawnSO : ScriptableObject
{
    [SerializeField] private Pawn prefab;
    [SerializeField] private string pawnName;
    [SerializeField] private int price;
    [SerializeField] private Sprite image;
    [TextArea][SerializeField] private string description;

    public string PawnName => pawnName;
    public int Price => price;
    public string Description => description;
    public Sprite Image => image;
    public Pawn Prefab => prefab;
}
