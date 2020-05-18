using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class Slow : MonoBehaviour, IActionBulletHit, IInjectDamageStats, IInjectBuffStats
{
    private IDamageStats damageData;
    private IBuffStats buffData;

    public void OnBulletHit()
    {
        SlowTarget();
    }

    // Start is called before the first frame update


    void SlowTarget(){
        float slowBuffValue = (damageData.Slow / 100) * (buffData.BuffSlow * 10);
        float slow = damageData.Slow + slowBuffValue;
        EnemyWalker enemyWalker = GetComponent<Bullet>().GetTarget().GetComponent<EnemyWalker>();
        if(enemyWalker != null)
        {
            enemyWalker.DecreaseSpeed(slow);
        }
    }

    public void AffectTargets(List<IDamageable> targets)
    {
        float slow = (damageData.Slow + buffData.BuffSlow);
        foreach(IDamageable t in targets)
        {
            if(t.GameObject.GetComponent<EnemyWalker>() != null)
            t.GameObject.GetComponent<EnemyWalker>().DecreaseSpeed(slow);
        }
    }

    public void AffectTarget(IDamageable target)
    {

        float slow = (damageData.Slow + buffData.BuffSlow);
        if (target.GameObject.GetComponent<EnemyWalker>() != null)
        target.GameObject.GetComponent<EnemyWalker>().DecreaseSpeed(slow);


    }

    public void InjectDamageStats(IDamageStats damageData)
    {
        this.damageData = damageData;
    }

    public void InjectBuffStats(IBuffStats buffData)
    {
        this.buffData = buffData;
    }
}
