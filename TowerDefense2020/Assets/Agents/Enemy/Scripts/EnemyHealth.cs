using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
	[SerializeField] private float startHP = 1;             //Starting hitpoint
	[SerializeField] private float currentHP = 1;           //Remaining hitpoint
    private EnemyFloatingText enemyFloatingText;

    public float StartHp { get => this.startHP; set => this.startHP = value; }
    public float CurrentHp { get => this.currentHP; set => this.currentHP = value; }

    void Awake()
	{
		currentHP = startHP;  //MAke current hp start with the starthp value.
        if(GetComponent<EnemyFloatingText>() != null) enemyFloatingText = GetComponent<EnemyFloatingText>();
    }
    public void LooseHP(float amount, float initDamage, IScore source)
    {
        currentHP -= amount;
        if(enemyFloatingText != null)
        {
            if(initDamage == amount) enemyFloatingText.GenerateScoreText(amount);
            else
            {
                enemyFloatingText.GenerateScoreText(amount, initDamage);
            }
        }
        if(GetComponent<HitHighlighter>() != null)
        {
            GetComponent<HitHighlighter>().BeginHitFlash();
        }
        
        if (currentHP <= 0)
        {
            GetComponent<Death>().Die(source);
        }
    }
    public void LooseHpDOT(float amount, IScore source)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            GetComponent<Death>().Die(source);
        }
    }
}
