using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{
    [SerializeField] GameObject outlineObject;

    public void ShowOutline()
    {
        if (outlineObject != null)
        {
            outlineObject.SetActive(true);
        }


    }
    public void HideOutline()
    {
        if (outlineObject != null)
        {
            outlineObject.SetActive(false);
        }

    }
}
