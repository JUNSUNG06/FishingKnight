using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DungeonPawn/Battle")]
public class DungeonPawnBattleSO : ScriptableObject
{
    [SerializeField] private float attackPower;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDelayTime;
    [SerializeField] private float targetDetectRange;

    public float AttackPower => attackPower;
    public float AttackRange => attackRange;
    public float AttackDelayTime => attackDelayTime;
    public float TargetDetectRange => targetDetectRange;
}
