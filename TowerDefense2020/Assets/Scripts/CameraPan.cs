using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    private int boundary = 50;
    private int speed = 5;
    int screenWidth;
    int screenHeight;
    [SerializeField] bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Input.mousePosition.x > screenWidth - boundary)
            {
                transform.position += new Vector3((float)speed * Time.deltaTime, 0, 0);

            }
            if (Input.mousePosition.x < boundary)
            {
                transform.position += new Vector3(-(float)speed * Time.deltaTime, 0, 0);

            }

            if (Input.mousePosition.y > screenHeight - boundary)
            {
                transform.position += new Vector3(0, 0, (float)speed * Time.deltaTime);

            }
            if (Input.mousePosition.y < boundary)
            {
                transform.position += new Vector3(0, 0, -(float)speed * Time.deltaTime);

            }
        }

    }
}
