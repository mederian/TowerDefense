using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//This is attached to an gameobject/ui obj that can have its values drained
public class ButtonDrainResource : MonoBehaviour, IDealWithEssences
{
    private _Essences essences;     //Injected player essence pool
    //private _Essences currentEssences; //currently drained essences

    public DrainedResources drainedResources; //User interface
    private Resource actingResource;
    private float drainTime = 10f;
    private float currentDrainTime = 0;
    private string buttonName;
    private int buttonEssenceValue;
    private int drainRes;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 buttonPosition = this.transform.position;
        Vector3 realSpacePosition = Camera.main.ScreenToWorldPoint(new Vector3(buttonPosition.x, buttonPosition.y, Camera.main.nearClipPlane));
        this.actingResource = this.DefineEssence(this.name);   
    }

    public void Drain()
    {
        drainedResources.AddResource(actingResource);
    }

    Resource DefineEssence(string essenceName)
    {
        if(essenceName == "GoldButton")
        {
            return essences.mainEssence;
        }
        else if(essenceName == "FireOrbButton")
        {
            return essences.aoeEssence;
        }
        else if (essenceName == "PoisonVialButton")
        {
            return essences.dotEssence;
        }
        else if (essenceName == "FrostShardButton")
        {
            return essences.slowEssence;
        }
        else if (essenceName == "ManaCrystalButton")
        {
            return essences.rangeEssence;
        }
        return null;
    }

    public void InjectEssences(_Essences essences)
    {
        this.essences = essences;
    }
}
