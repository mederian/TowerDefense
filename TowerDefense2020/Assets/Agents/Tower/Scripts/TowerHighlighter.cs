using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHighlighter : MonoBehaviour
{
    [SerializeField] private GameObject circleObjectPrefab;
    [SerializeField] private GameObject rangeObjectPrefab;
    [SerializeField] private Material selectedMaterial;
    private Material originalMaterial;
    private bool hover = false;


    void Start()
    {
        if (circleObjectPrefab != null)
        {
            HideCircle();
            circleObjectPrefab.GetComponent<Renderer>().material = selectedMaterial;

        }
        if(rangeObjectPrefab != null)
        {
            rangeObjectPrefab.transform.localScale = new Vector3(this.GetComponent<Tower>().towerData.Range, this.GetComponent<Tower>().towerData.Range, this.GetComponent<Tower>().towerData.Range);
        }
    }
    public void ShowCircle()
    {
        if (circleObjectPrefab != null)
        {
            //TODO: Show sphere that shows the range of the tower
            circleObjectPrefab.SetActive(true);
        }
        if(rangeObjectPrefab != null)
        {
            rangeObjectPrefab.SetActive(true);
            rangeObjectPrefab.transform.localScale = new Vector3(this.GetComponent<Tower>().towerData.Range, this.GetComponent<Tower>().towerData.Range, this.GetComponent<Tower>().towerData.Range);
        }
    }

    public void EssenceHoverOff()
    {
        if (hover)
        {
            Debug.Log("Hover is tuned off");
            hover = false;
        }
    }

    internal void EssenceHoverOn()
    {
        if (!hover)
        {
            Debug.Log("Hover is turned on");
            hover = true;
        }
    }

    public void HideCircle()
    {
        if (circleObjectPrefab != null)
        {
            //TODO: Hide sphere that shows the range of the tower
            circleObjectPrefab.SetActive(false);
        }
        if(rangeObjectPrefab != null)
        {
            rangeObjectPrefab.SetActive(false);
        }
    }
}
