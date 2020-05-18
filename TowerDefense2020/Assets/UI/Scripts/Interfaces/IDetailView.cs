using UnityEngine.UI;

public interface IDetailView
{
    //TODO: Clean up this interface (interface segration p.)
    Button UpgradeAoeButton { get; set; }
    Button UpgradeDamageButton { get; set; }
    Button UpgradeDotButton { get; set; }
    Button UpgradeRangeButton { get; set; }
    Button UpgradeSlowButton { get; set; }

    void ClearTowerData();
    void PopulateDetails();
    void ResetTowerData();
    void SetTowerDataStats(TowerData damageStats);
}