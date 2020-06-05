using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IAgent {
	public float speed = 15f;
	private Transform target;
	private GameObject owner; 
    public IScore scoreData;
    [SerializeField] GameObject meshObject;

    public GameObject GameObject { get { return this.gameObject; } }

    public GameObject MeshObject { get => meshObject; set => meshObject = value; }

    public void FixedUpdate()
    {
        //TODO: When enemy dies, bullets in the air, not yet reached enemy just dissepear. Maybe vanish effect could be used.
        if (target == null)
        {
            //our enemy is dead
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - this.transform.localPosition;
        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // We reached the object
            DoBulletHit();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            this.transform.rotation = Quaternion.LookRotation(dir);

        }
    }

	public Transform GetTarget(){

		return this.target;
	}
	public void SetTarget(Transform g){
		this.target = g;

	}
	void DoBulletHit(){

        List<IDamageable> affected = GetComponent<AOE>().AoeHitList();
        if(affected == null || affected.Count == 0)
        {
            Debug.Log("AOE IS NULL OR EMPTY");
        }
        if(affected.Count > 0)
        {
            GetComponent<BulletDamage>().AffectTargets(affected);
        }

        //TODO Spawn explosion
        Destroy(gameObject);
	}
    public void InjectScoreData(IScore scoreData)
    {
        this.scoreData = scoreData;

        IInjectScoreData[] injectables = GetComponents<IInjectScoreData>();
        foreach (IInjectScoreData i in injectables)
        {
            i.InjectScoreData(scoreData);
        }
    }

    public void InjectDamageData(IDamageStats damageData)
    {
        IInjectDamageStats[] injectables = GetComponents<IInjectDamageStats>();
        foreach (IInjectDamageStats i in injectables)
        {
            i.InjectDamageStats(damageData);
        }
    }
    public void InjectBuffData(IBuffStats buffData)
    {
        IInjectBuffStats[] injectables = GetComponents<IInjectBuffStats>();
        foreach (IInjectBuffStats i in injectables)
        {
            i.InjectBuffStats(buffData);
        }
    }
    private void InjectLevelData(ILevel levelData)
    {
        IInjectLevelData[] injectables = GetComponents<IInjectLevelData>();
        foreach (IInjectLevelData i in injectables)
        {
            i.InjectLevelData(levelData);
        }
    }


    internal void InitBullet(TowerData towerData, Transform transform)
    {
        this.InjectScoreData(towerData);
        this.InjectDamageData(towerData);
        this.InjectBuffData(towerData);
        this.InjectLevelData(towerData);
        this.SetTarget(transform);
    }


}
