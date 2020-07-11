using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCost : MonoBehaviour, ICost
{
    private List<ResourceScriptableObject> resourceCost;
    public List<ResourceScriptableObject> ResourceCost { get => resourceCost; set => resourceCost = value; }
}
