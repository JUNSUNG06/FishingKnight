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

                InventoryUIPanel inventoryUI = Manager.Instance.UI.MainCanvas.GetPanel<InventoryUIPanel>();
                inventoryUI.SetInventory(owner, showInventory);
                inventoryUI.SetInventoryAction(InventoryActionType.Sell);
                inventoryUI.Show();
            }),
            new ChoiceActionButtonInfo("Pawn", () =>
            {
                CharacterWallet wallet = dialoguePartner.GetEntityComponent<CharacterWallet>();
                if(wallet == null)
                    return;

                PawnStoreUIPanel pawnStoreUI = Manager.Instance.UI.MainCanvas.GetPanel<PawnStoreUIPanel>();
                pawnStoreUI.SetBuyer(dialoguePartner);
                pawnStoreUI.Show();
            }),
            new ChoiceActionButtonInfo("Quit", () =>
            {
                ShowDialogue();
            }),
        }));
        AddDialogueAction(new DialogueAction("See you next time", speakSpeed));
    }
}
