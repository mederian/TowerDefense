using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour, IInjectDamageStats
{
    private IDamageStats damageData;

    public void InjectDamageStats(IDamageStats damageData)
    {
        this.damageData = damageData;
    }

    public void UpgradeDamage()
    {
        Debug.Log("UPGRADE DAMAGE");
        damageData.Damage += 1;
    }
}
