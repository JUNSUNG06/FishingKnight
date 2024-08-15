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

    public void ShowPaenl(UIPanel panel)
    {
        if (panel == null)
            return;

        panelStack.Push(panel);

        if(panelStack.Count == 1)
        {
            InputManager.ChangeInputMap(InputMapType.UI);
            InputManager.GetInputSO<UIInputActionType>(InputMapType.UI)
                .RegistAction(UIInputActionType.Back, HidePanelByInptu);
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
                .UnregistAction(UIInputActionType.Back, HidePanelByInptu);
            InputManager.ChangeInputMap(InputMapType.Play);
        }
    }

    private void HidePanelByInptu(CallbackContext context)
    {
        if (context.started)
            HidePanel();
    }
}
