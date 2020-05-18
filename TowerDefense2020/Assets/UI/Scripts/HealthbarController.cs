using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    private Slider healthBar;
    private float currentHP = 100f;
    private float maxHP = 100f;


    private void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHP;
        healthBar.maxValue = maxHP;
    }

    public void ChangeHP(float hp)
    {
        currentHP += hp;
    }
    public void SetHP(float hp)
    {
        currentHP = hp;
    }
    public void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }
}
