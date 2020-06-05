using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class AOE : MonoBehaviour, IActionBulletHit, IInjectBuffStats, IInjectDamageStats
{
    private List<IDamageable> aoeHitList = new List<IDamageable>();
    private IBuffStats buffData;
    private IDamageStats damageData;
    [SerializeField] GameObject model;

    private List<IDamageable> AOEHit(){
        List<IDamageable> affected = new List<IDamageable>();
        float buffRadiusValue = (damageData.Aoe / 100) * (buffData.BuffAoe * 10);
        float radius = damageData.Aoe + buffRadiusValue;


        if (radius == 0)
        {
            affected.Add(GetComponent<Bullet>().GetTarget().GetComponent<IDamageable>());
        }
        else if (radius > 0)
        {
            Collider[] cols = Physics.OverlapSphere(model.transform.position, radius);
            foreach (Collider c in cols)
            {
                if (c.GetComponentInParent<IDamageable>() != null)
                {
                    
                    affected.Add(c.GetComponentInParent<IDamageable>());
                }
            }
        }
        return affected;
    }

    public List<IDamageable> AoeHitList()
    {
        return AOEHit();
    }

    public void OnBulletHit()
    {
        throw new System.NotImplementedException();
    }

    public void AffectTargets(List<IDamageable> targets)
    {
        
    }

    public void InjectBuffStats(IBuffStats buffData)
    {
        this.buffData = buffData;
    }

    public void InjectDamageStats(IDamageStats damageData)
    {
        this.damageData = damageData;
    }
}
