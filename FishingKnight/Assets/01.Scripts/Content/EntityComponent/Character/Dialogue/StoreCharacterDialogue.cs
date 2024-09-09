using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class StoreCharacterDialogue : CharacterDialogue
{
    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        AddDialogueAction(new DialogueAction("Do you need anything?", speakSpeed));
        AddDialogueAction(new DialogueAction(new ChoiceActionButtonInfo[]
        {
            new ChoiceActionButtonInfo("Sell", () =>
            {
                CharacterInventory showInventory = dialoguePartner.GetEntityComponent<CharacterInventory>();
                if(showInventory == null)
                    return;

                InventoryUIPanel inventoryUI = Manager.Instance.UI.MainCanvas.GetPanel<InventoryUIPanel>();
                inventoryUI.SetInventory(owner, showInventory);
                inventoryUI.SetInventoryAction(InventoryActionType.Sell);
                inventoryUI.Show();
            }),
            new ChoiceActionButtonInfo("Buy", () =>
            {
                CharacterInventory showInventory = owner.GetEntityComponent<CharacterInventory>();
                if(showInventory == null)
                    return;

                InventoryUIPanel inventoryUI = Manager.Instance.UI.MainCanvas.GetPanel<InventoryUIPanel>();
                inventoryUI.SetInventory(dialoguePartner, showInventory);
                inventoryUI.SetInventoryAction(InventoryActionType.Buy);
                inventoryUI.Show();
            }),
            new ChoiceActionButtonInfo("Quit", () =>
            {
                ShowDialogue();
            }),
        }));
        AddDialogueAction(new DialogueAction("It was a good deal", speakSpeed));
    }
}
