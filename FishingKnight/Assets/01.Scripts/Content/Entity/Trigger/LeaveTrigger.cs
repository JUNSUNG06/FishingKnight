using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : Trigger
{
    public override void OnTrigger(Collider other)
    {
        if (other.CompareTag("Player") == false)
            return;

        ChoiceUIPanel choiceUI = Manager.Instance.UI.MainCanvas.GetPanel<ChoiceUIPanel>();
        if (choiceUI == null)
            return;

        choiceUI.SetActionButton(new ChoiceActionButtonInfo[]
        {
            new ChoiceActionButtonInfo("Dungeon", () =>
            {
                Debug.Log("Go to dungeon");
            }),
            new ChoiceActionButtonInfo("Quit", () =>
            {
                Manager.Instance.UI.HidePanel();
                Debug.Log("Quit");
            }),
        });
        choiceUI.Show();
    }
}
