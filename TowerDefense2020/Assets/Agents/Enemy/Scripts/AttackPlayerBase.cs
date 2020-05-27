using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerBase : MonoBehaviour, IDealDamage
{
    GameObject playerBase;
    private bool attacking = false;
    private float fireCoolDown;
    private float damage;
    private float fireCoolDownLeft;

    public GameObject GameObject => this.gameObject;
    IScore score;
    public void Start()
    {
        damage = GetComponent<EnemyDamage>().BulletDamage;
        fireCoolDown = GetComponent<EnemyDamage>().FireCoolDown;
        fireCoolDownLeft = fireCoolDown;
        playerBase = GameObject.Find("Fortress");
        score = this.GetComponent<IScore>();
    }
    public void DealDamage(float damage)
    {
        if(playerBase != null)
        {
            //Debug.Log("Dealt damage: playerbase.Getcomponent<playerTakeDamage>..");
            playerBase.GetComponent<PlayerTakeDamage>().TakeDamage(damage, score);
        }
    }

    public void StartAttack()
    {
        //Debug.Log("Start Attacking");
        attacking = true;
    }
    void Update()
    {
       
        if (attacking)
        {
            fireCoolDownLeft -= Time.deltaTime;
            if(fireCoolDownLeft <= 0)
            {
                DealDamage(this.damage);
                //Debug.Log("DEAL DAMAGE");
                fireCoolDownLeft = fireCoolDown;
            }
        }
    }
}
