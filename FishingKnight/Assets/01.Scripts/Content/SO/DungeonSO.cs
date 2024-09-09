using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("SO/Dungeon/Dungeon"))]
public class DungeonSO : ScriptableObject
{
    [SerializeField] private DungeonBoard boardPrefab;
    [SerializeField] private List<DungeonBoardSO> boardSOList;

    public DungeonBoard BoardPrefab => boardPrefab;
    public List<DungeonBoardSO> BoardSOList => boardSOList;
}
