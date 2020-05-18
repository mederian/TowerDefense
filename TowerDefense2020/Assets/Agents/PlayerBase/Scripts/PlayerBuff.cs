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
    public void RecieveBuff(List<Resource> resources)
    {
        foreach (Resource r in resources)
        {

            if (r.name == damageBuffResource)
            {
                Debug.Log("dropping buffses on player");
            }

            else if (r.name == aoeBuffResource)
            {
                //towerData.BuffAoe += r.value;
            }

            else if (r.name == slowBuffResource)
            {
                //towerData.BuffSlow += r.value;
            }

            else if (r.name == dotBuffResource)
            {
                //towerData.BuffDot += r.value;
            }

            else if (r.name == rangeBuffResource)
            {
                //towerData.BuffRange += r.value;
            }
        }
        //resources.Clear();
    }

}
