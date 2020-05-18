using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    [SerializeField]
    private float flashTime;

    [SerializeField]
    private Color originalColor;

    [SerializeField]
    private MeshRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        originalColor = renderer.material.color;
    }

    public void FlashRed(){
        Debug.Log("FLASH");
        renderer.material.color = Color.red;
        Invoke("ResetColor", flashTime);

    }

    public void ResetColor()
    {
        renderer.material.color = originalColor;
    }
}
