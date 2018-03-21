using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    /// <summary>
    /// Used for Loading Game Objects and/or Materials
    /// </summary>
    public class ResourceLoader : MonoBehaviour
    {
        public GameObject pizza;
        public GameObject sauce;
        public GameObject cheese;
        public GameObject roni;
        public GameObject bacon;
        public GameObject pepper;
        public GameObject mush;

        // Loads Game Objects / Materials
        void Start()
        {
            pizza = Resources.Load("Pie2.0") as GameObject;
            sauce = Resources.Load("Sauce2.0") as GameObject;
            cheese = Resources.Load("Cheese2.0") as GameObject;
            roni = Resources.Load("Pepperoni2.0") as GameObject;
            bacon = Resources.Load("Bacon2.0") as GameObject;
            pepper = Resources.Load("Pepper2.0") as GameObject;
            mush = Resources.Load("Mushroom2.0") as GameObject;
        }
    }
}
