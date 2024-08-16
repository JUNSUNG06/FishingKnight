using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryActionButton : UIObject
{
    [SerializeField] private TextMeshProUGUI text;
    private Button button;

    public override void Initialize()
    {
        base.Initialize();

        button = GetComponent<Button>();
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetAction(Action action)
    {
        button.onClick.AddListener(() => action?.Invoke());
    }
}
