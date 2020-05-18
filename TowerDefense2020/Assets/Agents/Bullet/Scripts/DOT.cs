using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class DOT : MonoBehaviour, IActionBulletHit, IInjectDamageStats, IInjectBuffStats, IInjectScoreData
{
    private IDamageStats damageStats;
    private IDealDamage source;
    private IBuffStats buffData;
    private IScore scoreData;

    void Start()
    {
        source = this.GetComponent<IDealDamage>();
    }

    public void AffectTargets(List<IDamageable> targets)
    {
        float dotBuffValue = (damageStats.Dot / 100) * (buffData.BuffDot * 10);
        float dot = damageStats.Dot + dotBuffValue;
        GetComponent<Bullet>().GetTarget().GetComponent<IDamageable>().TakeDamageOverTime(dot, 500.0f, scoreData);
    }


    public void AffectTarget(IDamageable t)
    {
        float dot = damageStats.Dot + buffData.BuffDot;
        t.GameObject.GetComponent<IDamageable>().TakeDamageOverTime(dot, 500.0f, scoreData);
    }

    public void InjectDamageStats(IDamageStats damageData)
    {
        this.damageStats = damageData;
    }

    public void InjectBuffStats(IBuffStats buffData)
    {
        this.buffData = buffData;
    }

    public void InjectScoreData(IScore scoreData)
    {
        this.scoreData = scoreData;
    }
}
