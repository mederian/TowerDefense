using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionHandler : MonoBehaviour
{
    [SerializeField] List<ResourceScriptableObject> resources;
    [SerializeField] List<ResourceScriptableObject> essences;

    public bool ValidateResourceTransaction(List<ResourceScriptableObject> cost)
    {
        int counter = 0;
        foreach(ResourceScriptableObject c in cost)
        {
            foreach(ResourceScriptableObject r in resources)
            {
                if(c.resId == r.resId)
                {
                    if(c.Value > r.Value)
                    {
                        return false;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
        }
        if(counter == cost.Count)
        {
            Debug.Log("Transaction i valid");
            return true;
        }
        else
        {
            return false;
        }
    }
    public void CompleteTransaction(List<ResourceScriptableObject> cost)
    {
        foreach(ResourceScriptableObject c in cost)
        {
            foreach(ResourceScriptableObject r in resources)
            {
                if (c.resId == r.resId)
                {
                    r.Value -= c.Value;
                    Debug.Log("Subtracted: " + c.Value + " from " + c.resId.ToString());
                }
            }
            
        }  
    }
   
}
