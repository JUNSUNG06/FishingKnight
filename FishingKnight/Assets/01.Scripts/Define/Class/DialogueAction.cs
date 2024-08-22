using System;

[Serializable]
public class DialogueAction
{
    private DialogueActionType actionType;
    public DialogueActionType ActionType => actionType;

    private ChoiceActionButtonInfo[] butotnInfos;
    public ChoiceActionButtonInfo[] ButotnInfos => butotnInfos;

    private string text;
    public string Text => text;
    private Action onTextShowAction;
    public Action OnTextShowAction => onTextShowAction;

    public DialogueAction(string text, Action onTextShowAction = null)
    {
        this.text = text;
        this.onTextShowAction = onTextShowAction;

        actionType = DialogueActionType.Talk;
    }

    public DialogueAction(params ChoiceActionButtonInfo[] buttonInfos)
    {
        this.butotnInfos = buttonInfos;

        actionType = DialogueActionType.MakeChoice;
    }
}
