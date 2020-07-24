using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour, IHandleBuff
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

            if (r.ResourceName == damageBuffResource)
            {
                Debug.Log("dropping buffses on player");
            }

            else if (r.ResourceName == aoeBuffResource)
            {
                //towerData.BuffAoe += r.value;
            }

            else if (r.ResourceName == slowBuffResource)
            {
                //towerData.BuffSlow += r.value;
            }

            else if (r.ResourceName == dotBuffResource)
            {
                //towerData.BuffDot += r.value;
            }

            else if (r.ResourceName == rangeBuffResource)
            {
                //towerData.BuffRange += r.value;
            }
        }
        //resources.Clear();
    }
}
