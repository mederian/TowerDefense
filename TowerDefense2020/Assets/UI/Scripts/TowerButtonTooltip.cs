using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtonTooltip : MonoBehaviour, ITooltip
{
    private string tooltip; //Need the tower cost data to populate this variable
    private TowerCost towerCost;
    [SerializeField] GameObject towerObject;
    public string GetTooltip()
    {

        return tooltip;
    }



    // Start is called before the first frame update
    void Start()
    {
        if(towerObject.GetComponent<TowerCost>() != null)
        {
            towerCost = towerObject.GetComponent<TowerCost>();
            tooltip = "Build Tower";
            tooltip += "(" /*+ towerCost.GoldCost*/ + "G)";
            tooltip += "(" /*+ towerCost.FireCost*/ + "F)";
            tooltip += "(" /*+ towerCost.PoisonCost*/ + "P)";
            tooltip += "(" /*+ towerCost.FrostCost*/ + "fr)";
            tooltip += "(" /*+ towerCost.ManaCost*/ + "m)";
        }
        else
        {
            tooltip = "Build Tower";
        }
    }

    
    public int GoldCost()
    {
        return 0; //towerCost.GoldCost.Value;
    }
    public int FireCost()
    {
        return 0; // towerCost.FireCost.Value;
    }
    public int FrostCost()
    {
        return 0; //towerCost.FrostCost.Value;
    }
    public int PoisonCost()
    {
        return 0; //towerCost.PoisonCost.Value;
    }
    public int ManaCost()
    {
        return 0; //towerCost.ManaCost.Value;
    }


}
