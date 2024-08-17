using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : Entity
{
    [SerializeField] private FishingSpotSO fishingSpotSO;

    public Item GetItem()
    {
        int randomIndex = UnityEngine.Random.Range(0, fishingSpotSO.FishList.Count);    
        ItemSO itemSO = fishingSpotSO.FishList[randomIndex];

        Item item = Instantiate(itemSO.Prefab, transform);

        return item;
    }
}