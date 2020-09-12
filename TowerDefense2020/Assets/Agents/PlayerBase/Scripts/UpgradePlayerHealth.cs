using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHeatlh))]
public class UpgradePlayerHealth : MonoBehaviour
{
    private float upgradeValue = 1;
    private PlayerHeatlh playerHealth;
    [SerializeField] private int goldCost = 5;
    [SerializeField] private int manaCost = 5;
    [SerializeField] private int frostCost = 5;
    [SerializeField] private int poisonCost = 5;
    [SerializeField] private int fireCost = 5;


    [SerializeField] List<ResourceScriptableObject> cost;
    private TransactionHandler transactions;

    public int GoldCost { get => goldCost; set => goldCost = value; }
    public int ManaCost { get => manaCost; set => manaCost = value; }
    public int FrostCost { get => frostCost; set => frostCost = value; }
    public int PoisonCost { get => poisonCost; set => poisonCost = value; }
    public int FireCost { get => fireCost; set => fireCost = value; }

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
        if(transactions != null)
        {
            if (transactions.ValidateResourceTransaction(cost))
            {
                transactions.CompleteTransaction(cost);
            }
        }

        return false;
    }

    public void SubtractCost()
    {
        
    }

}
