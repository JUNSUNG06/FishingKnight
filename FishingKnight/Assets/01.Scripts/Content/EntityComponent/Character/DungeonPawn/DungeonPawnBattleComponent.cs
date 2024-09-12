using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPawnBattleComponent : DungeonPawnComponent
{
    private Entity target;
    public Entity Target => target;
    private RaycastHit detectTargetInfo;

    [SerializeField] private DungeonPawnBattleSO battleSO;
    public DungeonPawnBattleSO BattleSO => battleSO;

    private NavMovement nav;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        nav = entity.GetEntityComponent<NavMovement>();
    }

    private void Update()
    {
        if(nav != null && target != null)
        {
            nav.SetDestination(target.transform.position);
        }
    }

    public Entity FindTarget()
    {
        Entity detectTarget = null;
        RaycastHit[] hits = Physics.SphereCastAll(
            transform.position, battleSO.TargetDetectRange, Vector3.forward);

        foreach(RaycastHit hit in hits)
        {
            if(hit.transform.TryGetComponent<Entity>(out Entity hitEntity))
            {
                if (hitEntity == entity)
                    continue;

                if(hitEntity.TryGetComponent<IDamage>(out IDamage idamage))
                {
                    if(detectTarget != null)
                    {
                        if (Vector3.Distance(transform.position, detectTarget.transform.position)
                            < Vector3.Distance(transform.position, hitEntity.transform.position))
                        {
                            continue;
                        }
                    }

                    detectTarget = hitEntity;
                    detectTargetInfo = hit;
                }
            }
        }

        target = detectTarget;
        return detectTarget;
    }

    public virtual void Attack()
    {
        if (target == null)
            return;

        IDamage idamage = target.GetComponent<IDamage>();
        idamage.OnDamaged(entity, BattleSO.AttackPower, detectTargetInfo.point,
            -transform.forward, detectTargetInfo.normal);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, battleSO.TargetDetectRange);
    }
}