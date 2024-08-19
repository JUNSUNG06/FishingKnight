using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallet : CharacterComponent
{
    private int money;
    public int Money => money;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        money = 0;
    }

    public void AddMoeny(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
}