using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spikes))]
public class UpgradePlayerSpike : MonoBehaviour, IPriced, IDealWithResources
{
    private Spikes spikes;
    [SerializeField] private float upgradeSpikeModifier = 2.5f;
    [SerializeField] private float maximumValue = 100f;

    [SerializeField] private int goldCost = 5;
    [SerializeField] private int manaCost = 5;
    [SerializeField] private int frostCost = 5;
    [SerializeField] private int poisonCost = 5;
    [SerializeField] private int fireCost = 5;
    private _Resources resources;

    public int GoldCost { get => goldCost; set => goldCost = value; }
    public int ManaCost { get => manaCost; set => manaCost = value; }
    public int FrostCost { get => frostCost; set => frostCost = value; }
    public int PoisonCost { get => poisonCost; set => poisonCost = value; }
    public int FireCost { get => fireCost; set => fireCost = value; }
    // Start is called before the first frame update
    void Start()
    {
        spikes = this.GetComponent<Spikes>();
    }


    public void UpgradeSpikeDamage()
    {
        if (isAffordable())
        {
            if (spikes.SpikeDamageModifier + upgradeSpikeModifier <= maximumValue)
            {
                spikes.SpikeDamageModifier += upgradeSpikeModifier;
                SubtractCost();
            }
            else
            {
                spikes.SpikeDamageModifier = maximumValue;
            }
        }

    }

    public bool isAffordable()
    {
        if (resources == null)
        {
            resources = GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources();
        }
        if (resources.mainResource.value >= goldCost && resources.aoeResource.value >= fireCost &&
                resources.slowResource.value >= frostCost && resources.dotResource.value >= poisonCost &&
                resources.rangeResource.value >= manaCost)
        {
            return true;
        }
        return false;
    }

    public void SubtractCost()
    {
        if (resources == null)
        {
            resources = GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources();
        }
        resources.mainResource.value -= goldCost;
        resources.aoeResource.value -= fireCost;
        resources.slowResource.value -= frostCost;
        resources.dotResource.value -= poisonCost;
        resources.rangeResource.value -= manaCost;
    }

    public void InjectResources(_Resources resources)
    {
        this.resources = resources;
    }
}
