using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    float zoomAmount = 0;
    float maxToClamp = 10.0f;
    float rotSpeed = 10.0f;
    [SerializeField] bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            zoomAmount += Input.GetAxis("Mouse ScrollWheel");
            zoomAmount = Mathf.Clamp(zoomAmount, -maxToClamp, maxToClamp);
            float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), maxToClamp - Mathf.Abs(zoomAmount));
            this.transform.Translate(0, 0, translate * rotSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

        }
    }
}
