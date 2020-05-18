using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSkin : MonoBehaviour
{
    [SerializeField] private Texture normalMatBottom;
    [SerializeField] private Texture noBuildMatBottom;

    private GameObject tower;

    

    public void ChangeToNoBuildMaterial()
    {
        tower.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", noBuildMatBottom);
    }
    public void ChangeToNormalMaterial()
    {
        tower.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", normalMatBottom);
    }

    private void Awake()
    {
        tower = this.gameObject;
    }

}
