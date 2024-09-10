using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PawnArrangeInfo
{
    [Range(0, 7)]
    public int x;
    [Range(0, 3)]
    public int y;
    public PawnSO pawnSO;
}

[CreateAssetMenu(menuName = ("SO/Dungeon/DungeonBoard"))]
public class DungeonBoardSO : ScriptableObject
{
    [SerializeField] private List<PawnArrangeInfo> monsterPawnArrangeInfoList;
    public List<PawnArrangeInfo> MonsterPawnArrangeInfoList => monsterPawnArrangeInfoList;
}