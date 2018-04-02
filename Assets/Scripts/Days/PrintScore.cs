using System.Collections;
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


        // Use this for initialization
        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            days = GameObject.FindObjectOfType<Days>();
            printerPunchCardSpawn = GameObject.Find("Punch_Card_Spawn");
            punchCardObjForSpawner = resourceLoader.punchCardObj;
        }

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(PrintPunchTicket());
        }

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
    }
}