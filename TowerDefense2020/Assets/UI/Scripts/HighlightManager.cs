using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Tower";
    private IRayProvider rayProvider;
    private ISelectionResponse selectionResponse;
    private ISelector selector;
    private Transform currentSelection;
    private void Awake()
    {
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();
        selectionResponse = GetComponent<ISelectionResponse>();
    }
    void Update()
    {
        if (currentSelection != null) selectionResponse.OnDeselect(currentSelection);

        selector.Check(rayProvider.CreateRay());
        currentSelection = selector.GetSelection();

        if (currentSelection != null) selectionResponse.OnSelect(currentSelection);
    }
}
