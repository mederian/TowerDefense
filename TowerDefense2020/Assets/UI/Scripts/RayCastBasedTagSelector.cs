using UnityEngine;

public class RayCastBasedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] public string selectableTag = "Tower";
    public Transform selection;

    public void Check(Ray ray)
    {
        //Debug.Log("Checking with ray");
        selection = null;

        if (Physics.Raycast(ray, out var hit))
        {
          //  Debug.Log("Checking with ray - raycast");
            var targetSelection = hit.transform;
            if (targetSelection.CompareTag(selectableTag))
            {
            //    Debug.Log("Checking with ray, hitted");
                selection = targetSelection;
            }
        }
    }
    public Transform GetSelection()
    {
        return selection;
    }
}