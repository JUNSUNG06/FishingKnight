using OMG.Inputs;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class UIManager
{
    private UICanvas mainCanvas;
    public UICanvas MainCanvas
    {
        get
        {
            if (mainCanvas == null)
            {
                mainCanvas = GameObject.Find("MainCanvas").GetComponent<UICanvas>();
            }

            return mainCanvas;
        }
    }

    private Stack<UIPanel> panelStack;
    public Stack<UIPanel> PanelStack => panelStack;

    public UIManager()
    {
        panelStack = new Stack<UIPanel>();
    }

    public void ShowPanel(UIPanel panel)
    {
        if (panel == null)
            return;

        if(PanelStack.Count > 0)
        {
            panelStack.Peek().Hide();
        }

        panelStack.Push(panel);

        if(panelStack.Count == 1)
        {
            InputManager.ChangeInputMap(InputMapType.UI);
            InputManager.GetInputSO<UIInputActionType>(InputMapType.UI)
                .RegistAction(UIInputActionType.Back, HidePanelByInput);
        }
    }

    public void HidePanel()
    {
        if (panelStack.Count == 0)
            return;

        UIPanel panel = panelStack.Pop();
        panel.Hide();

        if (panelStack.Count == 0)
        {
            InputManager.GetInputSO<UIInputActionType>(InputMapType.UI)
                .UnregistAction(UIInputActionType.Back, HidePanelByInput);
            InputManager.ChangeInputMap(InputMapType.Play);
        }
        else
        {
            panelStack.Peek().OnlyShow();
        }
    }

    private void HidePanelByInput(CallbackContext context)
    {
        if (context.started == false)
            return;

        if (panelStack.Peek().CanHideByInput == false)
            return;

        HidePanel();
    }
}
