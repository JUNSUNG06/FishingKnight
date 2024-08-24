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

    private bool isDoTexting;
    private Coroutine waitDoText;

    public void SetSpeakerName(string name)
    {
        speakerNameText.text = name;
    }

    public void ShowDialogue(DialogueAction dialogueAction, Action<bool> onEndAction)
    {
        switch (dialogueAction.ActionType)
        {
            case DialogueActionType.Talk:
                ShowText(dialogueAction.Text, dialogueAction.DoTextTime, dialogueAction.OnTextShowAction, onEndAction);
                break;
            case DialogueActionType.MakeChoice:
                MakeChoice(onEndAction, dialogueAction.ButotnInfos);
                break;
        }
    }

    private void ShowText(string text, float doTextTime, Action onStartAction, Action<bool> onEndAction)
    {
        dialogueText.gameObject.SetActive(true);
        choiceActionButtonContainer.Hide();

        if (isDoTexting == false)
        {
            waitDoText = StartCoroutine(WaitDoText(dialogueText.DOText(text, doTextTime), onEndAction));

            onStartAction?.Invoke();

            onEndAction?.Invoke(false);
        }
        else
        {
            dialogueText.StopAllCoroutines();
            if (waitDoText != null)
            {
                StopCoroutine(waitDoText);
                waitDoText = null;
            }

            dialogueText.text = text;
            isDoTexting = false;

            onEndAction?.Invoke(true);
        }
    }

    private IEnumerator WaitDoText(Coroutine DOTextFunc, Action<bool> onEndAction)
    {
        isDoTexting = true;

        yield return DOTextFunc;

        isDoTexting = false;
        waitDoText = null;
        onEndAction?.Invoke(true);
    }

    private void MakeChoice(Action<bool> onEndAction, params ChoiceActionButtonInfo[] buttonInfos)
    {
        dialogueText.gameObject.SetActive(false);
        choiceActionButtonContainer.Show();

        choiceActionButtonContainer.SetActionButton(buttonInfos);

        onEndAction?.Invoke(true);
    }
}