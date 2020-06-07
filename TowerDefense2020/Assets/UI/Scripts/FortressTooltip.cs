using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTooltip : MonoBehaviour, ITooltip
{

    private string tooltip = "";
    [SerializeField] private GameObject fortress;
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

    public string GetTooltip()
    {
        if(updateType == PropertyType.Heal)
        {
            tooltip = "Upgrade HP";
            tooltip += "(" + playerHealth.GoldCost + "G)";
            tooltip += "(" + playerHealth.FireCost + "F)";
            tooltip += "(" + playerHealth.PoisonCost + "P)";
            tooltip += "(" + playerHealth.FrostCost + "fr)";
            tooltip += "(" + playerHealth.ManaCost + "m)";
        }
        else if(updateType == PropertyType.Armor)
        {
            tooltip = "Upgrade Damage";
            tooltip += "(" + playerArmor.GoldCost + "G)";
            tooltip += "(" + playerArmor.FireCost + "F)";
            tooltip += "(" + playerArmor.PoisonCost + "P)";
            tooltip += "(" + playerArmor.FrostCost + "fr)";
            tooltip += "(" + playerArmor.ManaCost + "m)";
        }
        else if(updateType == PropertyType.Spikes)
        {
            tooltip = "Upgrade Spike";
            tooltip += "(" + playerSpike.GoldCost + "G)";
            tooltip += "(" + playerSpike.FireCost + "F)";
            tooltip += "(" + playerSpike.PoisonCost + "P)";
            tooltip += "(" + playerSpike.FrostCost + "fr)";
            tooltip += "(" + playerSpike.ManaCost + "m)";
        }
        return tooltip;
    }

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

    public int GoldCost()
    {
        throw new System.NotImplementedException();
    }

    public int FireCost()
    {
        throw new System.NotImplementedException();
    }

    public int FrostCost()
    {
        throw new System.NotImplementedException();
    }

    public int PoisonCost()
    {
        throw new System.NotImplementedException();
    }

    public int ManaCost()
    {
        throw new System.NotImplementedException();
    }
}
