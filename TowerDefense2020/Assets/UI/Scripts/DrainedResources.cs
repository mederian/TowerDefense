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
    private bool isEmpty;
    [SerializeField] private List<ResourceScriptableObject> resourcesDrained;
    [SerializeField] private List<ResourceScriptableObject> essences;

    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }

    void Start()
    {
        //resourcesDrained = new List<ResourceScriptableObject>();
        text = this.GetComponent<TextMeshProUGUI>();
        foreach(ResourceScriptableObject resDrained in resourcesDrained)
        {
            resDrained.Value = 0;
        }
       
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
            if (resDrained.resId.name == res.resId.name)
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
        IsEmpty = true;
        result = "";
        string colortext = "white";
        foreach (ResourceScriptableObject r in resourcesDrained)
        {
            if (r.Value > 0)
            {
                IsEmpty = false;
                if (r.resId.name == "Gold") colortext = "yellow";
                else if (r.resId.name == "Fire") colortext = "red";
                else if (r.resId.name == "Frost") colortext = "blue";
                else if (r.resId.name == "Poison") colortext = "green";
                else if (r.resId.name == "Mana") colortext = "purple";
                else colortext = "white";
                result += "<color=" + colortext + ">" + r.Value + "</color> ";
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
                if (res.resId.name == ess.resId.name)
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
