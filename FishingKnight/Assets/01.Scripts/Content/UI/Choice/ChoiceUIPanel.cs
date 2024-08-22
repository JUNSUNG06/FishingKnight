using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceUIPanel : UIPanel
{
    [SerializeField] private ActionButton actionbuttonPrefab;
    [SerializeField] private Transform buttonContainer;

    public override void OnlyShow()
    {
        base.OnlyShow();

        foreach (Transform child in buttonContainer)
        {
            ActionButton button = child.GetComponent<ActionButton>();
            if (button == null)
                return;

            button.Show();
        }
    }

    public void SetActionButton(params ChoiceActionButtonInfo[] actionbuttonInfos)
    {
        transform.ClearChild();

        for(int i = 0; i < actionbuttonInfos.Length; i++)
        {
            ActionButton button = Instantiate(actionbuttonPrefab, buttonContainer);
            button.Initialize();
            button.SetText(actionbuttonInfos[i].Text);
            button.SetAction(actionbuttonInfos[i].Action);
            button.Show();
        }
    }
}