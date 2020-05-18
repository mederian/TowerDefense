using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
This scripts makes the object hostile towards towers
bool onlyGround, check this if it only can attacks towers that are placed on the ground, not the ones on the platform
 */

 
public class TowerHostile : MonoBehaviour
{

//Check this if it only attack grounded towers
    [SerializeField]
    private bool onlyground;


//Reference to tower controller, to gain access to list of towers
    [SerializeField]
    private GameObject towerController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if any towers are grounded: start 

        //dir = get nearest tower
    }


    public GameObject GetNearestTower(){

        if(towerController == null)
        {

            Debug.LogWarning("TowerHostile Script, did not have reference to towers, enemy will not attack towers");
            return null;
        }
        else
        {
            /* 
            GameObject[] towers = bm.TowerList().ToArray();
            GameObject nearestTower = null;
            float dist = Mathf.Infinity;
            foreach(GameObject e in towers){
                float d = Vector3.Distance(this.transform.position, e.transform.position);
                if(nearestTower == null || d < dist){
                    if(e.GetComponent<Tower>().isGrounded){
                        nearestTower = e;
                        dist = d;
                    }
                }
            }
            if(nearestTower == null){
                Debug.Log("No towers?");
                return null;
            }
            return nearestTower;
        */
        }
        return null;
	}
}
