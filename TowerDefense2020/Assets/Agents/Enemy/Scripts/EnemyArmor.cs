using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmor : MonoBehaviour, IArmor
{
    [SerializeField] private float chanceToHit;
    [SerializeField] private float damageReduction;     

    public float DamageAfterArmor(float damage)
    {
        float finalDamage = damage;
        float reductionValue = (damage / 100) * damageReduction;
        //Create randomizer for chance to hit
        if (!GetHitStatus()) {
            Debug.Log("MISSED MEEE");
            return -1;
        }

        finalDamage -= reductionValue;

        if (finalDamage < 0) finalDamage = 0;

        return finalDamage;
    }

    private bool GetHitStatus()
    {
        float rand = UnityEngine.Random.Range(0, 100f);
        if(rand <= chanceToHit)
        {
            //Debug.Log("Random: " + rand + " Chance:" + chanceToHit);
            return true;
        }
        return false;
    }
}
