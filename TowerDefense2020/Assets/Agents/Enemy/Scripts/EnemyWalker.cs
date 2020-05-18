using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    private float startSpeed;
    [SerializeField] private float speed = 5.0f; //speed of walker
    [SerializeField] private float minSpeed = 0.15f; //Minimum speed of walker
    private float startRegainSpeedCounter;
    [SerializeField] private float regainSpeedCounter = 10f; //how fast walker regain normal speed
    void Start()
    {
        startSpeed = speed;
        startRegainSpeedCounter = regainSpeedCounter;
    }

    public bool MoveTowards(Vector3 target)
    {
        float distThisFrame = speed * Time.deltaTime;
        Vector3 dir = new Vector3(target.x, this.transform.position.y, target.z) - this.transform.localPosition;
        if (dir.magnitude <= distThisFrame)
        {
            return false;
        }
        else
        {
            if(speed < startSpeed)
            {
                RegainSpeed(0.1f);
            }
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            this.transform.rotation = Quaternion.LookRotation(dir);
            return true;
        }
    }

    public void DecreaseSpeed(float modifier)
    {
        float m = modifier / 10;
        if (speed <= (m + minSpeed))
        {
            minSpeed = .015f;
        }
        else
        {
            speed -= m;
        }
    }
    public void RegainSpeed(float regain)
    {
        if(regainSpeedCounter <= 0)
        {
            regainSpeedCounter = startRegainSpeedCounter;
        }
        else
        {
            regainSpeedCounter -= Time.deltaTime;

            if ((speed + regain) >= startSpeed)
            {
                speed = startSpeed;
                regainSpeedCounter = startRegainSpeedCounter;
            }
            else
            {
                speed += regain;
            }
        }

    }

}
