using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    //Should Go Onto Ticket Punch Out
    public class Days : MonoBehaviour
    {
        public int currentDay;
        public int dayTimerAmount;
        public bool outOfTime = false;
        private bool clearSceneOfToppings = false;

        private ResourceLoader resourceLoader;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        }

        void Update()
        {
            StartCoroutine(CheckDay());
        }

        void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag.Equals(resourceLoader.punchCardObj.tag))
            {
                Destroy(col.gameObject);
                ClockOut();
            }
        }
        /*
         * Day 1: Cheese Pizzas
         * Day 2: 1-Topping Pizzas
         * Day 3: 2-Topping Pizzas
         * Day 4: 3-Topping Pizzas
         * Day 5: Oven Mechanics Introduced
         */
        //TODO: Certain Tickets will need to spawn based on day value

        //Increases the value of currentDay and resets outOfTime bool
        private void ClockOut()
        {
            currentDay++;
            outOfTime = false;
            clearSceneOfToppings = true;
            //**reset score** <- not sure if i save
            StartCoroutine(ClearSceneOfToppings());
            clearSceneOfToppings = false;
        }

        //Checks Current Day value to see if timer should be enabled
        private IEnumerator CheckDay()
        {
            if(currentDay >= 5)
            {
                StartCoroutine(DayTimer(dayTimerAmount));
            }
            else
            {
                StartCoroutine(Tutorials());
            }
            yield return null;
        }

        //Timer Based on seconds variable
        private IEnumerator DayTimer(int seconds)
        {
            while(!outOfTime)
            {
                yield return new WaitForSeconds(seconds);
                outOfTime = true;
            }
            yield return null;
        }

        private IEnumerator Tutorials()
        {
            //Should Change Out of Time in Tutorials when all tickets have despawned
            if (GameObject.FindObjectsOfType<Ticket>().Length == 0)
            {
                outOfTime = true;
            }
            yield return null;
        }

        //Clears Scene of Toppings at End of Day
        private IEnumerator ClearSceneOfToppings()
        {
            if(clearSceneOfToppings)
            {
                var sauceObjs = GameObject.FindGameObjectsWithTag(resourceLoader.sauceObj.tag);
                var cheeseObjs = GameObject.FindGameObjectsWithTag(resourceLoader.cheeseObj.tag);
                var roniObjs = GameObject.FindGameObjectsWithTag(resourceLoader.roniObj.tag);
                var baconObjs = GameObject.FindGameObjectsWithTag(resourceLoader.baconObj.tag);
                var pepperObjs = GameObject.FindGameObjectsWithTag(resourceLoader.pepperObj.tag);
                var mushObjs = GameObject.FindGameObjectsWithTag(resourceLoader.mushObj.tag);
                DestoryObjects(sauceObjs);
                DestoryObjects(cheeseObjs);
                DestoryObjects(roniObjs);
                DestoryObjects(baconObjs);
                DestoryObjects(pepperObjs);
                DestoryObjects(mushObjs);
            }
            yield return null;
        }

        //Destorys Specified Gameobjects in given array
        private void DestoryObjects(GameObject[] objects)
        {
            foreach(GameObject obj in objects)
            {
                Destroy(obj);
            }
        }

    }
}
