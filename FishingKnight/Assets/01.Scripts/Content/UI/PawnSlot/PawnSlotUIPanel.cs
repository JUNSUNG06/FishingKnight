using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSlotUIPanel : UIPanel
{
    [SerializeField] private PawnSlot pawnSlotPrefab;
    [SerializeField] private Transform pawnSlotContainer;

    [Space]
    [SerializeField] private List<PawnSO> pawnSOList;

    public event Action<PawnSO> SpawnPawnAction;

    public override void Show()
    {
        base.Show();

        CreatePawnSlot();
    }

    public override void OnlyShow()
    {
        base.OnlyShow();

        CreatePawnSlot();
    }

    private void CreatePawnSlot()
    {
        pawnSlotContainer.ClearChild();

        //pawnSOList = Manager.Instance.Player.Player.HoldingPawns;

        for(int i = 0; i < pawnSOList.Count; i++)
        {
            PawnSlot slot = Instantiate(pawnSlotPrefab, pawnSlotContainer);
            slot.SetPawnSO(pawnSOList[i]);
            slot.OnClickEvent += OnSlotClickHandle;
        }
    }

    private void OnSlotClickHandle(PawnSlot slot)
    {
        pawnSOList.Remove(slot.PawnSO);
        SpawnPawnAction?.Invoke(slot.PawnSO);

        CreatePawnSlot();
    }
}
