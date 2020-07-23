using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHighlighter : MonoBehaviour
{
    [SerializeField] private GameObject highlightObjectPrefab;
    [SerializeField] private GameObject rangeObjectPrefab;
    [SerializeField] private Material selectedMaterial;
    private Material originalMaterial;
    private bool hover = false;
    private bool isActive = false;


    void Start()
    {
        hover = false;
        if (highlightObjectPrefab != null)
        {
            HideCircle();
            isActive = false;
            highlightObjectPrefab.GetComponent<Renderer>().material = selectedMaterial;

        }
        if(rangeObjectPrefab != null)
        {
            rangeObjectPrefab.transform.localScale = new Vector3(this.GetComponent<Tower>().towerData.Range, this.GetComponent<Tower>().towerData.Range, this.GetComponent<Tower>().towerData.Range);
        }
    }
    public void ShowCircle()
    {
        if (highlightObjectPrefab != null)
        {
            //TODO: Show sphere that shows the range of the tower
            highlightObjectPrefab.SetActive(true);
            isActive = true;
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

    private void RotateObject()
    {
        highlightObjectPrefab.transform.Rotate(0, 4f, 0);
    }


    public void HideCircle()
    {
        if (highlightObjectPrefab != null)
        {
            //TODO: Hide sphere that shows the range of the tower
            highlightObjectPrefab.SetActive(false);
            isActive = false;
        }
        if(rangeObjectPrefab != null)
        {
            rangeObjectPrefab.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        Debug.Log("hover is: " + hover.ToString() + " isActive is: " + isActive.ToString());
        if (hover && isActive)
        {
            RotateObject();
        }
    }
}
