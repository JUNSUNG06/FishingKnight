using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIPanel : UIPanel
{
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private ChoiceActionButtonContainer choiceActionButtonContainer;
    [SerializeField] private Image enterImage;

    public void SetSpeakerName(string name)
    {
        speakerNameText.text = name;
    }

    public void ShowDialogue(DialogueAction dialogueAction)
    {
        switch (dialogueAction.ActionType)
        {
            case DialogueActionType.Talk:
                ShowText(dialogueAction.Text, dialogueAction.OnTextShowAction);
                break;
            case DialogueActionType.MakeChoice:
                MakeChoice(dialogueAction.ButotnInfos);
                break;
        }
    }

    private void ShowText(string text, Action action)
    {
        dialogueText.gameObject.SetActive(true);
        choiceActionButtonContainer.Hide();

        dialogueText.text = text;

        action?.Invoke();
    }

    private void MakeChoice(params ChoiceActionButtonInfo[] buttonInfos)
    {
        dialogueText.gameObject.SetActive(false);
        choiceActionButtonContainer.Show();

        choiceActionButtonContainer.SetActionButton(buttonInfos);
    }
}