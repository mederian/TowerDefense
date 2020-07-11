using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    [SerializeField] ResourceScriptableObject resource;
    [SerializeField] ResourceScriptableObject essence;
    [SerializeField] TextMeshProUGUI UIText;
    [SerializeField] Image EssenceBar;
    // Start is called before the first frame update
    void Start()
    {
        UIText.text = resource.Value.ToString();


        EssenceBar.fillAmount = EssenceToBar();


    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = resource.Value.ToString();


        EssenceBar.fillAmount = EssenceToBar();

        
    }

    public float EssenceToBar()
    {
        if(essence.Value > 0)
        {
            float r = (float)essence.Value;
            float rs = r / 10.0f;

            return rs;
        }

        return 0;
    }
}
