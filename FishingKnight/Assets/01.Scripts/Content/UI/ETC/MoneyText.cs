using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : UIObject
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void SetMoney(int money)
    {
        moneyText.text = money.ToString("N0");
    }
}