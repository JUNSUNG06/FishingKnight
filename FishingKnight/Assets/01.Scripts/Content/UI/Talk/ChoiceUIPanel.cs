using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceUIPanel : UIPanel
{
    public struct ChoiceActionButtonInfo
    {
        public string Text;
        public Action Action;
    }

    [SerializeField] private ActionButton actionbuttonPrefab;
    [SerializeField] private Transform buttonContainer;

    public void SetActionButton(params ChoiceActionButtonInfo[] actionbuttonInfos)
    {
        for(int i = 0; i < buttonContainer.childCount - 1; i++)
        {
            Destroy(buttonContainer.GetChild(i).gameObject);
        }

        for(int i = 0; i < actionbuttonInfos.Length; i++)
        {
            ActionButton button = Instantiate(actionbuttonPrefab, buttonContainer);
            button.Initialize();
            button.SetText(actionbuttonInfos[i].Text);
            button.SetAction(actionbuttonInfos[i].Action);
        }
    }
}