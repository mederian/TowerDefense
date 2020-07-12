using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCost : MonoBehaviour, ICost
{
    [SerializeField] private List<ResourceScriptableObject> resourceCost;
    [SerializeField] private List<ResourceScriptableObject> playerResources;
    public List<ResourceScriptableObject> ResourceCost { get => resourceCost; set => resourceCost = value; }


    public bool AttemptTransaction()
    {
        Debug.Log("Attempting transaction");
        if (resourceCost == null)
        {
            Debug.Log("towercost is null");
            return true;
        }
        foreach (ResourceScriptableObject costRes in resourceCost)
        {
            //TODO: This will not work, fix it 
            Debug.Log("NEXT: " + costRes.ResourceName);
            foreach (ResourceScriptableObject playerRes in playerResources)
            {
                if (costRes.ResourceName == playerRes.ResourceName)
                {
                    Debug.Log("SAME NAME GOD DAMNIT!!!");
                    if (playerRes.Value - costRes.Value <= 0)
                    {
                        playerRes.Value -= costRes.Value;
                        return true;
                    }
                    else
                    {
                        Debug.Log("Not enough mony");
                        return false;
                    }
                }
            }
        }
        return true;
    }
}