using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHighlighter : MonoBehaviour
{
    [SerializeField] private Material selectedMaterial;     //If this enemy is targeted by tower, change color
    private Material originalMaterial;                      //The object material
    private bool isTargeted;
    private GameObject meshObject; 
    public bool IsTargeted { get => isTargeted; set => isTargeted = value; }

    void Start()
    {
        meshObject = this.GetComponent<IAgent>().MeshObject;
        if (meshObject.GetComponent<MeshRenderer>() != null) originalMaterial = meshObject.GetComponent<MeshRenderer>().material;    //Make sure right standard material is selected
    }


    //Sets this enemy as targeted, this will change material to selectedMaterial
    public void SetTargeted()
    {
        meshObject.GetComponent<MeshRenderer>().material = selectedMaterial;
        IsTargeted = true;

    }

    //Sets this enemy as no longer targeted, and change material to original material
    public void RemoveTargeted()
    {
        meshObject.GetComponent<MeshRenderer>().material = originalMaterial;
        IsTargeted = false;
    }


}
