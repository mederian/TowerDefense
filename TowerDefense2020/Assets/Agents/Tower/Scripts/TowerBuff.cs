using System.Collections;
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
    private float damageBuffCooldown;
    private float aoeBuffCooldown;
    private float slowBuffCooldown;
    private float dotBuffCooldown;
    private float rangeBuffCooldown;
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

    public void RecieveBuff(List<Resource> resources)
    {
        Debug.Log("RECIEVE BUFF..............................................................");
        //TODO: Extract this to separate script that inherit function from interface
        //Interface handleBuff ... -> handle buff
        if (GetComponent<ConstructionStatus>().IsConstructionComplete())
        {
            Debug.Log("iscontstuctioncomplete");
            foreach (Resource r in resources)
            {
                if(r.name == damageBuffResource)
                {
                    int buffValue;
                    int overflow = (int)buffData.BuffDamage;
             
                    if (r.value > buffCap) buffValue = buffCap;
                    else buffValue = r.value;

                    buffValue -= overflow;

                    if(buffValue > 0)
                    {
                        buffData.BuffDamage += buffValue;
                        damageBuffCooldown = towerBuffCooldown;
                        r.value -= buffValue;
                    }
 
                }
                else if (r.name == aoeBuffResource)
                {
                    Debug.Log("Attempt buff, aoe ");
                    int buffValue;
                    int overflow = (int)buffData.BuffAoe;

                    if (r.value > buffCap) buffValue = buffCap;
                    else buffValue = r.value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffAoe += buffValue;
                        aoeBuffCooldown = towerBuffCooldown;
                        r.value -= buffValue;
                    }
                }
                else if (r.name == slowBuffResource)
                {
                    int buffValue;
                    int overflow = (int)buffData.BuffSlow;

                    if (r.value > buffCap) buffValue = buffCap;
                    else buffValue = r.value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffSlow += buffValue;
                        slowBuffCooldown = towerBuffCooldown;
                        r.value -= buffValue;
                    }
                }
                else if (r.name == dotBuffResource)
                {
                    int buffValue;
                    int overflow = (int)buffData.BuffDot;

                    if (r.value > buffCap) buffValue = buffCap;
                    else buffValue = r.value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffDot += buffValue;
                        dotBuffCooldown = towerBuffCooldown;
                        r.value -= buffValue;
                    }

                }
                else if (r.name == rangeBuffResource)
                {
                    int buffValue;
                    int overflow = (int)buffData.BuffRange;

                    if (r.value > buffCap) buffValue = buffCap;
                    else buffValue = r.value;

                    buffValue -= overflow;

                    if (buffValue > 0)
                    {
                        buffData.BuffRange += buffValue;
                        rangeBuffCooldown = towerBuffCooldown;
                        r.value -= buffValue;
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
