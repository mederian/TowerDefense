using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtonTooltip : MonoBehaviour, ITooltip
{
    private string tooltip; //Need the tower cost data to populate this variable
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
            TowerCost towerCost = towerObject.GetComponent<TowerCost>();
            tooltip = "Build Tower";
            tooltip += "(" + towerCost.GoldCost + "G)";
            tooltip += "(" + towerCost.FireCost + "F)";
            tooltip += "(" + towerCost.PoisonCost + "P)";
            tooltip += "(" + towerCost.FrostCost + "fr)";
            tooltip += "(" + towerCost.ManaCost + "m)";
        }
        else
        {
            tooltip = "Build Tower";
        }
    }
}
