﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionStatus : MonoBehaviour
{
    [SerializeField] private float buildTime;
    private bool buildStarted = false;
    private bool buildComplete = false;
    private float timer = 0;

    public bool BuildComplete { get => buildComplete; set => buildComplete = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (buildStarted && !BuildComplete)
        {
            if (!GetComponent<ConstructionHighlighter>().IsAnimateConstruction())
            {
                GetComponent<ConstructionHighlighter>().AnimateConstruction();
            }
            timer += Time.deltaTime;
            if(timer > buildTime)
            {
                CompleteBuild();
            }
        }

    }

    public void CompleteBuild()
    {
        BuildComplete = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        GetComponent<ConstructionHighlighter>().EndAnimateConstruction();
        //this.GetComponent<CircleSelect>().CreateSelectorMarker();
    }

    public void StartConstruction() 
    {
        buildStarted = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    //returns false if not yet constructed
    public bool IsConstructionComplete()
    {
        return BuildComplete;
    }


}
