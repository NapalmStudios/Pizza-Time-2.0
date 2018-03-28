﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
namespace PizzaTime
{
    public enum PIZZA
    {
        Dough,
        Sauce,
        Cheese,
        Roni,
        Bacon,
        Peppers,
        Mushrooms,
        RoniBacon,
        RoniPepper,
        RoniMush,
        PeppersBacon,
        PeppersMush,
        BaconMush,
        RoniPeppersBacon,
        PeppersBaconMush,
        RoniBaconMush,
        RoniPeppersMush,
        TheWorks
    };
    
    public class Pizza_Controller : MonoBehaviour
    {
        // ----------------- Class Variables ---------------- \\
        public float minCookTempature;
        public float midCookTempature;
        public float totalCookTime;
        public float burnTime;
        public float initialLowestCookSpeedValue;
        public float timeBeforeDirty;
        public bool isCooked = false;
        public bool isDirty = false;
        public GameObject pizza;
        public Pizza_Controller pizzaController;
        public Material activePizzaTexture;

        private float cookTime;
        private float cookingSpeed;
        private bool isCooking = false;
        private float maxCookTempature;
        private bool onOven = false;

        private Material currentPizzaTexture;
        private PIZZA pizzaCase;
        private PIZZA toppingCase;
        private ResourceLoader resourceLoader;
        // -------------------------------------------------- \\
        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();

            maxCookTempature = GameObject.FindObjectOfType<Oven>().maxTempature;
            pizzaController = this;
            activePizzaTexture = resourceLoader.pizzaDoughMaterial;
        }
        public void Update()
        {
            pizza.GetComponent<Renderer>().material = activePizzaTexture;
            StartCoroutine(Cooking(isCooking, cookingSpeed));
        }

        private void OnCollisionEnter(Collision col)
        {
            GameObject topping = col.gameObject;
            currentPizzaTexture = pizza.GetComponent<Renderer>().sharedMaterial;

            //Looks at the current pizza texture and then sets pizzaCase to the correct value
            if (currentPizzaTexture.Equals(resourceLoader.pizzaDoughMaterial))
            {
                pizzaCase = PIZZA.Dough;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.sauceMaterial))
            {
                pizzaCase = PIZZA.Sauce;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.cheeseMaterial))
            {
                pizzaCase = PIZZA.Cheese;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniMaterial))
            {
                pizzaCase = PIZZA.Roni;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.baconMaterial))
            {
                pizzaCase = PIZZA.Bacon;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.peppersMaterial))
            {
                pizzaCase = PIZZA.Peppers;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.mushMaterial))
            {
                pizzaCase = PIZZA.Mushrooms;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndBaconMaterial))
            {
                pizzaCase = PIZZA.RoniBacon;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndPeppersMaterial))
            {
                pizzaCase = PIZZA.RoniPepper;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.peppersAndBaconMaterial))
            {
                pizzaCase = PIZZA.PeppersBacon;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.peppersAndMushMaterial))
            {
                pizzaCase = PIZZA.PeppersMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.baconAndMushMaterial))
            {
                pizzaCase = PIZZA.BaconMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndBaconAndPeppersMaterial))
            {
                pizzaCase = PIZZA.RoniPeppersBacon;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.mushAndBaconAndPeppers))
            {
                pizzaCase = PIZZA.PeppersBaconMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndBaconAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniBaconMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndPeppersAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniPeppersMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.theWorksMaterial))
            {
                pizzaCase = PIZZA.TheWorks;
            }

            switch(pizzaCase)
            {
                case PIZZA.Dough:
                    PizzaAddSauceTopping(topping);
                    break;
                case PIZZA.Sauce:
                    PizzaAddCheeseTopping(topping);
                    break;
                default:
                    ToppingSelector(topping);
                    break;
            }

        }


        void OnTriggerStay(Collider col)
        {
            GameObject objectPizzaIsTouching = col.gameObject;
            if (objectPizzaIsTouching.tag.Equals(resourceLoader.ovenObj.tag))
            {
                onOven = true;
                Cook(objectPizzaIsTouching.GetComponent<Oven>().tempature);
            }
            else if(objectPizzaIsTouching.tag.Equals(resourceLoader.floorObj.tag))
            {
                StartCoroutine(PizzaWait());
                isDirty = true;
            }
            else if(objectPizzaIsTouching.tag.Equals(resourceLoader.trashCanObj.tag))
            {
                Destroy(this.gameObject);
            }
            else
            {
                onOven = false;
                isDirty = false;
            }
        }

        /// <summary>
        /// Selects the Topping Case to enable putting a topping onto a pizza
        /// </summary>
        /// <param name="topping"></param>
        private void ToppingSelector(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.roniObj.tag))
            {
                toppingCase = PIZZA.Roni;
            }
            else if (topping.tag.Equals(resourceLoader.baconObj.tag))
            {
                toppingCase = PIZZA.Bacon;
            }
            else if (topping.tag.Equals(resourceLoader.pepperObj.tag))
            {
                toppingCase = PIZZA.Peppers;
            }
            else if (topping.tag.Equals(resourceLoader.mushObj.tag))
            {
                toppingCase = PIZZA.Mushrooms;
            }

            switch (toppingCase)
            {
                case PIZZA.Roni:
                    PizzaAddRoniTopping(topping);
                    break;
                case PIZZA.Bacon:
                    PizzaAddBaconTopping(topping);
                    break;
                case PIZZA.Peppers:
                    PizzaAddPeppersTopping(topping);
                    break;
                case PIZZA.Mushrooms:
                    PizzaAddMushroomsTopping(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// If-Else Statment for Beginning the Pizza with Sauce
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddSauceTopping(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.sauceObj.tag))
            {
                activePizzaTexture = resourceLoader.sauceMaterial;
                Destroy(topping);
            }
        }

        /// <summary>
        /// If-Else Statement for Adding Cheese Before Able to Add Other Toppings
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddCheeseTopping(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.cheeseObj.tag))
            {
                activePizzaTexture = resourceLoader.cheeseMaterial;
                Destroy(topping);
            }
        }

        /// <summary>
        /// Adds Roni To the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddRoniTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.roniMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.roniAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.roniAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.roniAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersMush:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.BaconMush:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBaconMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds Bacon to the Crrent Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddBaconTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.baconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.peppersAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.baconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniMush:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPepper: 
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersMush:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPeppersMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds Peppers to the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddPeppersTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.peppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.peppersAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.peppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniMush:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.BaconMush:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBaconMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Adds Mushrooms to the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddMushroomsTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.mushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.baconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.peppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPepper:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBacon:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPeppersBacon:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Changes pizza to cooked material when cooked
        /// </summary>
        /// <param name="cooked"></param>
        private void CookedPizzas(bool cooked)
        {
            if(cooked)
            {
                switch (pizzaCase)
                {
                    case PIZZA.Dough:
                        activePizzaTexture = resourceLoader.cookedDoughMaterial;
                        break;
                    case PIZZA.Cheese:
                        activePizzaTexture = resourceLoader.cookedCheeseMaterial;
                        break;
                    case PIZZA.Roni:
                        activePizzaTexture = resourceLoader.cookedRoniMaterial;
                        break;
                    case PIZZA.Bacon:
                        activePizzaTexture = resourceLoader.cookedBaconMaterial;
                        break;
                    case PIZZA.Peppers:
                        activePizzaTexture = resourceLoader.cookedPeppersMaterial;
                        break;
                    case PIZZA.Mushrooms:
                        activePizzaTexture = resourceLoader.cookedMushMaterial;
                        break;
                    case PIZZA.RoniPepper:
                        activePizzaTexture = resourceLoader.cookedRoniAndPeppersMaterial;
                        break;
                    case PIZZA.RoniBacon:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconMaterial;
                        break;
                    case PIZZA.RoniMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndMushMaterial;
                        break;
                    case PIZZA.PeppersBacon:
                        activePizzaTexture = resourceLoader.cookedPeppersAndBaconMaterial;
                        break;
                    case PIZZA.PeppersMush:
                        activePizzaTexture = resourceLoader.cookedPeppersAndMushMaterial;
                        break;
                    case PIZZA.BaconMush:
                        activePizzaTexture = resourceLoader.cookedBaconAndMushMaterial;
                        break;
                    case PIZZA.RoniPeppersBacon:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconAndPeppersMaterial;
                        break;
                    case PIZZA.PeppersBaconMush:
                        activePizzaTexture = resourceLoader.cookedMushAndBaconAndPeppersMaterial;
                        break;
                    case PIZZA.RoniBaconMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconAndMushMaterial;
                        break;
                    case PIZZA.RoniPeppersMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndPeppersAndMushMaterial;
                        break;
                    default:
                        activePizzaTexture = resourceLoader.cookedTheWorksMaterial;
                        break;
                }
            }
        }

        /// <summary>
        /// Timer for Determining whether the pizza is cooked/burned
        /// </summary>
        /// <param name="currentOvenTempature">Current Tempature of the Oven</param>
        private void Cook(float currentOvenTempature)
        {
            //Sets isCooking bool and cookingSpeed based upon the current oven tempature
            if (currentOvenTempature < minCookTempature)
            {
                isCooking = false;
            }
            else if(currentOvenTempature >= minCookTempature && currentOvenTempature < midCookTempature)
            {
                isCooking = true;
                cookingSpeed = SetCookingSpeed(currentOvenTempature, minCookTempature, midCookTempature, initialLowestCookSpeedValue);
            }
            else if(currentOvenTempature >= midCookTempature && currentOvenTempature < maxCookTempature)
            {
                isCooking = true;
                cookingSpeed = SetCookingSpeed(currentOvenTempature, midCookTempature, maxCookTempature, initialLowestCookSpeedValue + 1);
            }
            else
            {
                isCooking = true;
                cookingSpeed = initialLowestCookSpeedValue + 2;
            }
        }

        /// <summary>
        /// Sets the Cooking Speed to the correct multiplier base upon the tempatures set for tempOne and tempTwo and the value of currentOvenTempature
        /// </summary>
        /// <param name="currentOvenTempature">Current Temapture of the Oven</param>
        /// <param name="tempatureOne">Min or Mid tempature value</param>
        /// <param name="tempatureTwo">Mid or Max tempature value</param>
        /// <param name="startingValue">Starting cooking speed multiplier</param>
        /// <returns></returns>
        private float SetCookingSpeed(float currentOvenTempature, float tempatureOne, float tempatureTwo, float startingValue)
        {
            var value = currentOvenTempature - tempatureOne;
            var divder = tempatureTwo - tempatureOne;

            var calculation = startingValue + (value / divder);

            return calculation;
        }

        private IEnumerator Cooking(bool isCooking, float cookingSpeed)
        {
            //Checks isCooking bool to allow cook time to increase when oven tempature is warm enough
            if(isCooking && onOven)
            {
                cookTime += Time.deltaTime;
                if (cookTime >= totalCookTime && cookTime <= totalCookTime + burnTime)
                {
                    isCooked = true;
                    CookedPizzas(isCooked);
                    isCooking = false;
                }
                else if (cookTime >= totalCookTime + burnTime)
                {
                    activePizzaTexture = resourceLoader.cookedBurnt;
                    isCooking = false;
                }
            }
            yield return null;
        }

        public IEnumerator PizzaWait()
        {
            yield return new WaitForSeconds(timeBeforeDirty);
        }
    }
}