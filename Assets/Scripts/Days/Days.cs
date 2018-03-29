using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class Days : MonoBehaviour
    {
        public int currentDay;
        public int dayTimerAmount;
        public bool outOfTime = false;

        void Start()
        {
            currentDay = 0;
        }

        void Update()
        {
            StartCoroutine(CheckDay());
        }
        /*
         * Day 1: Cheese Pizzas
         * Day 2: 1-Topping Pizzas
         * Day 3: 2-Topping Pizzas
         * Day 4: 3-Topping Pizzas
         * Day 5: Oven Mechanics Introduced
         */
        //TODO: Tickets will need to spawn based on day value
        //TODO: Change Day with Recipt Punch Card which will collide with an object
        //TODO: Keep Oven Off Until Day 5 which Mechanic is Introduced (keep wood from spawning)


        //Increases the value of currentDay and resets outOfTime bool
        private void ClockOut()
        {
            currentDay++;
            outOfTime = false;
        }

        //Checks Current Day value to see if timer should be enabled
        private IEnumerator CheckDay()
        {
            if(currentDay >= 5)
            {
                StartCoroutine(DayTimer(dayTimerAmount));
                outOfTime = true;
            }
            yield return null;
        }

        //Timer Based on seconds variable
        private IEnumerator DayTimer(int seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

    }
}
