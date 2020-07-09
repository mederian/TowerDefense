using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceGenerator : MonoBehaviour, IDealWithResources, IDealWithEssences
{

    ResourceManager resourceManager;
    private float mainEssenceCounter = 0;
    private float aoeEssenceCounter = 0;
    private float slowEssenceCounter = 0;
    private float dotEssenceCounter = 0;
    private float rangeEssenceCounter = 0;

    [SerializeField] private float mainEssenceGeneration = 0.2f;
    [SerializeField] private float aoeEssenceGeneration = 0.2f;
    [SerializeField] private float slowEssenceGeneration = 0.2f;
    [SerializeField] private float dotEssenceGeneration = 0.2f;
    [SerializeField] private float rangeEssenceGeneration = 0.2f;
    private _Resources resources;
    private _Essences essences;

    // Start is called before the first frame update
    void Start()
    {
        resourceManager = this.GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GenerateMainEssence();
        GenerateAoeEssence();
        GenerateSlowEssence();
        GenerateDotEssence();
        GenerateRangeEssence();
    }

    private void GenerateRangeEssence()
    {

        if (rangeEssenceCounter > 10)
        {/*
            if ((essences.rangeEssence.value+1) <= resourceManager.MaxEssence)
            {
                essences.rangeEssence.value += 1;
            }
            rangeEssenceCounter = 0;
            GetComponent<UserInterfaceManager>().UpdateAllVisuals();
        */}
        else
        {
            //rangeEssenceCounter += Time.deltaTime * (rangeEssenceGeneration * resources.rangeResource.value);
        }
    }

    private void GenerateDotEssence()
    {
        if (dotEssenceCounter > 10)
        {/*
            if ((essences.dotEssence.value + 1) <= resourceManager.MaxEssence)
            {
                essences.dotEssence.value += 1;
            }
            dotEssenceCounter = 0;
            GetComponent<UserInterfaceManager>().UpdateAllVisuals();
        */}
        else
        {
           // dotEssenceCounter += Time.deltaTime * (dotEssenceGeneration * resources.dotResource.value);
        }
    }

    private void GenerateSlowEssence()
    {
        if (slowEssenceCounter > 10)
        {/*
            if ((essences.slowEssence.value + 1) <= resourceManager.MaxEssence)
            {
                essences.slowEssence.value += 1;
            }
            slowEssenceCounter = 0;
            GetComponent<UserInterfaceManager>().UpdateAllVisuals();
        */}
        else
        {
            //slowEssenceCounter += Time.deltaTime * (slowEssenceGeneration * resources.slowResource.value);
        }
    }

    private void GenerateAoeEssence()
    {
        if (aoeEssenceCounter > 10)
        {/*
            if ((essences.aoeEssence.value + 1) <= resourceManager.MaxEssence)
            {
                essences.aoeEssence.value += 1;
            }
            aoeEssenceCounter = 0;
            GetComponent<UserInterfaceManager>().UpdateAllVisuals();
        */}
        else
        {
            //aoeEssenceCounter += Time.deltaTime * (aoeEssenceGeneration * resources.aoeResource.value);
        }
    }

    public void GenerateMainEssence()
    {
        if(mainEssenceCounter > 10)
        {/*
            if ((essences.mainEssence.value + 1) <= resourceManager.MaxEssence)
            {
                essences.mainEssence.value += 1;
            }
            mainEssenceCounter = 0;
            GetComponent<UserInterfaceManager>().UpdateAllVisuals();
        */}
        else
        {
          //  mainEssenceCounter += Time.deltaTime * (mainEssenceGeneration * resources.mainResource.value);
        }
    }

    public void InjectResources(_Resources resources)
    {
        this.resources = resources;
    }

    public void InjectEssences(_Essences essences)
    {
        this.essences = essences;
    }
}
