﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class Sauce : MonoBehaviour
    {
        private GameObject sauceBottle;
        private Vector3 bottleForward;
        private ResourceLoader resourceLoader;
        private Transform test;
        // Use this for initialization
        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            sauceBottle = this.gameObject;
        }

        void Update()
        {
            //SquirtSauce();
        }

        public void SquirtSauce()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.gameObject.tag.Equals(resourceLoader.pizzaObj.tag))
                {
                    var pizzaControl = hit.collider.gameObject.GetComponent<Pizza_Controller>();
                    if (!pizzaControl.hasSauce)
                    {
                        Fabric.EventManager.Instance.PostEvent("Diegetic - Pizza Sauce", gameObject);
                        pizzaControl.hasSauce = true;
                    }
                }
            }
        }
    }
}