using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    [SerializeField] private float chanceToHit = 100.0f;
    [SerializeField] private float damageReduction = 0;

    public float ChanceToHit { get => chanceToHit; set => chanceToHit = value; }
    public float DamageReduction { get => damageReduction; set => damageReduction = value; }

    public void Start()
    {
    }

    public float DamageAfterArmor(float damage)
    {
        if (HitStatus())
        {
            return damage - ((damage/100) * damageReduction);
        }
        else
        {
            return 0;
        }
    }
    //Return false if not hit..
    private bool HitStatus()
    {
        float rand = UnityEngine.Random.Range(0, 100f);
        if (rand <= chanceToHit)
        {
            return true;
        }
        return false;
    }
}
