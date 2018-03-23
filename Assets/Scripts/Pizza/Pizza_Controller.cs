using System.Collections;
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
        RoniPeppersMush
    };
    
    // TODO: Refactor in a way that it could be expaneded later
    public class Pizza_Controller : MonoBehaviour
    {
        public float cookTime = 0;
        public float doneTime = 10;
        public float burntTime = 20;
        public bool isCooked = false;
        public bool isBurned = false;

        public Pizza_Controller pizzaController;

        public Material activePizzaTexture;
        private Material doughMaterialForObj;
        private Material sauceMaterialForObj;
        private Material cheeseMaterialForObj;
        private Material roniMaterialForObj;
        private Material peppersMaterialForObj;
        private Material mushroomsMaterialForObj;
        private Material baconMaterialForObj;
        private Material roniAndBaconMaterialForObj;
        private Material roniAndPeppersMaterialForObj;
        private Material roniAndMushMaterialForObj;
        private Material peppersAndMushMaterialForObj;
        private Material peppersAndBaconMaterialForObj;
        private Material baconAndMushMaterialForObj;
        private Material roniAndBaconAndPeppersMaterialForObj;
        private Material roniAndBaconAndMushMaterialForObj;
        private Material roniAndPeppersAndMushMaterialForObj;
        private Material mushAndBaconAndPeppersMaterialForObj;
        private Material theWorksMaterialForObj;
        private Material cookedDoughMaterialForObj;
        private Material cookedSauceMaterialForObj;
        private Material cookedCheeseMaterialForObj;
        private Material cookedRoniMaterialForObj;
        private Material cookedPeppersMaterialForObj;
        private Material cookedMushroomsMaterialForObj;
        private Material cookedBaconMaterialForObj;
        private Material cookedRoniAndBaconMaterialForObj;
        private Material cookedRoniAndPeppersMaterialForObj;
        private Material cookedRoniAndMushMaterialForObj;
        private Material cookedPeppersAndMushMaterialForObj;
        private Material cookedPeppersAndBaconMaterialForObj;
        private Material cookedBaconAndMushMaterialForObj;
        private Material cookedRoniAndBaconAndPeppersMaterialForObj;
        private Material cookedRoniAndBaconAndMushMaterialForObj;
        private Material cookedRoniAndPeppersAndMushMaterialForObj;
        private Material cookedMushAndBaconAndPeppersMaterialForObj;
        private Material cookedTheWorksMaterialForObj;
        private Material burntMaterialForObj;

        private Material currentPizzaTexture;
        private PIZZA pizzaCase;
        private PIZZA oneToppingCase;

        public GameObject pizza;
        public bool psauce = false;
        public bool pcheese = false;
        public bool proni = false;
        public bool ppeppers = false;
        public bool pmush = false;
        public bool pbacon = false;

        public string pizzatype = "dough";

        private ResourceLoader resourceLoader;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();

            pizzaController = this;
            activePizzaTexture = resourceLoader.pizzaDoughMaterial;
        }
        public void Update()
        {
            pizza.GetComponent<Renderer>().material = activePizzaTexture;
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

            switch(pizzaCase)
            {
                case PIZZA.Dough:
                    pizzaAddSauceTopping(topping);
                    break;
                case PIZZA.Sauce:
                    pizzaAddCheeseTopping(topping);
                    break;
                default:
                    ToppingSelector(topping);
                    break;
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
                oneToppingCase = PIZZA.Roni;
            }
            else if (topping.tag.Equals(resourceLoader.baconObj.tag))
            {
                oneToppingCase = PIZZA.Bacon;
            }
            else if (topping.tag.Equals(resourceLoader.pepperObj.tag))
            {
                oneToppingCase = PIZZA.Peppers;
            }
            else if (topping.tag.Equals(resourceLoader.mushObj.tag))
            {
                oneToppingCase = PIZZA.Mushrooms;
            }

            switch (oneToppingCase)
            {
                case PIZZA.Roni:
                    pizzaAddRoniTopping(topping);
                    break;
                case PIZZA.Bacon:
                    pizzaAddBaconTopping(topping);
                    break;
                case PIZZA.Peppers:
                    pizzaAddPeppersTopping(topping);
                    break;
                case PIZZA.Mushrooms:
                    pizzaAddMushroomsTopping(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// If-Else Statment for Beginning the Pizza with Sauce
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddSauceTopping(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.sauceObj.tag))
            {
                activePizzaTexture = resourceLoader.sauceMaterial;
                Destroy(topping);
            }
            //else if (topping.layer.Equals(resourceLoader.sauceObj.layer))
            //{
            //    Destroy(topping);
            //}
        }

        /// <summary>
        /// If-Else Statement for Adding Cheese Before Able to Add Other Toppings
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddCheeseTopping(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.cheeseObj.tag))
            {
                activePizzaTexture = resourceLoader.cheeseMaterial;
                Destroy(topping);
            }
            //else if(topping.layer.Equals(resourceLoader.cheeseObj.tag))
            //{
            //    Destroy(topping);
            //}
        }

        /// <summary>
        /// Adds Roni To the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddRoniTopping(GameObject topping)
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
        private void pizzaAddBaconTopping(GameObject topping)
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
        private void pizzaAddPeppersTopping(GameObject topping)
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
        private void pizzaAddMushroomsTopping(GameObject topping)
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

        //void OnCollisionEnter(Collision col)
        //{
        //    GameObject other = col.gameObject;
        //    if (isCooked == false)
        //    {
        //        switch (other.tag)
        //        {
        //            case "sauce":
        //                if (psauce != true)
        //                {
        //                    Destroy(other);
        //                    //sauceAuto.objs--;
        //                }
        //                psauce = true;
        //                break;
        //            case "cheese":
        //                if (pcheese != true && psauce == true) Destroy(other);
        //                if (psauce == true)
        //                {
        //                    pcheese = true;
        //                    //cheeseAuto.objs--;
        //                }
        //                break;
        //            case "roni":
        //                if (psauce == true && pcheese == true && proni != true) Destroy(other);
        //                if (psauce == true && pcheese == true)
        //                {
        //                    proni = true;
        //                    //roniAuto.objs--;
        //                }
        //                break;
        //            case "peppers":
        //                if (psauce == true && pcheese == true && ppeppers != true) Destroy(other);
        //                if (psauce == true && pcheese == true)
        //                {
        //                    ppeppers = true;
        //                    //pepperAuto.objs--;
        //                }
        //                break;
        //            case "mushrooms":
        //                if (psauce == true && pcheese == true && pmush != true) Destroy(other);
        //                if (psauce == true && pcheese == true)
        //                {
        //                    pmush = true;
        //                    //mushAuto.objs--;
        //                }
        //                break;
        //            case "bacon":
        //                if (psauce == true && pcheese == true && pbacon != true) Destroy(other);
        //                if (psauce == true && pcheese == true)
        //                {
        //                    pbacon = true;
        //                    //baconAuto.objs--;
        //                }
        //                break;
        //        }
        //        ToppingChange();
        //    }
        //}

        //private void LoadMaterialVars()
        //{
        //    // ------------------------ Base Material Initalization --------------------------- \\
        //    doughMaterialForObj = resourceLoader.pizzaDoughMaterial;
        //    sauceMaterialForObj = resourceLoader.sauceMaterial;
        //    cheeseMaterialForObj = resourceLoader.cheeseMaterial;
        //    roniMaterialForObj = resourceLoader.roniMaterial;
        //    baconMaterialForObj = resourceLoader.baconMaterial;
        //    peppersMaterialForObj = resourceLoader.peppersMaterial;
        //    mushroomsMaterialForObj = resourceLoader.mushMaterial;
        //    burntMaterialForObj = resourceLoader.cookedBurnt;
        //    // -------------------------------------------------------------------------------- \\

        //    // ------------------------ Two-Topping Material Initalization --------------------------- \\
        //    roniAndBaconMaterialForObj = resourceLoader.roniAndBaconMaterial;
        //    roniAndPeppersMaterialForObj = resourceLoader.roniAndPeppersMaterial;
        //    roniAndMushMaterialForObj = resourceLoader.roniAndMushMaterial;
        //    peppersAndMushMaterialForObj = resourceLoader.peppersAndMushMaterial;
        //    peppersAndBaconMaterialForObj = resourceLoader.peppersAndBaconMaterial;
        //    baconAndMushMaterialForObj = resourceLoader.baconAndMushMaterial;
        //    // --------------------------------------------------------------------------------------- \\

        //    // -------------- Three-Topping Material Variables ---------------------------------------- \\
        //    roniAndBaconAndPeppersMaterialForObj = resourceLoader.roniAndBaconAndPeppersMaterial;
        //    roniAndBaconAndMushMaterialForObj = resourceLoader.roniAndBaconAndMushMaterial;
        //    roniAndPeppersAndMushMaterialForObj = resourceLoader.roniAndPeppersAndMushMaterial;
        //    mushAndBaconAndPeppersMaterialForObj = resourceLoader.mushAndBaconAndPeppers;
        //    // ---------------------------------------------------------------------------------------- \\

        //    // -------------- Specialty Material Variables --------------------------- \\
        //    theWorksMaterialForObj = resourceLoader.theWorksMaterial;
        //    // ----------------------------------------------------------------------- \\

        //    // --------------- Cooked Single Topping Material Variables --------------------------------------------- \\
        //    cookedDoughMaterialForObj = resourceLoader.cookedDoughMaterial;
        //    cookedSauceMaterialForObj = resourceLoader.cookedSauceMaterial;
        //    cookedCheeseMaterialForObj = resourceLoader.cookedCheeseMaterial;
        //    cookedRoniMaterialForObj = resourceLoader.cookedRoniMaterial;
        //    cookedBaconMaterialForObj = resourceLoader.cookedBaconMaterial;
        //    cookedPeppersMaterialForObj = resourceLoader.cookedPeppersMaterial;
        //    cookedMushroomsMaterialForObj = resourceLoader.cookedMushMaterial;
        //    // ------------------------------------------------------------------------------------------------------ \\

        //    // --------------- Cooked Two-Topping Material Variables --------------------------------------------- \\
        //    cookedRoniAndBaconMaterialForObj = resourceLoader.cookedRoniAndBaconMaterial;
        //    cookedRoniAndPeppersMaterialForObj = resourceLoader.cookedRoniAndPeppersMaterial;
        //    cookedRoniAndMushMaterialForObj = resourceLoader.cookedRoniAndMushMaterial;
        //    cookedPeppersAndMushMaterialForObj = resourceLoader.cookedPeppersAndMushMaterial;
        //    cookedPeppersAndBaconMaterialForObj = resourceLoader.cookedPeppersAndBaconMaterial;
        //    cookedBaconAndMushMaterialForObj = resourceLoader.cookedBaconAndMushMaterial;
        //    // --------------------------------------------------------------------------------------------------- \\

        //    // --------------- Cooked Three-Topping Material Variables --------------------------------------------- \\
        //    cookedRoniAndBaconAndPeppersMaterialForObj = resourceLoader.cookedRoniAndBaconAndPeppersMaterial;
        //    cookedRoniAndBaconAndMushMaterialForObj = resourceLoader.cookedRoniAndBaconAndMushMaterial;
        //    cookedRoniAndPeppersAndMushMaterialForObj = resourceLoader.cookedRoniAndPeppersAndMushMaterial;
        //    cookedMushAndBaconAndPeppersMaterialForObj = resourceLoader.cookedMushAndBaconAndPeppersMaterial;
        //    // ----------------------------------------------------------------------------------------------------- \\

        //    // -------------- Specialty Material Variables --------------------------- \\
        //    cookedTheWorksMaterialForObj = resourceLoader.theWorksMaterial;
        //    // ----------------------------------------------------------------------- \\
        //}

        //void ToppingChange()
        //{
        //    int caseSwitch = 0;
        //    if (isCooked != true && isBurned != true) caseSwitch = 1;
        //    if (isCooked == true && isBurned != true) caseSwitch = 2;
        //    if (isCooked == true && isBurned == true) caseSwitch = 3;
        //    switch (caseSwitch)
        //    {
        //        case 1:
        //            if (psauce == true && pcheese != true && proni != true && pmush != true && pbacon != true && ppeppers != true)
        //            {
        //                active = sauceMaterialForObj;
        //                //pizzatype = "sauce";
        //            }
        //            else if (psauce == true && pcheese == true && proni != true && pmush != true && pbacon != true && ppeppers != true)
        //            {
        //                active = cheeseMaterialForObj;
        //                //pizzatype = "cheese";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush != true && pbacon != true && ppeppers != true)
        //            {
        //                active = roniMaterialForObj;
        //                //pizzatype = "roni";
        //            }
        //            else if (psauce == true && pcheese == true && ppeppers == true && pmush != true && pbacon != true && proni != true)
        //            {
        //                active = peppersMaterialForObj;
        //                //pizzatype = "peppers";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && proni != true && pbacon != true && ppeppers != true)
        //            {
        //                active = mushroomsMaterialForObj;
        //                //pizzatype = "mushrooms";
        //            }
        //            else if (psauce == true && pcheese == true && pbacon == true && pmush != true && proni != true && ppeppers != true)
        //            {
        //                active = baconMaterialForObj;
        //                //pizzatype = "bacon";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && ppeppers == true && pbacon != true && pmush != true)
        //            {
        //                active = roniAndPeppersMaterialForObj;
        //                //pizzatype = "roniandpeppers";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers != true && pbacon != true)
        //            {
        //                active = roniAndMushMaterialForObj;
        //                //pizzatype = "roniandmush";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pbacon == true && pmush != true && ppeppers != true)
        //            {
        //                active = roniAndBaconMaterialForObj;
        //                //pizzatype = "roniandbacon";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && ppeppers == true && pbacon != true && proni != true)
        //            {
        //                active = peppersAndMushMaterialForObj;
        //                //pizzatype = "peppersandmush";
        //            }
        //            else if (psauce == true && pcheese == true && pbacon == true && ppeppers == true && proni != true && pmush != true)
        //            {
        //                active = peppersAndBaconMaterialForObj;
        //                //pizzatype = "peppersandbacon";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && pbacon == true && proni != true && ppeppers != true)
        //            {
        //                active = baconAndMushMaterialForObj;
        //                //pizzatype = "baconandmush";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pbacon == true && ppeppers == true && pmush != true)
        //            {
        //                active = roniAndBaconAndPeppersMaterialForObj;
        //                //pizzatype = "roniandbaconandpep";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers != true)
        //            {
        //                active = roniAndBaconAndMushMaterialForObj;
        //                //pizzatype = "roniandbaconandmush";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers == true && pbacon != true)
        //            {
        //                active = roniAndPeppersAndMushMaterialForObj;
        //                //pizzatype = "roniandPepandmush";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && pbacon == true && ppeppers == true && proni != true)
        //            {
        //                active = mushAndBaconAndPeppersMaterialForObj;
        //                //pizzatype = "mushandbaconandpep";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers == true)
        //            {
        //                active = theWorksMaterialForObj;
        //                //pizzatype = "theworks";
        //            }
        //            break;
        //        case 2:
        //            if (psauce != true && pcheese != true && proni != true && pmush != true && pbacon != true && ppeppers != true)
        //            {
        //                active = cookedDoughMaterialForObj;
        //            }
        //            else if (psauce == true && pcheese != true && proni != true && pmush != true && pbacon != true && ppeppers != true)
        //            {
        //                active = cookedSauceMaterialForObj;
        //                pizzatype = "sauce";
        //            }
        //            else if (psauce == true && pcheese == true && proni != true && pmush != true && pbacon != true && ppeppers != true)
        //            {
        //                active = cookedCheeseMaterialForObj;
        //                pizzatype = "cheese";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush != true && pbacon != true && ppeppers != true)
        //            {
        //                active = cookedRoniMaterialForObj;
        //                pizzatype = "roni";
        //            }
        //            else if (psauce == true && pcheese == true && ppeppers == true && pmush != true && pbacon != true && proni != true)
        //            {
        //                active = cookedPeppersMaterialForObj;
        //                pizzatype = "peppers";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && proni != true && pbacon != true && ppeppers != true)
        //            {
        //                active = cookedMushroomsMaterialForObj;
        //                pizzatype = "mushrooms";
        //            }
        //            else if (psauce == true && pcheese == true && pbacon == true && pmush != true && proni != true && ppeppers != true)
        //            {
        //                active = cookedBaconMaterialForObj;
        //                pizzatype = "bacon";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && ppeppers == true && pbacon != true && pmush != true)
        //            {
        //                active = cookedRoniAndPeppersMaterialForObj;
        //                pizzatype = "roniandpeppers";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers != true && ppeppers != true)
        //            {
        //                active = cookedRoniAndMushMaterialForObj;
        //                pizzatype = "roniandmush";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pbacon == true && pmush != true && ppeppers != true)
        //            {
        //                active = cookedRoniAndBaconMaterialForObj;
        //                pizzatype = "roniandbacon";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && ppeppers == true && pbacon != true && proni != true)
        //            {
        //                active = cookedPeppersAndMushMaterialForObj;
        //                pizzatype = "peppersandmush";
        //            }
        //            else if (psauce == true && pcheese == true && pbacon == true && ppeppers == true && proni != true && pmush != true)
        //            {
        //                active = cookedPeppersAndBaconMaterialForObj;
        //                pizzatype = "peppersandbacon";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && pbacon == true && proni != true && ppeppers != true)
        //            {
        //                active = cookedBaconAndMushMaterialForObj;
        //                pizzatype = "baconandmush";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pbacon == true && ppeppers == true && pmush != true)
        //            {
        //                active = cookedRoniAndBaconAndPeppersMaterialForObj;
        //                pizzatype = "roniandbaconandpep";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers != true)
        //            {
        //                active = cookedRoniAndBaconAndMushMaterialForObj;
        //                pizzatype = "roniandbaconandmush";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers == true && pbacon != true)
        //            {
        //                active = cookedRoniAndPeppersAndMushMaterialForObj;
        //                pizzatype = "roniandPepandmush";
        //            }
        //            else if (psauce == true && pcheese == true && pmush == true && pbacon == true && ppeppers == true && proni != true)
        //            {
        //                active = cookedMushAndBaconAndPeppersMaterialForObj;
        //                pizzatype = "mushandbaconandpep";
        //            }
        //            else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers == true)
        //            {
        //                active = cookedTheWorksMaterialForObj;
        //                pizzatype = "theworks";
        //            }
        //            break;
        //        case 3:
        //            active = burntMaterialForObj;
        //            break;
        //    }
        //}

        //void Cook()
        //{
        //    cookTime += Time.deltaTime;
        //    if (cookTime >= doneTime && cookTime <= burntTime)
        //        isCooked = true;
        //    else if (cookTime >= burntTime)
        //        isBurned = true;
        //    ToppingChange();
        //}
        //void OnTriggerStay(Collider col)
        //{
        //    GameObject other = col.gameObject;
        //    switch (other.tag)
        //    {
        //        case "oven":
        //            Cook();
        //            break;
        //    }
        //}
    }
}
