using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public void OnDeselect(Transform selection)
    {
        var circle = selection.GetComponent<TowerHighlighter>();
        if(circle != null)
        {
            circle.HideCircle();
        }
    }

    public void OnSelect(Transform selection)
    {
        var circle = selection.GetComponent<TowerHighlighter>();
        if (circle != null)
        {
            circle.ShowCircle();
        }
    }
}
