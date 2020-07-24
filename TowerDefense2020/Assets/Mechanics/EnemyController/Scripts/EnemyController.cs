using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{

    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int mainResourcePool = 0;
    [SerializeField] private int slowResourcePool = 0;
    [SerializeField] private int aoeResourcePool = 0;
    [SerializeField] private int dotResourcePool = 0;
    [SerializeField] private int rangeResourcePool = 0;
    [SerializeField] private int xpPool = 0;

	public delegate void KillAction();
	public static event KillAction OnKill;
    //private List<Resource> resourceData;

//Created enemies register at enemycontroller here
    public void RegisterEnemy(GameObject go)
    {
        //Couple this e
        foreach(IDealWithEnemyController ec in go.GetComponents<IDealWithEnemyController>())
        {
            ec.InjectEnemyController(this.GetComponent<EnemyController>());
        }
        enemyCount++;
      //  go.GetComponent<Reward>().InjectScoreData(resourceData);
    }

    public void Start()
    {

    }
    /*
    public void InjectResourceData(List<Resource> resourceData)
    {
        this.resourceData = resourceData;
    }
    */

    //Here should enemies that dies or get out of game call to
    public void UnRegisterEnemy(GameObject enemy)
    {
        enemyCount--;
        if(enemy.GetComponent<Reward>() != null)
        {
        }

        if(OnKill != null){
            OnKill();
        }
    }

//Enemy alerts the controller that it has completed its mission
    public void ReportSuccess()
    {

    }
    //TODO: Create events here that other classes can register to
    // Events be, when enemies dies, and when they get destroyed. And also perhaps when enemies drops

    public float[] GetScores()
    {
        float[] scores = { mainResourcePool, slowResourcePool, aoeResourcePool, dotResourcePool, rangeResourcePool, xpPool};
        return scores;
    }



}
