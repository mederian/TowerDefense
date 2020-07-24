using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCaster : MonoBehaviour
{
    [SerializeField] private LayerMask buildLayer;
    [SerializeField] private string hitTag;
    WaitForSeconds waitBetweenMouseCheck = new WaitForSeconds(0.1f);
    private GameObject currentTarget;
    Ray ray;
    RaycastHit hitInfo;


    private void Start()
    {
        StartCoroutine(CheckMousePosition());
    }

    public GameObject GetCurrentTarget()
    {
        if(currentTarget == null)
        {
            return null;
        }
        else
        {
            return currentTarget;
        }
    }

    IEnumerator CheckMousePosition()
    {

        while (true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo, 100.0f))
            {
                if (hitInfo.collider.gameObject.tag == hitTag)
                {
                    currentTarget = hitInfo.collider.gameObject;
                    if (currentTarget.GetComponent<TowerHighlighter>() != null)
                    {
                        if (!this.GetComponent<DrainedResources>().IsEmpty)
                        {
                            currentTarget.GetComponent<TowerHighlighter>().EssenceHoverOn();
                        }
                        else if (this.GetComponent<DrainedResources>().IsEmpty)
                        {
                            currentTarget.GetComponent<TowerHighlighter>().EssenceHoverOff();
                        }
                    }
                }
                else
                {
                    if (currentTarget != null)
                    {
                        if (currentTarget.GetComponent<TowerHighlighter>() != null)
                        {
                            currentTarget.GetComponent<TowerHighlighter>().EssenceHoverOff();
                        }
                        currentTarget = null;
                    }
                }
            }
            yield return waitBetweenMouseCheck;
        }
    }
}
