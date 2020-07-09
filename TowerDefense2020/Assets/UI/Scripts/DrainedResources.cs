using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrainedResources : MonoBehaviour//, IDealWithEssences
{


    private TextMeshProUGUI text;
    //private List<Resource> resourcesDrained;
    private string result;
    bool resourceExist = false;
    [SerializeField] private List<ResourceScriptableObject> resourcesDrained;
    [SerializeField] private List<ResourceScriptableObject> essences;


    void Start()
    {
        resourcesDrained = new List<ResourceScriptableObject>();
        text = this.GetComponent<TextMeshProUGUI>();
    }

    public List<ResourceScriptableObject> GetResources()
    {
        return resourcesDrained;
    }

    public void AddResource(ResourceScriptableObject res)
    {
        resourceExist = false;
        foreach (ResourceScriptableObject resDrained in resourcesDrained)
        {
            if (resDrained.ResourceName == res.ResourceName)
            {
                if (res.Value > 0)
                {
                    resDrained.Value++;
                    res.Value--;
                }
            }
        }
        UpdateText();
    }
    public void UpdateText()
    {
        result = "";
        foreach (ResourceScriptableObject r in resourcesDrained)
        {
            if (r.Value > 0)
            {
                result += r.name + ": " + r.Value + "\n";
            }
        }
        text.text = result;
    }

    public void ReturnResources()
    {
        foreach (ResourceScriptableObject res in resourcesDrained)
        {
            foreach (ResourceScriptableObject ess in essences)
            {
                if (res.name == ess.name)
                {
                    ess.Value += res.Value;
                    res.Value = 0;
                }
            }
        }
        UpdateText();
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ReturnResources();
        }
    }

}
