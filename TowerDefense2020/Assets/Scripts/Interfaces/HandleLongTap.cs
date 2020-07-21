using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleLongTap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private float initTime;
    private bool isDown;
    private float downTime;
    private ButtonDrainResource drainer;
    private bool t = true;
    private bool f = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        this.isDown = true;
        this.downTime = Time.realtimeSinceStartup;
        
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.isDown = false;
    }

    private void Start()
    {
        if (GetComponent<ButtonDrainResource>() == null)
        {
            Debug.Log("Did not find ButtonDrainResource..");
        }
        else
        {
            drainer = GetComponent<ButtonDrainResource>();
        }
    }

    void Update()
    {
        if (!this.isDown)
        {
            if(drainer != null)
            {
                drainer.DrainToggle(f);

            }
            
        }
        if (this.isDown)
        {
            if (Time.realtimeSinceStartup - this.downTime > initTime)
            {
                //print("Handle long tap");
                //this.isDown = false;
                // DO ButtonDrainEssence
                drainer.DrainToggle(t);
            }
        }
        
    }
}
