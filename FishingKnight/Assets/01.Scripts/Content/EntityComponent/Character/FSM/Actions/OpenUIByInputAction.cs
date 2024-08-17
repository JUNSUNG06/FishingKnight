using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class OpenUIByInputAction : FSMAction
{
    [SerializeField] private PlayInputSO input;

    public override void EnterState()
    {
        base.EnterState();

        input.RegistAction(PlayInputActionType.OpenInventory, OpenInventoryUI);
        input.RegistAction(PlayInputActionType.OpenHoldItem, OpenHoldItemUI);
    }

    public override void ExitState()
    {
        base.ExitState();

        input.UnregistAction(PlayInputActionType.OpenInventory, OpenInventoryUI);
        input.UnregistAction(PlayInputActionType.OpenHoldItem, OpenHoldItemUI);
    }

    private void OpenInventoryUI(CallbackContext context)
    {
        if(context.started)
        {
            InventoryUIPanel ui = Manager.UI.MainCanvas.GetPanel<InventoryUIPanel>();
            
            ui.SetInventory(character.Inventory);
            ui.SetInventoryAction(InventoryActionType.Hold, InventoryActionType.Remove);
            ui.Show();
        }
    }

    private void OpenHoldItemUI(CallbackContext context)
    {
        if (context.started)
        {
            HoldItemUIPanel ui = Manager.UI.MainCanvas.GetPanel<HoldItemUIPanel>();

            ui.SetHolder(character.Holder);
            ui.Show();
        }
    }
}
