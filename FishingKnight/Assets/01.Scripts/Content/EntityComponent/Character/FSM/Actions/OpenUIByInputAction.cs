using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class OpenUIByInputAction : FSMAction
{
    [SerializeField] private PlayInputSO input;

    private CharacterInventory inventory;
    private CharacterHolder holder;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        inventory = character.GetEntityComponent<CharacterInventory>();
        holder = character.GetEntityComponent<CharacterHolder>();
    }

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
            InventoryUIPanel ui = Manager.Instance.UI.MainCanvas.GetPanel<InventoryUIPanel>();
            
            ui.SetInventory(character, inventory);
            ui.SetInventoryAction(InventoryActionType.Hold, InventoryActionType.Remove);
            ui.Show();
        }
    }

    private void OpenHoldItemUI(CallbackContext context)
    {
        if (context.started)
        {
            HoldItemUIPanel ui = Manager.Instance.UI.MainCanvas.GetPanel<HoldItemUIPanel>();

            ui.SetHolder(holder);
            ui.Show();
        }
    }
}
