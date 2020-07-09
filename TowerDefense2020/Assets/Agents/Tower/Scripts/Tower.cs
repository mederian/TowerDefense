using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IDealWithResources, IAgent
{
    public TowerData towerData;
    private _Resources resources;
    [SerializeField] GameObject meshObject;
    [SerializeField] ParticleSystem psysYellow;
    [SerializeField] ParticleSystem psysRed;
    [SerializeField] ParticleSystem psysGreen;
    [SerializeField] ParticleSystem psysBlue;
    [SerializeField] ParticleSystem psysPurple;


    public GameObject MeshObject { get => meshObject; set => meshObject = value; }

    //private ILevel levelData;

    private void Start()
    {

        IInjectTowerData[] injectScoreData = GetComponents<IInjectTowerData>();
        foreach (IInjectTowerData i in injectScoreData)
        {
            i.InjectTowerData(towerData);
        }
        IInjectScoreData[] injectTowerData = GetComponents<IInjectScoreData>();
        foreach(IInjectScoreData i in injectTowerData)
        {
            i.InjectScoreData(towerData);
        }

        foreach(IDealWithResources r in GetComponents<IDealWithResources>())
        {
            r.InjectResources(resources);
        }

        IInjectLevelData[] injectLevelData = GetComponents<IInjectLevelData>();
        foreach (IInjectLevelData i in injectLevelData)
        {
            i.InjectLevelData(towerData);
        }

        IInjectDamageStats[] injectDamageData = GetComponents<IInjectDamageStats>();
        foreach (IInjectDamageStats i in injectDamageData)
        {
            i.InjectDamageStats(towerData);
        }
        IInjectBuffStats[] injectBuffStats = GetComponents<IInjectBuffStats>();
        foreach (IInjectBuffStats i in injectBuffStats)
        {
            i.InjectBuffStats(towerData);
        }

        if(psysYellow != null)
        {
            towerData.InjectParticleSystemYellow(psysYellow);
        }
        if (psysRed != null)
        {
            towerData.InjectParticleSystemRed(psysRed);
        }
        if (psysBlue != null)
        {
            towerData.InjectParticleSystemBlue(psysBlue);
        }
        if (psysGreen != null)
        {
            towerData.InjectParticleSystemGreen(psysGreen);
        }
        if (psysPurple != null)
        {
            towerData.InjectParticleSystemPurple(psysPurple);
        }


    }

    public TowerData TowerData()
    {
        return towerData;
    }

    public void InjectResources(_Resources resources)
    {
        this.resources = resources;
    }
}
