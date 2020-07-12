using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private _Resources resources;
    [SerializeField] private _Essences essences;
    [SerializeField] private string sepparator = ": ";
    [SerializeField] private int maxResource = 100;
    [SerializeField] private int maxEssence = 100;

    private List<int> resChecker;
    private int prevMainRes;

    public int MaxResource { get => maxResource; set => maxResource = value; }
    public int MaxEssence { get => maxEssence; set => maxEssence = value; }

    public void Awake()
    {
        
       foreach(IDealWithResources res in this.GetComponents<IDealWithResources>())
        {
            res.InjectResources(this.resources);
        }
        foreach (IDealWithEssences res in this.GetComponents<IDealWithEssences>())
        {
            res.InjectEssences(this.essences);
        }

        foreach (IDealWithEssences res in this.GetComponentsInChildren<IDealWithEssences>())
        {
            res.InjectEssences(this.essences);
        }
        
    }

    public bool ValuesChanged()
    {
        if(resChecker.Count <= 0)
        {
            return false;
        }


        return false;
    }

    public int GoldChange()
    {
        /*
        if(resources.mainResource.value < prevMainRes)
        {
            Debug.Log("minus one");
            prevMainRes = resources.mainResource.value;
            return -1;
        }
        if(resources.mainResource.value > prevMainRes)
        {
            prevMainRes = resources.mainResource.value;
            Debug.Log("one");
            return 1;
        }
        */
        return 0;
    }

    public bool isIncrGold()
    {
        /*
        if (resources.mainResource.value > prevMainRes)
        {
            prevMainRes = resources.mainResource.value;
            Debug.Log("one");
            return true;
        }
        */
        return false;
    }
    public bool isDecrGold()
    {
        /*
        if (resources.mainResource.value < prevMainRes)
        {
            Debug.Log("minus one");
            prevMainRes = resources.mainResource.value;
            return true;
        }
        */
        return false;
    }

    public _Resources GetResources()
    {
        return this.resources;
    }

    public void UpdateMainResourceText(TextMeshProUGUI mainResourceText)
    {
        //mainResourceText.text = resources.mainResource.value.ToString() + "(" + essences.mainEssence.value.ToString() +")";
    }
    public void UpdateAoeResourceText(TextMeshProUGUI aoeResourceText)
    {
        //aoeResourceText.text =resources.aoeResource.value.ToString() + "(" + essences.aoeEssence.value.ToString() + ")";
    }
    public void UpdateSlowResourceText(TextMeshProUGUI slowResourceText)
    {
        //slowResourceText.text = resources.slowResource.value.ToString() + "(" + essences.slowEssence.value.ToString() + ")";
    }
    public void UpdateDotResourceText(TextMeshProUGUI dotResourceText)
    {
        //dotResourceText.text = resources.dotResource.value.ToString() + "(" + essences.dotEssence.value.ToString() + ")";
    }
    public void UpdateRangeResourceText(TextMeshProUGUI rangeResourceText)
    {
        //rangeResourceText.text = resources.rangeResource.value.ToString() + "(" + essences.rangeEssence.value.ToString() + ")";
    }
}





[System.Serializable]
public class _Resources
{
    [SerializeField] public List<ResourceScriptableObject> Resources;
}

[System.Serializable]
public class _Essences
{
    [SerializeField] public List<ResourceScriptableObject> Essences;
}