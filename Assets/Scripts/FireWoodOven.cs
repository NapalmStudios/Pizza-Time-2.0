using System.Collections;
using UnityEngine;

namespace PizzaTime
{
    public class FireWoodOven : MonoBehaviour
    {
        public float tempature;
        public int upperBoundTemp;
        public int lowerBoundTemp;
        public float tempatureDecreaseSpeed;
        public int logTempIncrease;
        public int CookTime;
        public int BurnTimme;

        private void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {

        }

        private void TempControl()
        {
            tempature -= Time.deltaTime * tempatureDecreaseSpeed;

            if (tempature > upperBoundTemp)
            {

            }
            else if (tempature < lowerBoundTemp)
            {

            }
        }

        private IEnumerator CookPizza(Collision collision)
        {
            if (collision.gameObject.tag == "WoodLog")
            {
                tempature += logTempIncrease;
                Destroy(collision.gameObject, 3f);
            }
            else if (collision.gameObject.GetComponent<Pizza_Controller>() != null)
            {
                /*var timer += Time.deltaTime;
                 * 
                 * if (timer > cookTime && timer < burnTime)
                 * {
                 *      collision.gameObject.GetComponent<Pizza_Controller>().isCooked = true;
                 * } 
                 * else if (timer > burnTime)
                 * {
                 *      collision.gameObject.GetComponent<Pizza_Controller>().isBurnt = true;
                 * }
                 * 
                */
            }
            else
            {
                Destroy(collision.gameObject, 2f);
            }

            return null;
        }
    }       
}
