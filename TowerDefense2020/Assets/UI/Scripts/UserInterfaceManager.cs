using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] topText;
    [SerializeField] private TextMeshProUGUI mainResourceText;
    [SerializeField] private GameObject mainResourceIcon;
    [SerializeField] private TextMeshProUGUI aoeResourceText;
    [SerializeField] private TextMeshProUGUI slowResourceText;
    [SerializeField] private TextMeshProUGUI dotResourceText;
    [SerializeField] private TextMeshProUGUI rangeResourceText;
    [SerializeField] private GameObject enemyController;
    private ResourceManager resourceManager;

    void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
        //TODO: inject resources into enemycontroller correctly
        //enemyController.GetComponent<EnemyController>().InjectResourceData(this.GetComponent<ResourceManager>().ResourceData());
        //if

        
    }

    public void UpdateAllVisuals()
    {
        resourceManager.UpdateMainResourceText(mainResourceText);
        resourceManager.UpdateAoeResourceText(aoeResourceText);
        resourceManager.UpdateDotResourceText(dotResourceText);
        resourceManager.UpdateSlowResourceText(slowResourceText);
        resourceManager.UpdateRangeResourceText(rangeResourceText);
    }
    private void Update()
    {
        mainResourceIcon.GetComponent<Animator>().SetBool("AddRes", false);
        //UpdateAllVisuals();



        if (resourceManager.GoldChange())
        {

            mainResourceIcon.GetComponent<Animator>().SetBool("AddRes", true);
            UpdateAllVisuals();

            Debug.Log("TOGGGG");
            
            //Update gold visual

            //mainResourceIcon.GetComponent<Animator>().SetBool("AddRes", false);
        }
    }
}
