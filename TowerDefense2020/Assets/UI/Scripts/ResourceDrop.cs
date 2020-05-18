using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script will drop resources when correct target is under the mousepointer
public class ResourceDrop : MonoBehaviour
{
    MouseRayCaster mouseRayCaster;

    // Start is called before the first frame update
    void Start()
    {
        mouseRayCaster = GetComponent<MouseRayCaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(mouseRayCaster.GetCurrentTarget() != null)
            {
                List<Resource> res = this.GetComponent<DrainedResources>().GetResources();
                mouseRayCaster.GetCurrentTarget().GetComponentInParent<IHandleBuff>().RecieveBuff(res);
                this.GetComponent<DrainedResources>().UpdateText();
            }
        }
    }
}
