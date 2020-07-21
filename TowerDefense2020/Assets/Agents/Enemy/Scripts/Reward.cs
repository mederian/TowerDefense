using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour, IDealWithResources
{
    [SerializeField] private List<ResourceScriptableObject> rewards;
    
    [SerializeField] private int xpValue = 0;

    private _Resources resources;
    public void InitDrop()
    {
        if(rewards != null)
        {
            foreach (ResourceScriptableObject reward in rewards)
            {
                foreach(ResourceScriptableObject res in resources.Resources)
                {
                    if(reward.resId.name == res.resId.name)
                    {
                        res.Value += reward.Value;
                    }
                }
            }
        }
    }

    public int CollectXp()
    {
        float modifier = 1;
        float m;
        float f = 1;
        float divisor = 1.25f;
        float flyerModifer;
        if(this.GetComponent<Flyer>() != null) flyerModifer = 1.25f;
        else flyerModifer = 1f;
        if (modifier <= 0) m = 1;
        else m = modifier;
        float r = (GetComponent<IHealth>().StartHp * m * f * flyerModifer) / divisor;
        //Debug.Log("Collect xp: " + ((int)r).ToString());
        return (int)r;
    }
/*
    public void InjectScoreData(List<Resource> resourceData)
    {
        this.resourceData = resourceData;
    }
    */
    public void Start()
    {
        this.InjectResources(GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources());
    }
 
    public void InjectResources(_Resources resources)
    {
        this.resources = resources;
    }

}
