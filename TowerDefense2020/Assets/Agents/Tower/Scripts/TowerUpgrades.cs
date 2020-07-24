using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]
public class TowerUpgrades : MonoBehaviour, IInjectTowerData, IDealWithResources
{
    private DetailView detailView;
    private TowerData towerData;
    private Clickable clickable; //Interface?
    private int damageUpgradeCost = 5;
    private int aoeUpgradeCost = 5;
    private int slowUpgradeCost = 5;
    private int dotUpgradeCost = 5;
    private int rangeUpgradeCost = 5;
    private _Resources resources;
    // Start is called before the first frame update
    void Start()
    {
        clickable = GetComponent<Clickable>();
        detailView = GameObject.Find("DetailView").GetComponent<DetailView>();
        detailView.UpgradeDamageButton.onClick.AddListener(() => UpgradeDamage());
        detailView.UpgradeAoeButton.onClick.AddListener(() => UpgradeAoe());
        detailView.UpgradeDotButton.onClick.AddListener(() => UpgradeDot());
        detailView.UpgradeSlowButton.onClick.AddListener(() => UpgradeSlow());
        detailView.UpgradeRangeButton.onClick.AddListener(() => UpgradeRange());
    }
    private void UpgradeRange()
    {
        if (clickable.IsOn)
        {/*
            if (resources.rangeResource.value >= rangeUpgradeCost)
            {
                towerData.Range += 0.2f;
                detailView.SetTowerDataStats(towerData);
                resources.rangeResource.value -= rangeUpgradeCost;
            }*/
        }
    }

    private void UpgradeSlow()
    {
        if (clickable.IsOn)
        {/*
            if (resources.slowResource.value >= rangeUpgradeCost)
            {
                towerData.Slow += 0.2f;
                detailView.SetTowerDataStats(towerData);
                resources.slowResource.value -= slowUpgradeCost;
            }*/
        }
    }

    private void UpgradeDot()
    {
        if (clickable.IsOn)
        {/*
            if (resources.dotResource.value >= dotUpgradeCost)
            {
                towerData.Dot += 0.2f;
                detailView.SetTowerDataStats(towerData);
                resources.dotResource.value -= dotUpgradeCost;
            }*/
        }
    }

    private void UpgradeAoe()
    {
        if (clickable.IsOn)
        {/*
            if (resources.aoeResource.value >= aoeUpgradeCost)
            {
                towerData.Aoe += 0.2f;
                detailView.SetTowerDataStats(towerData);
                resources.aoeResource.value -= aoeUpgradeCost;
            }*/
        }
    }

    private void UpgradeDamage()
    {
        if (clickable.IsOn)
        {/*
            if (resources.mainResource.value >= damageUpgradeCost)
            {            
                towerData.Damage += 0.2f;
                detailView.SetTowerDataStats(towerData);
                resources.mainResource.value -= damageUpgradeCost;
            }*/
        }
    }

    public void InjectTowerData(TowerData towerData)
    {
        this.towerData = towerData;
    }

    public void InjectResources(_Resources resources)
    {
        //Debug.Log("Injected at towerupgrades");
        this.resources = resources;
    }
}
