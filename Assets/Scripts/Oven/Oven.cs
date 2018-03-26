﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class Oven : MonoBehaviour
    {
        public float tempature;
        public float tempatureDecrease;
        public float maxTempature;
        public float decreaseHeatTime;
        public bool newLogAdded = false;

        private GameObject pizzaOven;
        private ResourceLoader resourceLoader;
        private float heatTime = 0;

        void Start()
        {
            pizzaOven = this.gameObject;
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        }

        void Update()
        {
            StartCoroutine(TempatureDecreaseOverTime());
        }

        /// <summary>
        /// Decreases the Oven tempature after a certain amount of time has passed
        /// </summary>
        private IEnumerator TempatureDecreaseOverTime()
        {
            heatTime += Time.deltaTime;
            //Decreases the tempature of the oven over time
            if (heatTime > decreaseHeatTime && tempature != 0)
            {
                tempature -= tempatureDecrease;
                heatTime = 0;
            }
            //Reset the warmTime if a new log is added
            if (newLogAdded)
            {
                heatTime = 0;
                newLogAdded = false;
            }
            yield return null;
        }

    }
}