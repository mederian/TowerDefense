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

    private int xp;
    private int level;
    private int kills;
    private ParticleSystem psystemYellow;
    private ParticleSystem psystemRed;
    private ParticleSystem psystemBlue;
    private ParticleSystem psystemGreen;
    private ParticleSystem psystemPurple;

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
                if(psystemYellow != null)
                {
                    psystemYellow.Play();
                }
            }
            else //disable particle effect
            {
                if (psystemYellow != null)
                {
                    psystemYellow.Stop();
                }
            }
            buffDamage = value; 
        }
    }
    public float BuffRange
    {
        get { return buffRange; }
        set
        {
            if (value > 0) // start particle effect
            {
                if (psystemPurple != null)
                {
                    psystemPurple.Play();
                }
            }
            else //disable particle effect
            {
                if (psystemPurple != null)
                {
                    psystemPurple.Stop();
                }
            }
            buffRange = value;
        }
    }
    public float BuffFireCoolDown { get => buffFireCoolDown; set => buffFireCoolDown = value; }

    public float BuffAoe
    {
        get { return buffAoe; }
        set
        {
            if (value > 0) // start particle effect
            {
                if (psystemRed != null)
                {
                    psystemRed.Play();
                }
            }
            else //disable particle effect
            {
                if (psystemRed != null)
                {
                    psystemRed.Stop();
                }
            }
            buffAoe = value;
        }
    }
    public float BuffSlow
    {
        get { return buffSlow; }
        set
        {
            if (value > 0) // start particle effect
            {
                if (psystemBlue != null)
                {
                    psystemBlue.Play();
                }
            }
            else //disable particle effect
            {
                if (psystemBlue != null)
                {
                    psystemBlue.Stop();
                }
            }
            buffSlow = value;
        }
    }
    public float BuffDot
    {
        get { return buffDot; }
        set
        {
            if (value > 0) // start particle effect
            {
                if (psystemGreen != null)
                {
                    psystemGreen.Play();
                }
            }
            else //disable particle effect
            {
                if (psystemGreen != null)
                {
                    psystemGreen.Stop();
                }
            }
            buffDot = value;
        }
    }

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
    public void InjectParticleSystemYellow(ParticleSystem psys)
    {
        this.psystemYellow = psys;
    }
    public void InjectParticleSystemRed(ParticleSystem psys)
    {
        this.psystemRed = psys;

    }
    public void InjectParticleSystemBlue(ParticleSystem psys)
    {
        this.psystemBlue = psys;
    }
    public void InjectParticleSystemGreen(ParticleSystem psys)
    {
        this.psystemGreen = psys;
    }
    public void InjectParticleSystemPurple(ParticleSystem psys)
    {
        this.psystemPurple = psys;
    }
}
