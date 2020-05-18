using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour, IDamageable
{
    public GameObject GameObject { get { return this.gameObject; } }
    public bool TakeDamage(float damageTaken, IScore enemyScore)
    {
        return true;
    }

    public void TakeDamageOverTime(float damage, float duration, IScore enemyScore)
    {
        
    }

}
