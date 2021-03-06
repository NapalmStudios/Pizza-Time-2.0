﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class PrintScore : MonoBehaviour
    {
        private Days days;
        private ResourceLoader resourceLoader;
        private GameObject printerPunchCardSpawn;
        private GameObject punchCardObjForSpawner;
        private bool punchCardSpawned = false;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            days = GameObject.FindObjectOfType<Days>();
            printerPunchCardSpawn = GameObject.Find("Punch_Card_Spawn");
            punchCardObjForSpawner = resourceLoader.punchCardObj;
        }

        void Update()
        {
            StartCoroutine(PrintPunchTicket());
            StartCoroutine(CheckForPunchCard());
        }

        /// <summary>
        /// Print Punch Ticket at End of Day
        /// </summary>
        /// <returns></returns>
        private IEnumerator PrintPunchTicket()
        {
            while(days.outOfTime && !punchCardSpawned)
            {
                //Call punch card spawn
                punchCardSpawned = true;
                Instantiate(punchCardObjForSpawner, printerPunchCardSpawn.transform.position, printerPunchCardSpawn.transform.rotation);
                yield return null;
                
            }
            yield return null;
        }

        /// <summary>
        /// Checks to See if there is a Punch Card within the level
        /// </summary>
        /// <returns></returns>
        private IEnumerator CheckForPunchCard()
        {
            if(GameObject.FindGameObjectWithTag(resourceLoader.punchCardObj.tag))
            {
                punchCardSpawned = true;
            }
            else
            {
                punchCardSpawned = false;
            }
            yield return null;
        }
    }
}