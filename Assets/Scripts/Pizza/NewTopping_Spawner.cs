using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaTime
{
    public class NewTopping_Spawner : MonoBehaviour
    {
        // ------------------------- Class Variables -------------------------- \\
        public bool reset = false;
        public int maxSauceObjs;
        public int maxCheeseObjs;
        public int maxRoniObjs;
        public int maxBaconObjs;
        public int maxPepperObjs;
        public int maxMushroomObjs;
        public float timeInBetweenPizzaPieSpawns;
        private GameObject pizzaSpawnPosition;
        private GameObject pizzaGFSpawnPosition;
        private GameObject sauceSpawnPosition;
        private GameObject cheeseSpawnPosition;
        private GameObject roniSpawnPosition;
        private GameObject baconSpawnPosition;
        private GameObject pepperSpawnPosition;
        private GameObject mushSpawnPosition;
        private GameObject woodSpawnPosition;
        private GameObject pizzaObjForSpawner;
        private GameObject gfPizzaObjForSpawner;
        private GameObject sauceObjForSpawner;
        private GameObject cheeseObjForSpawner;
        private GameObject roniObjForSpawner;
        private GameObject baconObjForSpawner;
        private GameObject pepperObjForSpawner;
        private GameObject mushObjForSpawner;
        private GameObject woodObjForSpawner;
        private ResourceLoader resourceLoader;
        private Days days;
        private GameObject[] sauceObjects;
        private GameObject[] cheeseObjects;
        private GameObject[] roniObjects;
        private GameObject[] baconObjects;
        private GameObject[] pepperObjects;
        private GameObject[] mushroomObjects;
        // -------------------------------------------------------------------- \\

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            days = GameObject.FindObjectOfType<Days>();
            // ------------------- Topping Object Initalization ------------------------ \\
            pizzaObjForSpawner = resourceLoader.pizzaObj;
            gfPizzaObjForSpawner = resourceLoader.gfPizzaObj;
            sauceObjForSpawner = resourceLoader.sauceObj;
            cheeseObjForSpawner = resourceLoader.cheeseObj;
            roniObjForSpawner = resourceLoader.roniObj;
            baconObjForSpawner = resourceLoader.baconObj;
            pepperObjForSpawner = resourceLoader.pepperObj;
            mushObjForSpawner = resourceLoader.mushObj;
            woodObjForSpawner = resourceLoader.woodObj;
            // ------------------------------------------------------------------------- \\

            // ------------------- Topping Spawn Initalization ------------------------- \\
            pizzaSpawnPosition = GameObject.Find("DoughSpawn");
            pizzaGFSpawnPosition = GameObject.Find("Gf_Dough_Spawn");
            sauceSpawnPosition = GameObject.Find("SauceSpawn");
            cheeseSpawnPosition = GameObject.Find("CheeseSpawn");
            roniSpawnPosition = GameObject.Find("RoniSpawn");
            baconSpawnPosition = GameObject.Find("BaconSpawn");
            pepperSpawnPosition = GameObject.Find("PepperSpawn");
            mushSpawnPosition = GameObject.Find("MushroomSpawn");
            woodSpawnPosition = GameObject.Find("WoodSpawn");
            // ------------------------------------------------------------------------- \\

            sauceObjects = new GameObject[maxSauceObjs];
            cheeseObjects = new GameObject[maxCheeseObjs];
            roniObjects = new GameObject[maxRoniObjs];
            baconObjects = new GameObject[maxBaconObjs];
            pepperObjects = new GameObject[maxPepperObjs];
            mushroomObjects = new GameObject[maxMushroomObjs];
        }

        void Update()
        {
            StartCoroutine(FindToppings());
        }

        /// <summary>
        /// Spawn Trigger Collisions
        /// </summary>
        /// <param name="col"></param>
        private void OnCollisionEnter(Collision col)
        {
            GameObject trigger = col.gameObject;
            if (trigger.tag.Equals(resourceLoader.pieSpawnTrigger.tag))
            {
                Instantiate(pizzaObjForSpawner, pizzaSpawnPosition.transform.position, pizzaSpawnPosition.transform.rotation);
                StartCoroutine(PizzaWait());
            }
            //else if (trigger.tag.Equals(resourceLoader.glutenFreeSpawnTrigger.tag))
            //{
            //    Instantiate(gfPizzaObjForSpawner, pizzaGFSpawnPosition.transform.position, pizzaGFSpawnPosition.transform.rotation);
            //    StartCoroutine(PizzaWait());
            //}
            else if (trigger.tag.Equals(resourceLoader.toppingSpawnTrigger.tag))
            {
                MechanicsSelector();
            }
            //else if(trigger.tag.Equals(resourceLoader.woodSpawnTrigger.tag) && days.currentDay >= 5)
            //{
            //    Instantiate(woodObjForSpawner, woodSpawnPosition.transform.position, woodSpawnPosition.transform.rotation);
            //}
            else if(trigger.tag.Equals(resourceLoader.resetTrigger.tag))
            {
                SceneManager.LoadScene("Level_GreyBox");
            }
        }

        /// <summary>
        /// Finds all toppings with in the Scene
        /// </summary>
        /// <returns></returns>
        private IEnumerator FindToppings()
        {
            sauceObjects = GameObject.FindGameObjectsWithTag(resourceLoader.sauceObj.tag);
            cheeseObjects = GameObject.FindGameObjectsWithTag(resourceLoader.cheeseObj.tag);
            roniObjects = GameObject.FindGameObjectsWithTag(resourceLoader.roniObj.tag);
            baconObjects = GameObject.FindGameObjectsWithTag(resourceLoader.baconObj.tag);
            pepperObjects = GameObject.FindGameObjectsWithTag(resourceLoader.pepperObj.tag);
            mushroomObjects = GameObject.FindGameObjectsWithTag(resourceLoader.mushObj.tag);
            yield return null;
        }

        /// <summary>
        /// Waits For Set amount of seconds
        /// </summary>
        /// <returns></returns>
        public IEnumerator PizzaWait()
        {
            yield return new WaitForSeconds(timeInBetweenPizzaPieSpawns);
        }

        /// <summary>
        /// Spawns Toppings for the Specified max amount
        /// </summary>
        /// <param name="toppingArray">Topping Array</param>
        /// <param name="topping">Topping GameObject to Spawn</param>
        /// <param name="toppingSpawner">Topping Spawn Location</param>
        /// <param name="maxToppingAmount">Max Amount of Toppings to Spawn</param>
        private void SpawnTopping(GameObject[] toppingArray, GameObject topping, GameObject toppingSpawner, int maxToppingAmount)
        {
            for(int i = 0; i < toppingArray.Length; i++)
            {
                Destroy(toppingArray[i]);
            }
            for(int z = 0; z < maxToppingAmount; z++)
            {
                Instantiate(topping, toppingSpawner.transform.position, toppingSpawner.transform.rotation);
            }
        }

        /// <summary>
        /// Selects the Available Mechanics for Pizzas for the Days
        /// </summary>
        private void MechanicsSelector()
        {
            switch(days.currentDay)
            {
                //Day 1
                case 0:
                    SpawnTopping(sauceObjects, sauceObjForSpawner, sauceSpawnPosition, maxSauceObjs);
                    SpawnTopping(cheeseObjects, cheeseObjForSpawner, cheeseSpawnPosition, maxCheeseObjs);
                    break;
                //Day 2 and Up
                default:
                    SpawnTopping(sauceObjects, sauceObjForSpawner, sauceSpawnPosition, maxSauceObjs);
                    SpawnTopping(cheeseObjects, cheeseObjForSpawner, cheeseSpawnPosition, maxCheeseObjs);
                    SpawnTopping(roniObjects, roniObjForSpawner, roniSpawnPosition, maxRoniObjs);
                    SpawnTopping(baconObjects, baconObjForSpawner, baconSpawnPosition, maxBaconObjs);
                    SpawnTopping(pepperObjects, pepperObjForSpawner, pepperSpawnPosition, maxPepperObjs);
                    SpawnTopping(mushroomObjects, mushObjForSpawner, mushSpawnPosition, maxMushroomObjs);
                    break;
            }
        }

        //NOT SURE IF WILL BE NEEDED
        //    if (coll.tag == "button")
        //    {
        //        SceneManager.LoadScene("Level_GreyBox");
        //    }
        //    if (coll.tag == "reset")
        //    {
        //        dSceneManager.LoadScene("Level_GreyBox");
        //    }
        //}
    }
}