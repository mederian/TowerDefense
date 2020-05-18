using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCaster : MonoBehaviour
{
    [SerializeField] private LayerMask buildLayer;
    [SerializeField] private string hitTag;
    private GameObject currentTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    public void CheckMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100.0f))
        {
            
            string a = hitInfo.collider.gameObject.name.ToString();
            //Debug.Log("raycast hit : : " + a);

            if (hitInfo.collider.gameObject.tag == hitTag)
            {
                Debug.Log("Hit Target MouseRayCaster script");
                currentTarget = hitInfo.collider.gameObject;
            }
            else
            {
                currentTarget = null;
            }


            //rayedObject = hitInfo.collider.gameObject.tag;
            //Debug.Log("hitinopoint: " + m.ToString());
            //Debug.Log("Tagged as: " + rayedObject);
        }

        
    }
}
