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
        //TODO: Change Day with Recipt Punch Card which will collide with an object
        //TODO: Create Punch Card Class

        //Increases the value of currentDay and resets outOfTime bool
        private void ClockOut()
        {
            currentDay++;
            outOfTime = false;
            //Need to add Scene Reset to this function aka clear the scene of all topping objects, pizza objects and **reset score** <- not sure if i save
        }

        //Checks Current Day value to see if timer should be enabled
        private IEnumerator CheckDay()
        {
            if(currentDay >= 5)
            {
                StartCoroutine(DayTimer(dayTimerAmount));
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

    }
}
