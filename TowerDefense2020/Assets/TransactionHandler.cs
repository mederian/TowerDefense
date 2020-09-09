using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionHandler : MonoBehaviour
{
    [SerializeField] private List<ResourceScriptableObject> resources;
    [SerializeField] private List<ResourceScriptableObject> essences;


    public bool ValidateResourceTransaction(List<ResourceScriptableObject> cost)
    {
        int count = 0;
        foreach(ResourceScriptableObject c in cost)
        {
            foreach(ResourceScriptableObject r in resources)
            {
                if(r.resId == c.resId)
                {
                    if(c.Value > r.Value)
                    {
                        return false;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }
        Debug.Log("count: " + count.ToString() + " cost.count: " + cost.Count.ToString());
        if (count == cost.Count)
        {
            return true;
        }
        return false;
    }

    public void SubtractCost(List<ResourceScriptableObject> cost)
    {
        foreach (ResourceScriptableObject r in resources)
        {
            foreach (ResourceScriptableObject c in cost)
            {
                if(r.resId == c.resId)
                {
                    r.Value -= c.Value;
                }
            }
        }
    }
}
