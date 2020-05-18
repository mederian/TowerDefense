using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerTakeDamage))]
public class DamageableComponent : MonoBehaviour
{
    
    [SerializeField] private int priority;
    [SerializeField] private float hp;

    public int Priority { get => priority; set => priority = value; }
    public float Hp { get => hp; set => hp = value; }

    public void BreakComponent()
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
}
