using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCost : MonoBehaviour, ICost
{
    [SerializeField] private List<ResourceScriptableObject> resourceCost;
    [SerializeField] private List<ResourceScriptableObject> playerResources;
    public List<ResourceScriptableObject> ResourceCost { get => resourceCost; set => resourceCost = value; }

    private List<TransactionPair> transactionPairs;

    public bool AttemptTransaction()
    {
        if(transactionPairs == null)
        {
            transactionPairs = new List<TransactionPair>();
        }
        else
        {
            transactionPairs.Clear();
        }
        bool transactionGo = false;
        //Debug.Log("Attempting transaction");
        if (resourceCost == null)
        {
            //Debug.Log("towercost is null");
            return true;
        }
        foreach (ResourceScriptableObject costRes in resourceCost)
        {
     
            foreach (ResourceScriptableObject playerRes in playerResources)
            {
                if (costRes.ResourceName == playerRes.ResourceName)
                {
          
                    if (playerRes.Value - costRes.Value >= 0)
                    {
                        //create transaction pairs
                        
                        transactionPairs.Add(new TransactionPair(costRes, playerRes));               
                    }
                    else
                    {
                    
                        return false;
                    }
                }
            }
        }

        foreach(TransactionPair t in transactionPairs)
        {
            t.CompleteTransaction();
        }
        return true;
    }
}
class TransactionPair
{
    ResourceScriptableObject cost;
    ResourceScriptableObject asset;

    public TransactionPair(ResourceScriptableObject cost, ResourceScriptableObject asset)
    {
        this.cost = cost;
        this.asset = asset;
    }
    public void InitPair(ResourceScriptableObject cost, ResourceScriptableObject asset)
    {
        this.cost = cost;
        this.asset = asset;
    }
    public void CompleteTransaction()
    {
        if(asset != null &&  cost != null) {
            this.asset.Value -= this.cost.Value;
        }
        
    }
}