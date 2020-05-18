using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour, IInjectTowerData ,ICombat, IInjectDamageStats, IInjectBuffStats, IInjectLevelData, IInjectScoreData
{
	[SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletStart;
    [SerializeField] private GameObject hitList;
    [SerializeField] private bool paused;
    [SerializeField] private float fireCoolDownLeft;

	private Vector3 firePosition;
	private Transform nearestEnemy;
    private IDamageStats damageData;
    private IBuffStats buffData;
    private ILevel levelData;
    private IScore scoreData;
    private TowerData towerData;

    public GameObject HitList { get => hitList; set => hitList = value; }
	public void SetHitList(GameObject hitList)
	{
		//Debug.Log("Setting Hitlist: " + this.name);
		this.hitList = hitList;
	}


	//This function checks if gameobject has a child that is named bulletstart which it fires from. If it has not this object, it will fire from center of gameobject
	private Vector3 BulletFirePosition()
	{
		if(bulletStart != null){
			return bulletStart.transform.position;
		}
		else
		{
			return transform.position;
		}
	}

	// Update is called once per frame
	void Update()
	{	
		if(!paused)
		{
            if(GetComponent<ConstructionStatus>().BuildComplete)
            {
                if (nearestEnemy != null)
                {
                    AttemptAttack();
                }
                else
                {
                    FindNextTarget();
                }
            }
		}
	}

    private void AttemptAttack()
    {
        Vector3 dir = nearestEnemy.transform.position - this.transform.position;
        fireCoolDownLeft -= Time.deltaTime;

        if (fireCoolDownLeft <= 0)
        {
            float buffRangeValue = (damageData.Range / 100) * (buffData.BuffRange * 5);
            //if within range. 
            if (dir.magnitude <= (damageData.Range + buffRangeValue + levelData.Level * 2))
            {
                fireCoolDownLeft = damageData.FireCoolDown;
                Attack(nearestEnemy.GetComponent<IDamageable>());
            }
            //If not in range, then find the next one
            else
            {
                FindNextTarget();
            }
        }
    }

    //Function finds the nearest enemy(object that has component "health") within the hitList
    public void FindNextTarget()
	{
		if(HitList == null)
		{

			Debug.LogWarning("Tower has no applied targetlist, tower will not shoot"+ this.transform.name.ToString());
		}
		else
		{
			float dist = Mathf.Infinity;
            // Iterate hitlist...
            Transform[] childrensInList = HitList.GetComponentsInChildren<Transform>();
			foreach(Transform l in childrensInList)
            {
				if(l.gameObject.GetComponent<IDamageable>() != null)
				{
					float d = Vector3.Distance(this.transform.position, l.transform.position);
					if(nearestEnemy == null || d < dist){
						if(nearestEnemy != null) nearestEnemy.GetComponent<TargetHighlighter>().RemoveTargeted();
						nearestEnemy = l;
						nearestEnemy.GetComponent<TargetHighlighter>().SetTargeted();
						dist = d;
					}
				}
			}
		}
	}

	public Transform GetNearestEnemy(){

		return nearestEnemy;
	}

	public void Attack(IDamageable e){
		firePosition = BulletFirePosition();
		GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePosition, Quaternion.identity);
		Bullet b = bulletGo.GetComponent<Bullet>();
        b.InitBullet(towerData, e.GameObject.transform);
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

    public void InjectTowerData(TowerData towerData)
    {
        this.towerData = towerData;
    }
}
