using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IInjectTowerData
{
    [SerializeField] private bool isOn = false;
    private DetailView detailView;
    private TowerData towerData;

    public bool IsOn { get => isOn; set => isOn = value; }

    public void Start()
    {
        detailView = GameObject.Find("DetailView").GetComponent<DetailView>();  
    }
    public void ToggleClick()
    {
        if (IsOn)
        {
            detailView.ResetTowerData();
            GetComponent<SelectorHighlighter>().HideSelector();
            IsOn = false;
        }
        else if (!IsOn)
        {
            detailView.SetTowerDataStats(towerData);
            GetComponent<SelectorHighlighter>().ShowSelector();
            IsOn = true;
        }
    }
    public void ToggleOff()
    {
        detailView.ResetTowerData();
        GetComponent<SelectorHighlighter>().HideSelector();
        IsOn = false;
    }

    public void InjectTowerData(TowerData towerData)
    {   
        this.towerData = towerData;
    }
}
