using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public GameObject lastClicked;
    [SerializeField] private LayerMask buildLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse clicked");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildLayer))
            {
                //Debug.Log("Mouse clicked");
                GameObject hitObject = hit.collider.gameObject;
                //This object is clickable
                //Debug.Log(hitObject.name.ToString());
                if(hitObject.GetComponent<Clickable>() != null){
                    //hitObject.GetComponent<Clickable>().ToggleClick();
                    //lastClicked = hitObject;

                    
                    // if it is not the same as last time
                    if(lastClicked != null && lastClicked != hit.collider.gameObject)
                    {
                        //Debug.Log("Not same tower as last click");
                        lastClicked.GetComponentInParent<Clickable>().ToggleOff();
                        hit.collider.GetComponentInParent<Clickable>().ToggleClick();
                    }
                    else if(lastClicked != null && lastClicked == hit.collider.gameObject)
                    {
                        hit.collider.GetComponentInParent<Clickable>().ToggleClick();
                    }
                    lastClicked = hit.collider.gameObject;
                    Debug.Log("Tower has been Clicked!!");
                }
                else
                {
                    //Debug.Log(hitObject.name);
                    if (lastClicked != null)
                    {
                        //Debug.Log("Not same tower as last click");
                        //lastClicked.GetComponentInParent<Clickable>().ToggleOff();
                       
                    }
                    //TODO: need to reset any details
                }
                //Debug.Log("Hitteded - " + t);
            }
        }
        
    }
}
