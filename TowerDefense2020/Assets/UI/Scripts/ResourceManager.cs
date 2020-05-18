using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private _Resources resources;
    [SerializeField] private _Essences essences;
    [SerializeField] private string sepparator = ": ";
    [SerializeField] private int maxResource = 100;
    [SerializeField] private int maxEssence = 100;

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

    public _Resources GetResources()
    {
        return this.resources;
    }

    public void UpdateMainResourceText(TextMeshProUGUI mainResourceText)
    {
        mainResourceText.text = resources.mainResource.name + sepparator + resources.mainResource.value.ToString() + "(" + essences.mainEssence.value.ToString() +")";
    }
    public void UpdateAoeResourceText(TextMeshProUGUI aoeResourceText)
    {
        aoeResourceText.text = resources.aoeResource.name + sepparator + resources.aoeResource.value.ToString() + "(" + essences.aoeEssence.value.ToString() + ")";
    }
    public void UpdateSlowResourceText(TextMeshProUGUI slowResourceText)
    {
        slowResourceText.text = resources.slowResource.name + sepparator + resources.slowResource.value.ToString() + "(" + essences.slowEssence.value.ToString() + ")";
    }
    public void UpdateDotResourceText(TextMeshProUGUI dotResourceText)
    {
        dotResourceText.text = resources.dotResource.name + sepparator + resources.dotResource.value.ToString() + "(" + essences.dotEssence.value.ToString() + ")";
    }
    public void UpdateRangeResourceText(TextMeshProUGUI rangeResourceText)
    {
        rangeResourceText.text = resources.rangeResource.name + sepparator + resources.rangeResource.value.ToString() + "(" + essences.rangeEssence.value.ToString() + ")";
    }
}



[System.Serializable]
public class Resource
{
    public Resource(string name, int value)
    {
        this.name = name;
        this.value = value;
    }
    public Resource()
    {

    }
    [SerializeField] public string name;
    [SerializeField] public int value;

}

[System.Serializable]
public class _Resources
{
    [SerializeField] public Resource mainResource;

    [SerializeField] public Resource aoeResource;

    [SerializeField] public Resource dotResource;

    [SerializeField] public Resource slowResource;

    [SerializeField] public Resource rangeResource;
}

[System.Serializable]
public class _Essences
{
    public Resource mainEssence;
    public Resource aoeEssence;
    public Resource dotEssence;
    public Resource slowEssence;
    public Resource rangeEssence;
}