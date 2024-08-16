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
    }

    public override void ExitState()
    {
        base.ExitState();

        input.UnregistAction(PlayInputActionType.OpenInventory, OpenInventoryUI);
    }

    private void OpenInventoryUI(CallbackContext context)
    {
        if(context.started)
        {
            InventoryUIPanel ui = Manager.UI.MainCanvas.GetPanel<InventoryUIPanel>();
            
            ui.SetInventory(character.Inventory);
            ui.SetInventoryAction(InventoryActionType.Equipment, InventoryActionType.Remove);
            ui.Show();
        }
    }
}
