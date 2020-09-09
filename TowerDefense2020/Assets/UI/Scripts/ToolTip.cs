using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    private ITooltip tooltipData;
    [SerializeField] ToolTipPanel panel;
    [SerializeField] TextMeshProUGUI uiText;
    private string defaultTooltip = "Tooltip";

    private void Awake()
    {
        if(GetComponent<ITooltip>() != null)
        tooltipData = GetComponent<ITooltip>();
    }
    private void OnGUI()
    {
        
    }

    public void ShowTooltip()
    {
        //panel.ShowPanel(tooltipData.GoldCost(), tooltipData.FireCost(), tooltipData.FrostCost(), tooltipData.PoisonCost(), tooltipData.ManaCost());
    }   
    public void HideTooltip()
    {
        //panel.HidePanel();

    }
}
