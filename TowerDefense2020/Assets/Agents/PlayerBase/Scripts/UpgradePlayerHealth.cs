using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHeatlh))]
public class UpgradePlayerHealth : MonoBehaviour
{
    private float upgradeValue = 1;
    private PlayerHeatlh playerHealth;
    private TransactionHandler transactionHandler;
    [SerializeField] private List<ResourceScriptableObject> resourceCost;

    void Start()
    {
        playerHealth = this.GetComponent<PlayerHeatlh>();

        transactionHandler = this.GetComponent<TransactionHandler>();
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

            SubtractCost();
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
        if(transactionHandler != null)
        {
            if (transactionHandler.ValidateResourceTransaction(resourceCost))
            {
                return true;
            }
        }

        return false;
    }

    public void SubtractCost()
    {
        if(transactionHandler != null)
        {
            transactionHandler.SubtractCost(resourceCost);
        }
    }
}
