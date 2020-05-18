using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private float direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
    }
}
