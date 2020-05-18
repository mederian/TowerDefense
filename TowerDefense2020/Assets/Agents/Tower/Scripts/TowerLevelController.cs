using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevelController : MonoBehaviour, IInjectTowerData
{
    [SerializeField] private List<int> levelLadder = new List<int>();
    private bool maxLevel = false;
    private TowerData towerData;

    public void UpdateLevel()
    {
        //Debug.Log("LevelLadder.Count: " + levelLadder.Count.ToString() + " towerData.Level:" + towerData.Level.ToString());
        if (levelLadder.Count > towerData.Level && levelLadder.Count > 0)
        {
            if (towerData != null)
            {
                if (levelLadder[towerData.Level] <= towerData.Xp)
                {
                    LevelUp();
                }
            }
        }
    }

    void OnEnable()
    {
        EnemyController.OnKill += UpdateLevel;
    }
    void OnDisable()
    {
        EnemyController.OnKill -= UpdateLevel;
    }

    private void LevelUp()
    {
        if (towerData != null)
        {
            towerData.Level++;

            //bonuses on level? 

        }
    }

    public void InjectTowerData(TowerData towerData)
    {
        this.towerData = towerData;
    }
}
