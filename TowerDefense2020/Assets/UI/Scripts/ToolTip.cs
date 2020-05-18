using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    private ITooltip tooltipData;
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
        if(tooltipData != null)
        {
            uiText.text = tooltipData.GetTooltip();
        }
        else
        {
            uiText.text = defaultTooltip;
        }
    }   
    public void HideTooltip()
    {
        uiText.text = "";
    }
}
