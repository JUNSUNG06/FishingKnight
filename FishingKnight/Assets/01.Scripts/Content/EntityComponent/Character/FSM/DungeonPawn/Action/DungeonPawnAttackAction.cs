using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawnAttackAction : DungeonPawnFSMAction
{
    private DungeonPawnBattleComponent battle;
    private EntityAnimation anim;

    [SerializeField] private string attackAnimHash;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        battle = pawn.GetEntityComponent<DungeonPawnBattleComponent>();
        anim = pawn.GetEntityComponent<EntityAnimation>();
    }

    public override void EnterState()
    {
        base.EnterState();

        anim.Event.RegistEvent(AnimationEventType.End, SetNextAttack);
        anim.Event.RegistEvent(AnimationEventType.Playing, AttackHitCheck);
    }

    public override void ExitState()
    {
        base.ExitState();

        anim.Event.UnregistEvent(AnimationEventType.End, SetNextAttack);
        anim.Event.UnregistEvent(AnimationEventType.Playing, AttackHitCheck);

    }

    private void SetNextAttack()
    {
        StartCoroutine(AttackCo());
    }

    private IEnumerator AttackCo()
    {
        yield return new WaitForSeconds(battle.BattleSO.AttackDelayTime);
        
        anim.Animator.SetTrigger(attackAnimHash);
    }

    private void AttackHitCheck()
    {
        battle.Attack();
    }
}
