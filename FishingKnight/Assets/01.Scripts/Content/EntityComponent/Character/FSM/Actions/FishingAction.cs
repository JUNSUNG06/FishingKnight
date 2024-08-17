using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingAction : FSMAction
{
    [SerializeField] private float minCatchDelay;
    [SerializeField] private float maxCatchDelay;
    private float catchDelay;

    public override void EnterState()
    {
        base.EnterState();

        character.Fishing.CurrentRob.OnItemStucked += OnStuckedItem;

        catchDelay = UnityEngine.Random.Range(minCatchDelay, maxCatchDelay);

        StartCoroutine(CatchDelay());
    }

    public override void ExitState()
    {
        base.ExitState();

        character.Fishing.CurrentRob.OnItemStucked -= OnStuckedItem;

        StopAllCoroutines();
    }

    private IEnumerator CatchDelay()
    {
        yield return new WaitForSeconds(catchDelay);

        Item item = character.Fishing.CurrentSpot.GetItem();

        character.Fishing.CurrentRob.StuckItem(item);
    }

    private void OnStuckedItem(Item item)
    {
        Debug.Log(item.name);
    }
}
