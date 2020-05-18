using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: Require that this object is damageable
public class Spikes : MonoBehaviour
{
    [SerializeField] private float spikeDamageModifier = 0;

    public float SpikeDamageModifier { get => spikeDamageModifier; set => spikeDamageModifier = value; }

    public float DetermineSpikeDamage(float damage)
    {
        return (damage/100) * spikeDamageModifier;
        //TODO: MAYBE: Add Score element to playerbase, so that we can register killes etc for playerbase
    }

}
