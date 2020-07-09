using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrainedResources : MonoBehaviour//, IDealWithEssences
{

    private _Essences essences;
    private TextMeshProUGUI text;
    //private List<Resource> resourcesDrained;
    private string result;
    bool resourceExist = false;
    private List<ResourceScriptableObject> resourcesDrained;



    void Start()
    {
        resourcesDrained = new List<ResourceScriptableObject>();
        text = this.GetComponent<TextMeshProUGUI>();
    }
    /*
    public List<Resource> GetResources()
    {
        return resourcesDrained;
    }
    public void AddResource(Resource res)
    {
        resourceExist = false;
        foreach (Resource resDrained in resourcesDrained)
        {
            if (resDrained.name == res.name)
            {
                if(res.value > 0)
                {
                    resDrained.value++;
                    res.value--;
                }

                resourceExist = true;
                UpdateText();
            }
        }
        if (!resourceExist)
        {
            if(res.value > 0)
            {
                Resource newRes = new Resource(res.name, 1);
                res.value--;
                resourcesDrained.Add(newRes);
            }
            UpdateText();
        }
        UpdateText();
    }
    public void ReturnResources()
    {
        foreach(Resource res in resourcesDrained)
        {
            if(res.name == essences.mainEssence.name)
            {
                essences.mainEssence.value += res.value;
            }
            if (res.name == essences.aoeEssence.name)
            {
                essences.aoeEssence.value += res.value;
            }
            if (res.name == essences.slowEssence.name)
            {
                essences.slowEssence.value += res.value;
            }
            if (res.name == essences.dotEssence.name)
            {
                essences.dotEssence.value += res.value;
            }
            if (res.name == essences.rangeEssence.name)
            {
                essences.rangeEssence.value += res.value;
            }
        }
        resourcesDrained.Clear();
        UpdateText();
    }

    public void UpdateText()
    {
        result = "";
        foreach(Resource r in resourcesDrained)
        {
            if(r.value > 0)
            {
                result += r.name + ": " + r.value + "\n";
            }
            
        }
        text.text = result;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ReturnResources();
        }
    }

    public void InjectEssences(_Essences essences)
    {
        this.essences = essences;
    }
    */
}
