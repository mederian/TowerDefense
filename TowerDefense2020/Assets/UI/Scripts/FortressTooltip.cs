using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTooltip : MonoBehaviour
{


    [SerializeField] private GameObject fortress;
    private UpgradePlayerArmor playerArmor;
    private UpgradePlayerHealth playerHealth;
    private UpgradePlayerSpike playerSpike;
    enum PropertyType
    {
        Heal,
        Armor,
        Spikes
    }
    [SerializeField] PropertyType updateType = PropertyType.Heal;


    // Start is called before the first frame update
    void Start()
    {

        if(fortress.GetComponent<UpgradePlayerArmor>() != null)
            playerArmor = fortress.GetComponent<UpgradePlayerArmor>();

        if (fortress.GetComponent<UpgradePlayerHealth>() != null)
            playerHealth = fortress.GetComponent<UpgradePlayerHealth>();

        if (fortress.GetComponent<UpgradePlayerSpike>() != null)
            playerSpike = fortress.GetComponent<UpgradePlayerSpike>();
    }
}
