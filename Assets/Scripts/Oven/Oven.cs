using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class Oven : MonoBehaviour
    {
        public float tempature;
        public float maxTempature;

        private GameObject pizzaOven;
        private ResourceLoader resourceLoader;

        void Start()
        {
            pizzaOven = this.gameObject;
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        }

        void TempatureDecreaseOverTime()
        {

        }

    }
}
