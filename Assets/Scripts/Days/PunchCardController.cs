using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaTime
{
    public class PunchCardController : MonoBehaviour
    {
        public Text dayNumberText;
        public Text pizzasMadeNumber;
        public Text score;

        private Goal scorer;
        private Days day;

        void Start()
        {
            scorer = GameObject.FindObjectOfType<Goal>();
            day = GameObject.FindObjectOfType<Days>();
        }

        void Update()
        {
            StartCoroutine(Scoring());
        }

        /// <summary>
        /// Displays Scoring onto the Punch Card Game Object
        /// </summary>
        /// <returns></returns>
        private IEnumerator Scoring()
        {
            dayNumberText.text = "Day: " + day.currentDay;
            pizzasMadeNumber.text = "Pizzas Made: " + scorer.pizzasMade;
            score.text = "Score for the Day: " + scorer.score;
            yield return null;
        }

    }
}