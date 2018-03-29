using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class Days : MonoBehaviour
    {
        public int currentDay;

        void Start()
        {
            currentDay = 0;
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


        //Increases the value of currentDay
        private void ClockOut()
        {
            currentDay++;
        }

    }
}
