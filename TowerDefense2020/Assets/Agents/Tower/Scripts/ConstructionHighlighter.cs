using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectorHighlighter))]
public class ConstructionHighlighter : MonoBehaviour
{
    [SerializeField] GameObject selector;
    private bool animateConstruction;

    void Update()
    {
        if (animateConstruction)
        {
            selector.transform.Rotate(0, 4f, 0);
        }
    }
    public bool IsAnimateConstruction()
    {
        return animateConstruction;
    }
    public void AnimateConstruction()
    {
        selector.SetActive(true);
        animateConstruction = true;
    }
    public void EndAnimateConstruction()
    {
        selector.SetActive(false);
        animateConstruction = false;
    }
}
