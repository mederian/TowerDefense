using UnityEngine;

public interface IDamageable
{
    bool TakeDamage(float damage, IScore sourceScore);
    void TakeDamageOverTime(float damage, float duration, IScore sourceScore);
    GameObject GameObject { get; }
}
