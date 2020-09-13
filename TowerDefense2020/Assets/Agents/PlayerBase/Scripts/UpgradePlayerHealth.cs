using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHeatlh))]
public class UpgradePlayerHealth : MonoBehaviour, IUpgradePlayer
{
    private float upgradeValue = 1;
    private PlayerHeatlh playerHealth;
    [SerializeField] List<ResourceScriptableObject> cost;
    private TransactionHandler transactions;


    public List<ResourceScriptableObject> Cost()
    {
        return this.cost;
    }
    public int GoldCost()
    {
        foreach (ResourceScriptableObject r in cost)
        {
            if (r.resId.name == "Gold")
            {
                return r.Value;
            }
        }
        return 0;
    }
    public int ManaCost()
    {
        foreach (ResourceScriptableObject r in cost)
        {
            if (r.resId.name == "Mana")
            {
                return r.Value;
            }
        }
        return 0;
    }
    public int FrostCost()
    {
        foreach (ResourceScriptableObject r in cost)
        {
            if (r.resId.name == "Frost")
            {
                return r.Value;
            }
        }
        return 0;
    }
    public int PoisonCost()
    {
        foreach (ResourceScriptableObject r in cost)
        {
            if (r.resId.name == "Poison")
            {
                return r.Value;
            }
        }
        return 0;
    }
    public int FireCost()
    {
        foreach (ResourceScriptableObject r in cost)
        {
            if (r.resId.name == "Fire")
            {
                return r.Value;
            }
        }
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = this.GetComponent<PlayerHeatlh>();
        transactions = this.GetComponent<TransactionHandler>();
    }
    public void UpgradeStartHP()
    {
        if (isAffordable())
        {
            playerHealth.StartHp += upgradeValue;
            playerHealth.CurrentHp += upgradeValue;
            playerHealth.HealthController.SetMaxHP(playerHealth.StartHp);
            playerHealth.HealthController.SetHP(playerHealth.CurrentHp);
            playerHealth.UpdateHealthText();
        }
    }

    public void HealHp()
    {
        if ((playerHealth.CurrentHp + this.upgradeValue) <= playerHealth.StartHp)
        {
            playerHealth.CurrentHp += this.upgradeValue;
        }
        else
        {
            playerHealth.CurrentHp = playerHealth.StartHp;
        }
    }

    public bool isAffordable()
    {
        if (transactions != null)
        {
            if (transactions.ValidateResourceTransaction(cost))
            {

                transactions.CompleteTransaction(cost);
                return true;
            }
        }

        return false;
    }
}
