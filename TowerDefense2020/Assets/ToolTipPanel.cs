﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipPanel : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI goldValue;
    [SerializeField]private TextMeshProUGUI fireValue;
    [SerializeField]private TextMeshProUGUI frostValue;
    [SerializeField]private TextMeshProUGUI poisonValue;
    [SerializeField]private TextMeshProUGUI manaValue;
    [SerializeField] private Image goldImage;
    [SerializeField] private Image fireImage;
    [SerializeField] private Image frostImage;
    [SerializeField] private Image poisonImage;
    [SerializeField] private Image manaImage;

    public void HidePanel()
    {
        this.enabled = false;
    }

    public void SetGold(int value)
    {
        goldValue.text = value.ToString();
    }
    public void SetFire(int value)
    {
        fireValue.text = value.ToString();
    }
    public void SetFrost(int value)
    {
        frostValue.text = value.ToString();
    }
    public void SetPoison(int value)
    {
        poisonValue.text = value.ToString();
    }
    public void SetMana (int value)
    {
        manaValue.text = value.ToString();
    }

}
