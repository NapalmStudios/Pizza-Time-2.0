using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    //Should Go Onto Ticket Punch Out Machine
    public class Days : MonoBehaviour
    {
        public int currentDay;
        public int dayTimerAmount;
        public bool outOfTime = false;
        private bool clearSceneOfToppings = false;

        private ResourceLoader resourceLoader;
        private Goal scorer;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            scorer = GameObject.FindObjectOfType<Goal>();
        }

        void Update()
        {
            StartCoroutine(CheckDay());
        }

        /// <summary>
        /// Checks to see if Punch Card Obj has collided
        /// </summary>
        /// <param name="col"></param>
        void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag.Equals(resourceLoader.punchCardObj.tag))
            {
                Destroy(col.gameObject);
                ClockOut();
            }
        }

        /// <summary>
        /// Increases the value of currentDay and resets outOfTime bool
        /// </summary>
        private void ClockOut()
        {
            currentDay++;
            outOfTime = false;
            clearSceneOfToppings = true;
            StartCoroutine(ClearSceneOfToppings());
            scorer.score = 0;
        }

        /// <summary>
        /// Checks Current Day value to see if timer should be enabled
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Timer Based on seconds variable
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        private IEnumerator DayTimer(int seconds)
        {
            while(!outOfTime)
            {
                yield return new WaitForSeconds(seconds);
                outOfTime = true;
            }
            yield return null;
        }

        /// <summary>
        /// Method for Tutorial Levels of the Game
        /// </summary>
        /// <returns></returns>
        private IEnumerator Tutorials()
        {
            if (GameObject.FindObjectsOfType<Ticket>().Length == 0)
            {
                outOfTime = true;
            }
            yield return null;
        }

        /// <summary>
        /// Clears Scene of Toppings at End of Day
        /// </summary>
        /// <returns></returns>
        private IEnumerator ClearSceneOfToppings()
        {
            if(clearSceneOfToppings)
            {
                var pieObjs = GameObject.FindGameObjectsWithTag(resourceLoader.pizzaObj.tag);
                var gfPieObjs = GameObject.FindGameObjectsWithTag(resourceLoader.gfPizzaObj.tag);
                var sauceObjs = GameObject.FindGameObjectsWithTag(resourceLoader.sauceObj.tag);
                var cheeseObjs = GameObject.FindGameObjectsWithTag(resourceLoader.cheeseObj.tag);
                var roniObjs = GameObject.FindGameObjectsWithTag(resourceLoader.roniObj.tag);
                var baconObjs = GameObject.FindGameObjectsWithTag(resourceLoader.baconObj.tag);
                var pepperObjs = GameObject.FindGameObjectsWithTag(resourceLoader.pepperObj.tag);
                var mushObjs = GameObject.FindGameObjectsWithTag(resourceLoader.mushObj.tag);
                DestoryObjects(pieObjs);
                DestoryObjects(gfPieObjs);
                DestoryObjects(sauceObjs);
                DestoryObjects(cheeseObjs);
                DestoryObjects(roniObjs);
                DestoryObjects(baconObjs);
                DestoryObjects(pepperObjs);
                DestoryObjects(mushObjs);
                clearSceneOfToppings = false;
            }
            yield return null;
        }

        /// <summary>
        /// Destorys Specified Gameobjects in given array
        /// </summary>
        /// <param name="objects"></param>
        private void DestoryObjects(GameObject[] objects)
        {
            foreach(GameObject obj in objects)
            {
                Destroy(obj);
            }
        }

    }
}
