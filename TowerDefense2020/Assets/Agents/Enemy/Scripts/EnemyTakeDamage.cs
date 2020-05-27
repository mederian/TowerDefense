using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour, IDamageable
{
    private IHealth enemyHealth;
    private IArmor enemyArmor;

    public GameObject GameObject => this.gameObject;

    void Start()
    {
        if(GetComponent<IArmor>() != null) enemyArmor = GetComponent<IArmor>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    public bool TakeDamage(float damage, IScore towerScore)
    {
        float initDamage = damage;
        float finalDamage = enemyArmor.DamageAfterArmor(damage);
        //Debug.Log("Take Damage");
        enemyHealth.LooseHP(finalDamage, initDamage, towerScore);
        if (finalDamage > -1)
        {
            return false;
        }
        else return true;
    }
    public void TakeDamageDOT(float damage, IScore towerScore)
    {
        Debug.Log("Take Damage");
        enemyHealth.LooseHpDOT(damage, towerScore);
    }
    //Do damage over time coro
    IEnumerator DoDamageOverTime(float damage, float duration, IScore towerScore)
    {
        int currentCount = 0;
        float damageAmount = damage / duration;
        int d = Mathf.RoundToInt(duration);
        while (currentCount < d)
        {
            TakeDamageDOT(damageAmount, towerScore);  //Take damage.towerData gets killcount and xp on death
            if (enemyHealth.CurrentHp <= 0)
            {
                yield break;                        //If hp less than 1, then stop coro
            }
            yield return new WaitForSeconds(0.1f);
            currentCount++;
        }
    }

    //function call to coro for damage over time. "damage" is the total damage to be dealt over the "duration", towerData is for reporting kill count and xp if enemy dies
    public void TakeDamageOverTime(float damage, float duration,IScore towerScore)
    {
        StartCoroutine(DoDamageOverTime(damage, duration, towerScore));
    }
}
