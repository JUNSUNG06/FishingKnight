using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingAction : FSMAction
{
    [SerializeField] private float minCatchDelay;
    [SerializeField] private float maxCatchDelay;
    private float catchDelay;

    private CharacterFishing fishing;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        fishing = character.GetEntityComponent<CharacterFishing>();
    }

    public override void EnterState()
    {
        base.EnterState();

        fishing.CurrentRob.OnItemStucked += OnStuckedItem;

        catchDelay = UnityEngine.Random.Range(minCatchDelay, maxCatchDelay);

        StartCoroutine(CatchDelay());
    }

    public override void ExitState()
    {
        base.ExitState();

        fishing.CurrentRob.OnItemStucked -= OnStuckedItem;

        StopAllCoroutines();
    }

    private IEnumerator CatchDelay()
    {
        yield return new WaitForSeconds(catchDelay);

        Item item = fishing.CurrentSpot.GetItem();

        fishing.CurrentRob.StuckItem(item);
    }

    private void OnStuckedItem(Item item)
    {
        Debug.Log(item.name);
    }
}
