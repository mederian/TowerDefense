using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTooltip : MonoBehaviour, ITooltip
{ 
    [SerializeField] private GameObject fortress;
    private List<ResourceScriptableObject> resourceCostSO;
    private UpgradePlayerArmor playerArmor;
    private UpgradePlayerHealth playerHealth;
    private UpgradePlayerSpike playerSpike;
    enum PropertyType
    {
        Heal,
        Armor,
        Spikes
    }
    [SerializeField] PropertyType updateType = PropertyType.Heal;


    // Start is called before the first frame update
    void Start()
    {
        
        if(fortress.GetComponent<UpgradePlayerArmor>() != null)
            playerArmor = fortress.GetComponent<UpgradePlayerArmor>();

        if (fortress.GetComponent<UpgradePlayerHealth>() != null)
            playerHealth = fortress.GetComponent<UpgradePlayerHealth>();

        if (fortress.GetComponent<UpgradePlayerSpike>() != null)
            playerSpike = fortress.GetComponent<UpgradePlayerSpike>();
    }

    public List<ResourceScriptableObject> GetCostList()
    {
        return null;
    }
    public int GoldCost()
    {
        if (updateType == PropertyType.Heal)
        { 
            return playerHealth.GoldCost();
        }
        else if (updateType == PropertyType.Armor)
        {
            return playerArmor.GoldCost;
        }
        else if (updateType == PropertyType.Spikes)
        {
            return playerSpike.GoldCost;
        }
        else
        {
            return 0;
        }
    }

    public int FireCost()
    {
        if (updateType == PropertyType.Heal)
        {
            return playerHealth.FireCost();
        }
        else if (updateType == PropertyType.Armor)
        {
            return playerArmor.FireCost;
        }
        else if (updateType == PropertyType.Spikes)
        {
            return playerSpike.FireCost;
        }
        else
        {
            return 0;
        }
    }

    public int FrostCost()
    {
        if (updateType == PropertyType.Heal)
        {
            return playerHealth.FrostCost();
        }
        else if (updateType == PropertyType.Armor)
        {
            return playerArmor.FrostCost;
        }
        else if (updateType == PropertyType.Spikes)
        {
            return playerSpike.FrostCost;
        }
        else
        {
            return 0;
        }
    }

    public int PoisonCost()
    {
        if (updateType == PropertyType.Heal)
        {
            return playerHealth.PoisonCost();
        }
        else if (updateType == PropertyType.Armor)
        {
            return playerArmor.PoisonCost;
        }
        else if (updateType == PropertyType.Spikes)
        {
            return playerSpike.PoisonCost;
        }
        else
        {
            return 0;
        }
    }

    public int ManaCost()
    {
        if (updateType == PropertyType.Heal)
        {
            return playerHealth.ManaCost();
        }
        else if (updateType == PropertyType.Armor)
        {
            return playerArmor.ManaCost;
        }
        else if (updateType == PropertyType.Spikes)
        {
            return playerSpike.ManaCost;
        }
        else
        {
            return 0;
        }
    }
}
