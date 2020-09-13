using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHeatlh : MonoBehaviour, IHealth
{
    [SerializeField] float startHp = 100f;
    [SerializeField] float currentHp = 100f;
    public float StartHp { get => startHp; set => startHp = value; }
    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public HealthbarController HealthController { get => healthController; set => healthController = value; }
    private List<DamageableComponent> damageableComponents;
    private HealthbarController healthController;
    private TextMeshProUGUI healthText;


    private void Start()
    {
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
        this.currentHp -= actAmount;
        healthController.SetHP(currentHp);
        UpdateHealthText();

        if (currentHp <= 0)
        {
            GetComponent<PlayerDeath>().Die();
        }
    }

    public void LooseHpDOT(float amount, IScore source)
    {
        throw new NotImplementedException();
    }
}
