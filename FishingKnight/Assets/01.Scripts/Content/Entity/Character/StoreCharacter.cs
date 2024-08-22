using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCharacter : Character, IInteract
{
    [SerializeField] private Chair sitChair;

    protected override void Start()
    {
        base.Start();

        if (sitChair != null)
            sitChair.Interact(this);
    }

    public void Interact(Entity performer)
    {
        GetEntityComponent<CharacterDialogue>().StartDialogue(performer);
        //ChoiceUIPanel panel = Manager.UI.MainCanvas.GetPanel<ChoiceUIPanel>();
        //panel.SetActionButton(new ChoiceActionButtonInfo[]
        //{
        //    new ChoiceActionButtonInfo("Sell", () =>
        //    {
        //        CharacterInventory showInventory = performer.GetEntityComponent<CharacterInventory>();
        //            if(showInventory == null)
        //                return;

        //            InventoryUIPanel inventoryUI = Manager.UI.MainCanvas.GetPanel<InventoryUIPanel>();
        //            inventoryUI.SetInventory(this, showInventory);
        //            inventoryUI.SetInventoryAction(InventoryActionType.Sell);
        //            inventoryUI.Show();
        //    }),
        //    new ChoiceActionButtonInfo("Buy", () =>
        //    {
        //        CharacterInventory showInventory = GetEntityComponent<CharacterInventory>();
        //        if(showInventory == null)
        //            return;

        //        InventoryUIPanel inventoryUI = Manager.UI.MainCanvas.GetPanel<InventoryUIPanel>();
        //        inventoryUI.SetInventory(performer, showInventory);
        //        inventoryUI.SetInventoryAction(InventoryActionType.Buy);
        //        inventoryUI.Show();
        //    }),
        //    new ChoiceActionButtonInfo("Quit", () =>
        //    {
        //        Manager.UI.HidePanel();
        //    }),
        //});
        //panel.Show();
    }
}