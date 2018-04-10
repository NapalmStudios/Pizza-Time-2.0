using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightnDay : MonoBehaviour
{
    public bool night;
    public bool day;
    public int nightTimeStart;
    public int dayTimeStart;
    private int timer;

    void Update()
    {
        timer++;

        if (timer >= nightTimeStart)
        {
            night = true;
        }

        if (timer >= dayTimeStart)
        {
            day = true;
        }

        if (night == true)
        {
            if (transform.position.y >= -40)
            {
                transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);
                transform.LookAt(Vector3.zero);
            }
        }

        if (day == true)
        {
            if (transform.position.y <= 50)
            {
                transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);
                transform.LookAt(Vector3.zero);
                timer = 0;
            }
        }
    }
}
