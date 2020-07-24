using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private ResourceScriptableObject resource;
    [SerializeField] private ResourceScriptableObject essence;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private GameObject mainResourceIcon;
    [SerializeField] Image EssenceBar;
    private int prevValue;
    // Start is called before the first frame update
    void Start()
    {
        UIText.text = resource.Value.ToString();
        prevValue = resource.Value;

        EssenceBar.fillAmount = EssenceToBar();


    }

    // Update is called once per frame
    void Update()
    {
        if(resource.Value != prevValue)
        {
            UIText.text = resource.Value.ToString();
            //TODO: Animate the resource 
            if(prevValue < resource.Value)
            {
                mainResourceIcon.GetComponent<Animator>().SetTrigger("AddResTrigger");
            }
            else if(prevValue > resource.Value)
            {
                mainResourceIcon.GetComponent<Animator>().SetTrigger("SubResTrigger");
            }
            
            prevValue = resource.Value;
        }
        


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
