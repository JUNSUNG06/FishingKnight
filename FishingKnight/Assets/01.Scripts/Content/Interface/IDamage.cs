using UnityEngine;

public interface IDamage
{
    public void OnDamaged(Entity attacker, float power, Vector3 point,
        Vector3 direction = default, Vector3 normal = default);
}
