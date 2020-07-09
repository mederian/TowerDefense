using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHeatlh : MonoBehaviour, IHealth, IDealWithResources
{
    [SerializeField] float startHp = 100f;
    [SerializeField] float currentHp = 100f;

    private List<DamageableComponent> damageableComponents;
    private HealthbarController healthController;
    private TextMeshProUGUI healthText;
    private _Resources resources;

    //Todo : User UpgradePlayerHealth instead of these
    [SerializeField] private int goldCost = 5;
    [SerializeField] private int manaCost = 5;
    [SerializeField] private int frostCost = 5;
    [SerializeField] private int poisonCost = 5;
    [SerializeField] private int fireCost = 5;

    public float StartHp { get => startHp; set => startHp = value; }
    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public HealthbarController HealthController { get => healthController; set => healthController = value; }

    private void Start()
    {
        resources = GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources();
        damageableComponents = new List<DamageableComponent>();
        healthController = GameObject.Find("Healthbar").GetComponent<HealthbarController>();
        healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        healthController.SetMaxHP(startHp);
        healthController.SetHP(currentHp);
        UpdateHealthText();
        DamageableComponent[] dComponents = this.GetComponentsInChildren<DamageableComponent>();
        foreach (DamageableComponent d in dComponents)
        {
            damageableComponents.Add(d);
        }
    }

    public void UpdateHealthText()
    {
        healthText.text = startHp + "/" + currentHp;
    }


    public void LooseHP(float amount, float initDamage, IScore source)
    {
        float actAmount = this.GetComponent<PlayerArmor>().DamageAfterArmor(amount);

           // Debug.Log("main damage:" + amount + "(" + actAmount + ")");
            
            this.currentHp -= actAmount;
            healthController.SetHP(currentHp);
            UpdateHealthText();
            //Debug.Log("CurrentHP: " + currentHp.ToString());

            if (currentHp <= 0)
            {
                GetComponent<PlayerDeath>().Die();
            }
    }

    public void LooseHpDOT(float amount, IScore source)
    {
        throw new NotImplementedException();
    }

    public void InjectResources(_Resources resources)
    {
        this.resources = resources;
    }

    private bool isAffordable()
    {
        if (resources == null)
        {
            resources = GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources();
        }/*
        if (resources.mainResource.value >= goldCost && resources.aoeResource.value >= fireCost &&
                resources.slowResource.value >= frostCost && resources.dotResource.value >= poisonCost &&
                resources.rangeResource.value >= manaCost)
        {
            return true;
        }*/
        return false;
    }
    private void SubtractCost()
    {
        if (resources == null)
        {
            resources = GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources();
        }
        /*
        resources.mainResource.value -= goldCost;
        resources.aoeResource.value -= fireCost;
        resources.slowResource.value -= frostCost;
        resources.dotResource.value -= poisonCost;
        resources.rangeResource.value -= manaCost;
    */}
}
