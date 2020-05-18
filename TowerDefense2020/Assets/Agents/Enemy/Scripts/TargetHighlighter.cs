using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHighlighter : MonoBehaviour
{
    [SerializeField] private Material selectedMaterial;     //If this enemy is targeted by tower, change color
    private Material originalMaterial;                      //The object material
    private bool isTargeted;

    public bool IsTargeted { get => isTargeted; set => isTargeted = value; }

    void Start()
    {
        if (this.GetComponent<MeshRenderer>() != null) originalMaterial = this.GetComponent<MeshRenderer>().material;    //Make sure right standard material is selected
    }


    //Sets this enemy as targeted, this will change material to selectedMaterial
    public void SetTargeted()
    {
        this.GetComponent<MeshRenderer>().material = selectedMaterial;
        IsTargeted = true;

    }

    //Sets this enemy as no longer targeted, and change material to original material
    public void RemoveTargeted()
    {
        this.GetComponent<MeshRenderer>().material = originalMaterial;
        IsTargeted = false;
    }
}
