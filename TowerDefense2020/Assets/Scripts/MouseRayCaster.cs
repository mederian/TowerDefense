using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCaster : MonoBehaviour
{
    [SerializeField] private LayerMask buildLayer;
    [SerializeField] private string hitTag;
    private GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        CheckMousePosition();   
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


    //TODO: Maybe make this a coroutine with yield wait for secons, for 
    public void CheckMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100.0f))
        {
            
            string a = hitInfo.collider.gameObject.name.ToString();

            if (hitInfo.collider.gameObject.tag == hitTag)
            {
                Debug.Log("Hit Target MouseRayCaster script");
                currentTarget = hitInfo.collider.gameObject;
                if(currentTarget.GetComponent<TowerHighlighter>() != null)
                {
                    if (!this.GetComponent<DrainedResources>().IsEmpty)
                    {
                        Debug.Log("Essence is on");
                        currentTarget.GetComponent<TowerHighlighter>().EssenceHoverOn();
                    }
                    else if (this.GetComponent<DrainedResources>().IsEmpty)
                    {
                        Debug.Log("Essence is off");
                        currentTarget.GetComponent<TowerHighlighter>().EssenceHoverOff();
                    }
                }

            }
            else
            {
                if(currentTarget != null)
                {
                    if (currentTarget.GetComponent<TowerHighlighter>() != null)
                    {
                        
                        currentTarget.GetComponent<TowerHighlighter>().EssenceHoverOff();
                    }
                    currentTarget = null;
                }
            }
        }
    }
}
