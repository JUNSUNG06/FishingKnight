using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallet : CharacterComponent
{
    [SerializeField] private int initMoney;
    private int money;

    public int Money => money;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        money = initMoney;
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