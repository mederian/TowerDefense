using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorHighlighter : MonoBehaviour
{
    [SerializeField] GameObject selector;

    public void ShowSelector()
    {
        selector.SetActive(true);
    }
    public void HideSelector()
    {
        selector.SetActive(false);
    }
}