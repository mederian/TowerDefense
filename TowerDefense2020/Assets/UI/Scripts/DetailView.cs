using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailView : MonoBehaviour, IDetailView
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI dmgText;
    [SerializeField] private TextMeshProUGUI aoeText;
    [SerializeField] private TextMeshProUGUI slowText;
    [SerializeField] private TextMeshProUGUI dotText;
    [SerializeField] private TextMeshProUGUI rangeText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI xpText;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private Button upgradeDamageButton;
    [SerializeField] private Button upgradeAoeButton;
    [SerializeField] private Button upgradeSlowButton;
    [SerializeField] private Button upgradeDotButton;
    [SerializeField] private Button upgradeRangeButton;
    private TowerData towerData;

    public Button UpgradeDamageButton { get => upgradeDamageButton; set => upgradeDamageButton = value; }
    public Button UpgradeAoeButton { get => upgradeAoeButton; set => upgradeAoeButton = value; }
    public Button UpgradeSlowButton { get => upgradeSlowButton; set => upgradeSlowButton = value; }
    public Button UpgradeDotButton { get => upgradeDotButton; set => upgradeDotButton = value; }
    public Button UpgradeRangeButton { get => upgradeRangeButton; set => upgradeRangeButton = value; }

    void OnEnable()
    {
        ClearTowerData();
        EnemyController.OnKill += PopulateDetails;
        TowerBuff.OnBuff += PopulateDetails;
    }
    void OnDisable()
    {
        EnemyController.OnKill -= PopulateDetails;
        TowerBuff.OnBuff -= PopulateDetails;
    }

    public void SetTowerDataStats(TowerData damageStats)
    {
        this.towerData = damageStats;
        PopulateDetails();

    }
    public void ResetTowerData()
    {
        this.towerData = null;
        ClearTowerData();
    }

    public void PopulateDetails()
    {

        if (towerData != null)
        {
            titleText.text = "" + towerData.Name;
            dmgText.text = "Damage: " + towerData.Damage.ToString() + "(" + towerData.BuffDamage + ")";
            aoeText.text = "Aoe: " + towerData.Aoe.ToString() + "(" + towerData.BuffAoe + ")";
            dotText.text = "Dot: " + towerData.Dot.ToString() + "(" + towerData.BuffDot + ")";
            rangeText.text = "Range: " + towerData.Range.ToString() + "(" + towerData.BuffRange + ")";
            slowText.text = "Slow: " + towerData.Slow.ToString() + "(" + towerData.BuffSlow + ")";
            killsText.text = "Kills: " + towerData.Kills.ToString();
            xpText.text = "XP: " + towerData.Xp.ToString();
            levelText.text = "Level:" + towerData.Level.ToString();
        }

    }
    public void ClearTowerData()
    {
        titleText.text = "";
        dmgText.text = "";
        aoeText.text = "";
        slowText.text = "";
        dotText.text = "";
        rangeText.text = "";
        killsText.text = "";
        xpText.text = "";
        levelText.text = "";

    }

}
