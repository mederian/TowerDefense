using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour, IInjectScoreData ,IActionBulletHit, IDealDamage, IInjectDamageStats, IInjectBuffStats, IInjectLevelData
{
    private IScore towerData;
    private IDamageStats towerDamageStats;
    private IBuffStats buffData;
    private IDamageStats damageData;
    private ILevel levelData;
    private IScore scoreData;

    public GameObject GameObject => gameObject;

    public void AffectTargets(List<IDamageable> targets)
    {
        //Buffdamage = 5: Bonus = 50% of original damage
        float buffDamageBonus = (damageData.Damage / 100) * (buffData.BuffDamage * 10);

        float damage = damageData.Damage + buffDamageBonus + levelData.Level*2;
        foreach(IDamageable t in targets)
        {
            bool hitStatus = t.TakeDamage(damage, scoreData);

            if (hitStatus == true)
            {
                GetComponent<Slow>().AffectTarget(t);
                GetComponent<DOT>().AffectTarget(t);
            }
        }
    }

    public void OnBulletHit()
    {
        throw new System.NotImplementedException();
    }

    public void DealDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void InjectDamageStats(IDamageStats damageData)
    {
        this.damageData = damageData;
    }

    public void InjectBuffStats(IBuffStats buffData)
    {
        this.buffData = buffData;
    }

    public void InjectLevelData(ILevel levelData)
    {
        this.levelData = levelData;
    }

    public void InjectScoreData(IScore scoreData)
    {
        this.scoreData = scoreData;
    }
}
