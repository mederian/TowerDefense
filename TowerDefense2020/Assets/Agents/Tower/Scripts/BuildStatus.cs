using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStatus : MonoBehaviour
{

    private bool buildStatus = true;

    public void SetNoBuild()
    {
        GetComponent<TowerSkin>().ChangeToNoBuildMaterial();
        buildStatus = false;
    }
    public void SetOkBuild()
    {
        GetComponent<TowerSkin>().ChangeToNormalMaterial();
        buildStatus = true;
    }

    public bool CanBuild()
    {
        return buildStatus;
    }


    void OnTriggerEnter(Collider other)
    {

        if (LayerMask.LayerToName(other.gameObject.layer) == "GroundLayer")
        {

        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Nature" || LayerMask.LayerToName(other.gameObject.layer) == "BuildLayer")
        {

            SetNoBuild();
        }
        
    }
    void OnTriggerExit(Collider other)
    {
 
        if (LayerMask.LayerToName(other.gameObject.layer) == "GroundLayer")
        {

        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Nature" || LayerMask.LayerToName(other.gameObject.layer) == "BuildLayer")
        {

            SetOkBuild();
        }
    }

}
