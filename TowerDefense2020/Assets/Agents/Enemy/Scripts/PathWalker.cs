using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyWalker))]
public class PathWalker : MonoBehaviour {

    private EnemyWalker enemyWalker;
	
	Transform targetPathNode;
	int pathNodeIndex = 0;
    bool pathWalkerActive;
    GameObject pathGO;
    [SerializeField] bool randomPath = false;
    bool otherPath;
    string xnode = "XSphere";

	void Start () {
        if (randomPath)
        {
            float r = Random.Range(0,100);
            if (r < 50)
            {
                otherPath = true;
            }
            else otherPath = false;
        }
		pathGO = GameObject.Find("Path");
        enemyWalker = GetComponent<EnemyWalker>();
        pathWalkerActive = true;
	}

    void FixedUpdate()
    {
        if (pathWalkerActive)
        {
            FindNextPathNode();
            MoveTowardsNextNode();
        }

    }

    void FindNextPathNode()
    {
   
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {//We run out of path!
                ReachedGoal();
                return;
            }
        }

    }
    void MoveTowardsNextNode()
    {
		if(targetPathNode == null)
		{
			return;
		}

        if (enemyWalker.MoveTowards(targetPathNode.position))
        {
            //Moving
        }
        else
        {
            targetPathNode = null;
        }
    }

    public int PathNodeIndex(){
		return this.pathNodeIndex - 1;
	}
	public void PathNodeIndex(int i){
		this.pathNodeIndex = i;

	}
	public string NextPathNode(){

		if(targetPathNode == null){
			Debug.Log("There was no pathnode here...");
			return "NO PATHNODE";
		}
		else{
			return targetPathNode.name.ToString();
		}
	}
	public void SetPathNode(string pathnode){
		targetPathNode = GameObject.Find(pathnode).transform;
	}

	//This sets targetPathnode, the next position the enemy should go to.. 
	void GetNextPathNode(){
		if(pathNodeIndex < pathGO.transform.childCount){
			targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            if(targetPathNode.name == xnode && otherPath)
            {
                pathGO = GameObject.Find("Path2");
                pathNodeIndex = 0;
            }
			pathNodeIndex++;
		}
		else{
			targetPathNode = null;
			//ReachedGoal();
		}
	}
		
	void ReachedGoal(){
		//tell enemycontroller that this enemy reached its goal. enemyController.ReportSuccess();
		Debug.Log("REached goal");
        //Destroy(gameObject);
        //The enemy now deals damage to playerbase.
        pathWalkerActive = false;

        AttackPlayerBase b = GetComponent<AttackPlayerBase>();
        if(b != null) 
        {
            GetComponent<AttackPlayerBase>().StartAttack();
        }
        else
        {
            // if not attacking base, maybe some other function?
        }
        
	}



}
