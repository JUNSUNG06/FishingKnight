using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFishing : CharacterComponent
{
    private FishingSpot currentSpot;
    public FishingSpot CurrentSpot => currentSpot;

    private FishingRob currentRob;
    public FishingRob CurrentRob => currentRob;

    public void SetFishingSpot(FishingSpot spot)
    {
        currentSpot = spot;
    }

    public void SetFishingRob(FishingRob rob)
    {
        currentRob = rob;
    }
}
