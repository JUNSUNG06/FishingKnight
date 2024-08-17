using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Fishing/Spot")]
public class FishingSpotSO : ScriptableObject
{
    [SerializeField] private List<ItemSO> fishList;

    public List<ItemSO> FishList => fishList;
}