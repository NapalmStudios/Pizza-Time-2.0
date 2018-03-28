using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class Sauce : MonoBehaviour
    {
        private GameObject sauceBottle;
        private Vector3 bottleFoward;
        // Use this for initialization
        void Start()
        {
            sauceBottle = this.gameObject;
            bottleFoward = sauceBottle.transform.forward;
        }

        //TODO: Add Raycast for Sauce Bottle
    }
}

