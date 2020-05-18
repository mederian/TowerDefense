using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour, IDamageable
{
    public GameObject GameObject => throw new System.NotImplementedException();

    public bool TakeDamage(float damageTaken, IScore enemyScore)
    {
        GetComponent<IHealth>().LooseHP(damageTaken, damageTaken, enemyScore);
        if(this.gameObject.GetComponent<Spikes>() != null)
        {
            float spikeDamage = this.gameObject.GetComponent<Spikes>().DetermineSpikeDamage(damageTaken);
            //enemyScore.GameObject.GetComponent
            enemyScore.GameObject.GetComponent<IDamageable>().TakeDamage(spikeDamage, null);
        }
        return true;
    }

    public void TakeDamageOverTime(float damage, float duration, IScore enemyScore)
    {
        //throw new System.NotImplementedException();
    }
}
