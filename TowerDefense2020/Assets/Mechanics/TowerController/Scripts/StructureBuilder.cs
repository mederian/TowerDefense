using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureBuilder : MonoBehaviour, IDealWithResources
{
    [SerializeField] private LayerMask buildLayer;
    private string rayedObject;
    [SerializeField] private GameObject hitList;  //The list of enemies the towers will hit
    private GameObject currentConstruction;
    private bool isUnderConstruction;
    private _Resources resources;
    private int constructionCounter = 1;

    void Start()
    {
        InjectResources(GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources());
        
        currentConstruction = null;
        isUnderConstruction = false;
    }

    void Update()
    {
        if(isUnderConstruction)
        {
            //Something is under construction. object is attached to cursor until placement by a mouse click on valid position
            currentConstruction.transform.position = MousePosition();
            
            if(Input.GetMouseButtonDown(0))
            {
                if (currentConstruction.GetComponent<BuildStatus>().CanBuild())
                {
                    if (AttemptTransaction(currentConstruction.GetComponent<TowerCost>()))
                    {
                        PlaceTower();//Tower controller. add this tower
                        isUnderConstruction = false;
                    }       
                }

            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(currentConstruction);
                isUnderConstruction = false;
            }
        }
    }

    public bool AttemptTransaction(TowerCost cost)
    {
        if(cost.GoldCost > resources.mainResource.value)
        {
            return false;
        }
        if(cost.FireCost > resources.aoeResource.value)
        {
            return false;
        }
        if(cost.FrostCost > resources.slowResource.value)
        {
            return false;
        }
        if(cost.PoisonCost > resources.dotResource.value)
        {
            return false;
        }
        if(cost.ManaCost > resources.rangeResource.value)
        {
            return false;
        }

        resources.mainResource.value -= cost.GoldCost;
        resources.aoeResource.value -= cost.FireCost;
        resources.dotResource.value -= cost.PoisonCost;
        resources.slowResource.value -= cost.FrostCost;
        resources.rangeResource.value -= cost.ManaCost;



        return true;
    }

    //change to change structure
    public void PlaceTower()
    {
        //Tower controller. add this tower
        currentConstruction.name = currentConstruction.name + " - " + constructionCounter;
        currentConstruction.GetComponent<Tower>().towerData.Name = currentConstruction.name;
        constructionCounter++;
        //Debug.Log("placed tower");
        currentConstruction.GetComponent<Ranged>().SetHitList(this.hitList);
        //currentConstruction.GetComponent<Ranged>().HitList = this.hitList; //Gives the structure hitlist
        currentConstruction.GetComponent<ConstructionStatus>().StartConstruction();
    }

    //This function initiateing structure creation
    public void CreateStructure(GameObject structure)
    {
        Debug.Log("CREATE STRUCTURE");
        currentConstruction = Instantiate(structure, MousePosition(), Quaternion.identity);
        currentConstruction.GetComponent<Tower>().InjectResources(resources);
        isUnderConstruction = true;
    }


    public Vector3 MousePosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 m = new Vector3(0,0,0);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100.0f, buildLayer)){
                m = hitInfo.point;
                rayedObject = hitInfo.collider.gameObject.tag;
        }
        
        return new Vector3(m.x, 1.1f ,m.z);
    }

    public void InjectResources(_Resources resources)
    {
        this.resources = resources;
    }
}
