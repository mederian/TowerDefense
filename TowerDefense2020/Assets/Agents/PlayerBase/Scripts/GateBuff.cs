using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBuff : MonoBehaviour, IHandleBuff
{
    private string damageBuffResource = "Gold Essence";
    private string aoeBuffResource = "Fire Essence";
    private string slowBuffResource = "Frost Essence";
    private string dotBuffResource = "Poison Essence";
    private string rangeBuffResource = "Mana Essence";
    /*
    public void RecieveBuff(List<Resource> resources)
    {
        foreach (Resource r in resources)
        {
            //HP
            if (r.name == damageBuffResource)
            {
                this.GetComponent<DamageableComponent>().Hp += 1f;
                //towerData.BuffDamage += r.value;
            }
            //damages enemies
            else if (r.name == aoeBuffResource)
            {
                //towerData.BuffAoe += r.value;
            }
            //chance to freeze enemy?
            else if (r.name == slowBuffResource)
            {
                //towerData.BuffSlow += r.value;
            }
            //Healing over time
            else if (r.name == dotBuffResource)
            {
                //towerData.BuffDot += r.value;
            }
            //Damage reduction?
            else if (r.name == rangeBuffResource)
            {
                //towerData.BuffRange += r.value;
            }
        }
        resources.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
