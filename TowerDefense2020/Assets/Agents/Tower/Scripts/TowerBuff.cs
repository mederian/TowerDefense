﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuff : MonoBehaviour, IHandleBuff, IInjectBuffStats
{
    private string damageBuffResource = "Gold Essence";
    private string aoeBuffResource = "Fire Essence";
    private string slowBuffResource = "Frost Essence";
    private string dotBuffResource = "Poison Essence";
    private string rangeBuffResource = "Mana Essence";

    [SerializeField] private float towerBuffCooldown;
    [SerializeField] private int buffCap = 10;
    [SerializeField] private float damageBuffCooldown;
    [SerializeField] private float aoeBuffCooldown;
    [SerializeField] private float slowBuffCooldown;
    [SerializeField] private float dotBuffCooldown;
    [SerializeField] private float rangeBuffCooldown;
    private IBuffStats buffData;

    //TODO: Create inspector reference to interface for handling the buffs

    public delegate void BuffAction();
    public static event BuffAction OnBuff;

    public void Update()
    {
      
        if(aoeBuffCooldown > 0)
        {
            aoeBuffCooldown -= Time.deltaTime;
        }
        else if(aoeBuffCooldown <= 0 && buffData.BuffAoe > 0)
        {
            buffData.BuffAoe = 0;
        }

        if (damageBuffCooldown > 0)
        {
            damageBuffCooldown -= Time.deltaTime;

            //TODO: if counted down to <= 0 - update detailview
        }
        else if (damageBuffCooldown <= 0 && buffData.BuffDamage > 0)
        {
            buffData.BuffDamage = 0;
        }

        if (slowBuffCooldown > 0)
        {
            slowBuffCooldown -= Time.deltaTime;
        }
        else if (slowBuffCooldown <= 0 && buffData.BuffSlow > 0)
        {
            buffData.BuffSlow = 0;
        }

        if (dotBuffCooldown > 0)
        {
            dotBuffCooldown -= Time.deltaTime;
        }
        else if (dotBuffCooldown <= 0 && buffData.BuffDot > 0)
        {
            buffData.BuffDot = 0;
        }

        if (rangeBuffCooldown > 0)
        {
            rangeBuffCooldown -= Time.deltaTime;
        }
        else if (rangeBuffCooldown <= 0 && buffData.BuffRange > 0)
        {
            buffData.BuffRange = 0;
        }
      
    }

    public void RecieveBuff(List<ResourceScriptableObject> resources)
    {
        Debug.Log("RECIEVE BUFF..............................................................");
        //TODO: Extract this to separate script that inherit function from interface
        //Interface handleBuff ... -> handle buff
        if (GetComponent<ConstructionStatus>().IsConstructionComplete())
        {
            Debug.Log("iscontstuctioncomplete");
            foreach (ResourceScriptableObject r in resources)
            {
                if(r.ResourceName == damageBuffResource)
                {
                    Debug.Log("Attempt buff dmg: " + r.Value.ToString());
                    int buffValue;
                    int overflow = (int)buffData.BuffDamage;
             
                    if (r.Value > buffCap) buffValue = buffCap;
                    else buffValue = r.Value;
                    Debug.Log("Buff value1: " + buffValue.ToString());
                    buffValue -= overflow;

                    Debug.Log("Buff value2: " + buffValue.ToString());
                    if(buffValue > 0)
                    {
                        buffData.BuffDamage += buffValue;
                        damageBuffCooldown = towerBuffCooldown;
                        r.Value -= buffValue;
                        Debug.Log("Buffvalue vas over 0");
                    }
 
                }
                else if (r.ResourceName == aoeBuffResource)
                {
                    Debug.Log("Attempt buff, aoe ");
                    int buffValue;
                    int overflow = (int)buffData.BuffAoe;

                    if (r.Value > buffCap) buffValue = buffCap;
                    else buffValue = r.Value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffAoe += buffValue;
                        aoeBuffCooldown = towerBuffCooldown;
                        r.Value -= buffValue;
                    }
                }
                else if (r.ResourceName == slowBuffResource)
                {
                    int buffValue;
                    int overflow = (int)buffData.BuffSlow;

                    if (r.Value > buffCap) buffValue = buffCap;
                    else buffValue = r.Value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffSlow += buffValue;
                        slowBuffCooldown = towerBuffCooldown;
                        r.Value -= buffValue;
                    }
                }
                else if (r.ResourceName == dotBuffResource)
                {
                    int buffValue;
                    int overflow = (int)buffData.BuffDot;

                    if (r.Value > buffCap) buffValue = buffCap;
                    else buffValue = r.Value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffDot += buffValue;
                        dotBuffCooldown = towerBuffCooldown;
                        r.Value -= buffValue;
                    }

                }
                else if (r.ResourceName == rangeBuffResource)
                {
                    int buffValue;
                    int overflow = (int)buffData.BuffRange;

                    if (r.Value > buffCap) buffValue = buffCap;
                    else buffValue = r.Value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffRange += buffValue;
                        rangeBuffCooldown = towerBuffCooldown;
                        r.Value -= buffValue;
                    }
                }
            }
            //resources.Clear();
        }
        else
        {

        }
    }

    public void InjectBuffStats(IBuffStats buffData)
    {
        this.buffData = buffData;
    }
}
