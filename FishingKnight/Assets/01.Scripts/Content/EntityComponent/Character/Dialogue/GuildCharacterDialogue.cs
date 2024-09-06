using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildCharacterDialogue : CharacterDialogue
{
    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        AddDialogueAction(new DialogueAction("What do you want", speakSpeed));
        AddDialogueAction(new DialogueAction(new ChoiceActionButtonInfo[]
        {
            new ChoiceActionButtonInfo("Quest", () =>
            {
                CharacterInventory showInventory = dialoguePartner.GetEntityComponent<CharacterInventory>();
                if(showInventory == null)
                    return;

                InventoryUIPanel inventoryUI = Manager.UI.MainCanvas.GetPanel<InventoryUIPanel>();
                inventoryUI.SetInventory(owner, showInventory);
                inventoryUI.SetInventoryAction(InventoryActionType.Sell);
                inventoryUI.Show();
            }),
            new ChoiceActionButtonInfo("Team", () =>
            {
                CharacterInventory showInventory = owner.GetEntityComponent<CharacterInventory>();
                if(showInventory == null)
                    return;

                InventoryUIPanel inventoryUI = Manager.UI.MainCanvas.GetPanel<InventoryUIPanel>();
                inventoryUI.SetInventory(dialoguePartner, showInventory);
                inventoryUI.SetInventoryAction(InventoryActionType.Buy);
                inventoryUI.Show();
            }),
            new ChoiceActionButtonInfo("Quit", () =>
            {
                ShowDialogue();
            }),
        }));
        AddDialogueAction(new DialogueAction("See you next time", speakSpeed));
    }
}
