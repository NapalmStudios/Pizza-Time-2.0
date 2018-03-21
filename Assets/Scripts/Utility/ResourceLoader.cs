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
        // -------------- GameObject Variables -------------------- \\
        public GameObject pizzaObj;
        public GameObject sauceObj;
        public GameObject cheeseObj;
        public GameObject roniObj;
        public GameObject baconObj;
        public GameObject pepperObj;
        public GameObject mushObj;
        // -------------------------------------------------------- \\

        // -------------- Base Material Variables ---------------------- \\
        public Material pizzaDoughMaterial;
        public Material sauceMaterial;
        public Material cheeseMaterial;
        public Material roniMaterial;
        public Material baconMaterial;
        public Material peppersMaterial;
        public Material mushMaterial;
        // ------------------------------------------------------------- \\

        // -------------- Two-Topping Material Variables ---------------------- \\
        
        // -------------------------------------------------------------------- \\

        // Loads Game Objects / Materials
        void Start()
        {
            // -------------- Load GameObject Into Variables ---------------------- \\
            pizzaObj = Resources.Load("ToppingPrefabs/Pie2.0") as GameObject;
            sauceObj = Resources.Load("ToppingPrefabs/Sauce2.0") as GameObject;
            cheeseObj = Resources.Load("ToppingPrefabs/Cheese2.0") as GameObject;
            roniObj = Resources.Load("ToppingPrefabs/Pepperoni2.0") as GameObject;
            baconObj = Resources.Load("ToppingPrefabs/Bacon2.0") as GameObject;
            pepperObj = Resources.Load("ToppingPrefabs/Pepper2.0") as GameObject;
            mushObj = Resources.Load("ToppingPrefabs/Mushroom2.0") as GameObject;
            // -------------------------------------------------------------------- \\

            // -------------- Load Materials Into Variables ---------------------- \\
            pizzaDoughMaterial = Resources.Load("ToppingMaterial/Uncooked/Materials/Pizza_Dough") as Material;
            sauceMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Sauce") as Material;
            cheeseMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Cheese") as Material;
            roniMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni") as Material;
            baconMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Bacon") as Material;
            peppersMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Pepper") as Material;
            mushMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Mush") as Material;
            // ------------------------------------------------------------------- \\
        }
    }
}
