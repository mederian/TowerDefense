using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour, IDealWithEnemyController
{

    public UnityEvent deathEvent;
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        if(deathEvent == null)
        {
            deathEvent = new UnityEvent();
        }
        deathEvent.AddListener(Ping);
    }

    public void Die(IScore sourceScore)
    {
        GetComponent<Reward>().InitDrop();
        if(sourceScore != null)
        {
            sourceScore.Kills += 1;
            sourceScore.Xp += GetComponent<Reward>().CollectXp();
        }
        enemyController.GetComponent<EnemyController>().UnRegisterEnemy(this.gameObject);
        deathEvent.Invoke();
        Destroy(gameObject);
    }
    void Ping()
    {

    }

    public void InjectEnemyController(EnemyController enemyController)
    {

        this.enemyController = enemyController;
    }
}
