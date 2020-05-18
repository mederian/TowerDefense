using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make the object  follow the cursor
public class StickToCursor : MonoBehaviour
{

    //

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<RectTransform>().position = new Vector3(3.0f, 3.0f, 3.0f);
        //this.gameObject.transform.position = new Vector3(3.0f, 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("The cursr pos: " + GetCursorPosition().ToString());
        //Debug.Log("Mouse AT: " + MousePosition().ToString());
        this.GetComponent<Canvas>().transform.position = MousePosition();
    }


    //Returns position of the cursros
    public Vector3 GetCursorPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        //Vector3 x = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 y = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        //Vector3 v = Input.mousePosition;
        return y;
    }
    public Vector3 MousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 m = new Vector3(0, 0, 0);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100.0f))
        {
            m = hitInfo.point;
            //Debug.Log("hitinopoint: " + m.ToString());
            //Debug.Log("Tagged as: " + rayedObject);
        }
        Vector3 x = new Vector3(m.x, 1.0f, m.z);

        return x;
    }
}
