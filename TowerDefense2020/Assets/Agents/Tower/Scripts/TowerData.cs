using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class TowerData : IScore, IDamageStats, INamed, IBuffStats, ILevel
{
    [SerializeField] private new string name;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float fireCoolDown;
    [SerializeField] private float aoe;
    [SerializeField] private float slow;
    [SerializeField] private float dot;

    [SerializeField] private float buffDamage;
    [SerializeField] private float buffRange;
    [SerializeField] private float buffFireCoolDown;
    [SerializeField] private float buffAoe;
    [SerializeField] private float buffSlow;
    [SerializeField] private float buffDot;
    private ParticleSystem psystem;
    private int xp;
    private int level;
    private int kills;

    public int Xp { get { return xp; } set { xp = value; } }
    public int Level { get { return level; } set { level = value; } }
    public int Kills { get { return kills; } set { kills = value; } }
    public float Damage { get { return damage; } set { damage = value; } }
    public float Range { get { return range; } set { range = value; } }
    public float FireCoolDown { get { return fireCoolDown; } set { fireCoolDown = value; } }
    public float Aoe { get { return aoe; } set { aoe = value; } }
    public float Dot { get { return dot; } set { dot = value; } }
    public float Slow { get => slow; set => slow = value; }
    public string Name { get { return name; } set { name = value; } }

    //public float BuffDamage { get => buffDamage; set => buffDamage = value; }
    public float BuffDamage
    {
        get { return buffDamage; }
        set { 
            if(value > 0) // start particle effect
            {
                if(psystem != null)
                {
                    psystem.Play();
                }
            }
            else //disable particle effect
            {
                if (psystem != null)
                {
                    psystem.Stop();
                }
            }
            buffDamage = value; 
        }
    }
    public float BuffRange { get => buffRange; set => buffRange = value; }
    public float BuffFireCoolDown { get => buffFireCoolDown; set => buffFireCoolDown = value; }
    public float BuffAoe { get => buffAoe; set => buffAoe = value; }
    public float BuffSlow { get => buffSlow; set => buffSlow = value; }
    public float BuffDot { get => buffDot; set => buffDot = value; }

    public GameObject GameObject => null;

    public string GetXP()
    {
        return "XP: " + Xp.ToString();
    }
    public string GetLevel()
    {
        return "Level: " + Xp.ToString();
    }
    public string GetKills()
    {
        return "Kills: " + Xp.ToString();
    }
    public string GetDamage()
    {
        return "Damage: " + Xp.ToString();
    }
    public void InjectParticleSystem(ParticleSystem psys)
    {
        this.psystem = psys;
    }
}
