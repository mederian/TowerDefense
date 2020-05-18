using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 0.2f;
    [SerializeField] private float fireCoolDown = 1.2f;

    public float BulletDamage { get => bulletDamage; set => bulletDamage = value; }
    public float FireCoolDown { get => fireCoolDown; set => fireCoolDown = value; }
}
