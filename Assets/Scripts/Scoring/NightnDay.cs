using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class NightnDay : MonoBehaviour
    {
        void Update()
        {
            transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);
            transform.LookAt(Vector3.zero);
        }
    }
}