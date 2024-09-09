using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PawnStoreUIPanel : UIPanel
{
    [SerializeField] private List<PawnSO> pawnSOList;

    [Space]
    [SerializeField] private PawnStoreSlot slotPrefab;
    [SerializeField] private Transform slotContainer;

    [Space]
    [SerializeField] private MoneyText moneyText;

    [Space]
    [SerializeField] private PawnDescriptor descriptor;

    private Entity buyer;

    public override void Show()
    {
        base.Show();

        CreateSlot();
    }

    public void SetBuyer(Entity buyer)
    {
        this.buyer = buyer;

        CharacterWallet wallet = buyer.GetEntityComponent<CharacterWallet>();
        if (wallet == null)
            return;

        moneyText.SetMoney(wallet.Money);
    }

    private void CreateSlot()
    {
        slotContainer.ClearChild();

        for(int i = 0; i <  pawnSOList.Count; i++)
        {
            PawnStoreSlot slot = Instantiate(slotPrefab, slotContainer);
            slot.OnClickEvent += OnSlotClickHandle;
            slot.SetPawn(pawnSOList[i]);
        }
    }

    private void OnSlotClickHandle(PawnSO info)
    {
        descriptor.Show();

        CharacterWallet wallet = buyer.GetEntityComponent<CharacterWallet>();
        if (wallet == null)
            return;

        if (wallet.Money < info.Price)
            return;

        descriptor.SetPawn(info);

        descriptor.ClearActionButton();

        descriptor.CreateActionButton("Buy", () =>
        {
            wallet.RemoveMoney(info.Price);

            moneyText.SetMoney(wallet.Money);

            pawnSOList.Remove(info);
            Manager.Instance.Player.Player.AddHoldingPawn(info);

            CreateSlot();

            descriptor.Hide();
        });
    }
}