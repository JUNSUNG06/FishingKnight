using System;

public class ChoiceActionButtonInfo
{
    public ChoiceActionButtonInfo(string text, Action action)
    {
        Text = text;
        Action = action;
    }

    public string Text;
    public Action Action;
}