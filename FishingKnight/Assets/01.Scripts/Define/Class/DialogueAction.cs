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
    private float doTextTime;
    public float DoTextTime => doTextTime;
    private Action onTextShowAction;
    public Action OnTextShowAction => onTextShowAction;

    public DialogueAction(string text, float doTextTime = 0.025f, Action onTextShowAction = null)
    {
        this.text = text;
        this.onTextShowAction = onTextShowAction;
        this.doTextTime = doTextTime;

        actionType = DialogueActionType.Talk;
    }

    public DialogueAction(params ChoiceActionButtonInfo[] buttonInfos)
    {
        this.butotnInfos = buttonInfos;

        actionType = DialogueActionType.MakeChoice;
    }
}
