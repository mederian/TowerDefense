using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceGenerator : MonoBehaviour, IDealWithResources, IDealWithEssences
{

    [SerializeField] private float regenRate = 0.2f;
    private _Resources resources;
    private _Essences essences;
    private bool regenActive = true;

    void Start()
    {
        GenerateEssences();
    }

    private void GenerateEssences()
    {
        foreach(ResourceScriptableObject ess in essences.Essences)
        {
            foreach(ResourceScriptableObject res in resources.Resources)
            {
                if(ess.resId.name == res.resId.name)
                {
                    StartCoroutine(RegainEssenceOverTime(ess, res));
                }
            }            
        }
    }

    private IEnumerator RegainEssenceOverTime(ResourceScriptableObject essence, ResourceScriptableObject resource)
    {
        bool first = true;

        while (regenActive)
        {
            
            float reg = (((resource.MaxValue - resource.Value) / 10) + 0.5f) * regenRate; //TODO: get regenValue from the scriptable object
            
            if (essence.Value < essence.MaxValue)
            {
                if(resource.Value > 0)
                {
                    if (!first)
                    {
                        essence.Value++;
                    }
                }
                Debug.Log("Reg "+ essence.ResourceName + ": " + reg.ToString() + " Max: " + resource.MaxValue.ToString() + " Value: " + resource.Value.ToString() + " RegenRate: " + regenRate.ToString() + "WaitForSecond: " + reg.ToString());
                
            }
            if (first) first = false;
            yield return new WaitForSeconds(reg);
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
