using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitHighlighter : MonoBehaviour
{
    [SerializeField] private Material selectedMaterial;     //If this enemy is targeted by tower, change color
    private Material originalMaterial;                      //The object material
    [SerializeField] private float initTimer = 0.2f;
    private float countDownMultiplier = 2;
    private float timer;

    // Start is called before the first frame update

    void Start()
    {
        if (this.GetComponent<MeshRenderer>() != null) originalMaterial = this.GetComponent<MeshRenderer>().material;    //Make sure right standard material is selected
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Timer: " + timer.ToString());
        if(timer > 0)
        {
            timer -= Time.deltaTime*countDownMultiplier;
        }
        else if(timer <= 0)
        {
            EndHitFlash();
        }
    }

    //Change material, and start countdown towards changing back to origin material
    public void BeginHitFlash()
    {
        Debug.Log("Start HIT FLASH- " + gameObject.name.ToString() + " -");
        this.GetComponent<MeshRenderer>().material = selectedMaterial;
        timer = initTimer;
    }

    //Sets this enemy as no longer targeted, and change material to original material
    public void EndHitFlash()
    {
        if (GetComponent<TargetHighlighter>().IsTargeted)
        {
            GetComponent<TargetHighlighter>().SetTargeted();
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = originalMaterial;
        }
        
        timer = 0;

    }
}
