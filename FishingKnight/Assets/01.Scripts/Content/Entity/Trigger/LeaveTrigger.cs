using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : Trigger
{
    public override void OnTrigger(Collider other)
    {
        if (other.CompareTag("Player") == false)
            return;

        ChoiceUIPanel choiceUI = Manager.UI.MainCanvas.GetPanel<ChoiceUIPanel>();
        if (choiceUI == null)
            return;

        choiceUI.SetActionButton(new ChoiceUIPanel.ChoiceActionButtonInfo[]
        {
            new ChoiceUIPanel.ChoiceActionButtonInfo()
            {
                Text = "Dungeon",
                Action = () =>
                {
                    Debug.Log("Go to dungeon");
                }
            },
            new ChoiceUIPanel.ChoiceActionButtonInfo()
            {
                Text = "Quit",
                Action = () =>
                {
                    Manager.UI.HidePanel();
                    Debug.Log("Quit");
                }
            },
        });
        choiceUI.Show();
    }
}
