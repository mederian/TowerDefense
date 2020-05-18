using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
}
