using System.Collections;
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


    void Awake()
    {
        goldValue.gameObject.SetActive(false);
        goldImage.gameObject.SetActive(false);
        fireValue.gameObject.SetActive(false);
        fireImage.gameObject.SetActive(false);
        frostValue.gameObject.SetActive(false);
        frostImage.gameObject.SetActive(false);
        poisonValue.gameObject.SetActive(false);
        poisonImage.gameObject.SetActive(false);
        manaValue.gameObject.SetActive(false);
        manaImage.gameObject.SetActive(false);
    }
    public void HidePanel()
    {


        goldValue.gameObject.SetActive(false);
        goldImage.gameObject.SetActive(false);
        fireValue.gameObject.SetActive(false);
        fireImage.gameObject.SetActive(false);
        frostValue.gameObject.SetActive(false);
        frostImage.gameObject.SetActive(false);
        poisonValue.gameObject.SetActive(false);
        poisonImage.gameObject.SetActive(false);
        manaValue.gameObject.SetActive(false);
        manaImage.gameObject.SetActive(false);
    }
    public void ShowPanel(int g, int f, int fr, int p, int m)
    {
        SetGold(g);
        SetFire(f);
        SetFrost(fr);
        SetPoison(p);
        SetMana(m);

        if (goldValue.text == "0")
        {
            goldValue.gameObject.SetActive(false);
            goldImage.gameObject.SetActive(false);
        }
        else
        {
            goldValue.gameObject.SetActive(true);
            goldImage.gameObject.SetActive(true);
        }

        if (fireValue.text == "0")
        {
            fireValue.gameObject.SetActive(false);
            fireImage.gameObject.SetActive(false);
        }
        else
        {
            fireValue.gameObject.SetActive(true);
            fireImage.gameObject.SetActive(true);
        }
        if (frostValue.text == "0")
        {
            frostValue.gameObject.SetActive(false);
            frostImage.gameObject.SetActive(false);
        }
        else
        {
            frostValue.gameObject.SetActive(true);
            frostImage.gameObject.SetActive(true);
        }
        if (poisonValue.text == "0")
        {
            poisonValue.gameObject.SetActive(false);
            poisonImage.gameObject.SetActive(false);
        }
        else
        {
            poisonValue.gameObject.SetActive(true);
            poisonImage.gameObject.SetActive(true);
        }
        if (manaValue.text == "0")
        {
            manaValue.gameObject.SetActive(false);
            manaImage.gameObject.SetActive(false);
        }
        else
        {
            manaValue.gameObject.SetActive(true);
            manaImage.gameObject.SetActive(true);
        }

        
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
