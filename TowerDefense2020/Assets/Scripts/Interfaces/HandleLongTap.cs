using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleLongTap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDown;
    private float downTime;
    private ButtonDrainResource drainer;

    public void OnPointerDown(PointerEventData eventData)
    {
        this.isDown = true;
        this.downTime = Time.realtimeSinceStartup;
        this.drainer = GetComponent<ButtonDrainResource>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.isDown = false;
    }

    void Update()
    {
        if (!this.isDown) return;
        if(Time.realtimeSinceStartup - this.downTime > 1f)
        {
            //print("Handle long tap");
            //this.isDown = false;

            // DO ButtonDrainEssence
            //drainer.Drain();
        }
    }

}
