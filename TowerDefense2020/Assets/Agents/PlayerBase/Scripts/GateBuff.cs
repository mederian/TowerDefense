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
    
    public void RecieveBuff(List<ResourceScriptableObject> resources)
    {
        foreach (ResourceScriptableObject r in resources)
        {
            //HP
            if (r.ResourceName == damageBuffResource)
            {
                this.GetComponent<DamageableComponent>().Hp += 1f;
                //towerData.BuffDamage += r.Value;
            }
            //damages enemies
            else if (r.ResourceName == aoeBuffResource)
            {
                //towerData.BuffAoe += r.Value;
            }
            //chance to freeze enemy?
            else if (r.ResourceName == slowBuffResource)
            {
                //towerData.BuffSlow += r.Value;
            }
            //Healing over time
            else if (r.ResourceName == dotBuffResource)
            {
                //towerData.BuffDot += r.Value;
            }
            //Damage reduction?
            else if (r.ResourceName == rangeBuffResource)
            {
                //towerData.BuffRange += r.Value;
            }
        }
        resources.Clear();
    }
}
