using UnityEngine;

public interface IDealDamage
{
    void DealDamage(float damage);
    GameObject GameObject { get; }
}
