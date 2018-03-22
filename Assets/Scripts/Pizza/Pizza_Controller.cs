using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
namespace PizzaTime
{
    // TODO: Refactor in a way that it could be expaneded later
    public class Pizza_Controller : MonoBehaviour
    {
        public float cookTime = 0;
        public float doneTime = 10;
        public float burntTime = 20;
        public bool isCooked = false;
        public bool isBurned = false;

        public Pizza_Controller pizzaController;

        public Material active;
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
            active = doughMaterialForObj;
        }

        private void LoadMaterialVars()
        {
            // ------------------------ Base Material Initalization --------------------------- \\
            doughMaterialForObj = resourceLoader.pizzaDoughMaterial;
            sauceMaterialForObj = resourceLoader.sauceMaterial;
            cheeseMaterialForObj = resourceLoader.cheeseMaterial;
            roniMaterialForObj = resourceLoader.roniMaterial;
            baconMaterialForObj = resourceLoader.baconMaterial;
            peppersMaterialForObj = resourceLoader.peppersMaterial;
            mushroomsMaterialForObj = resourceLoader.mushMaterial;
            burntMaterialForObj = resourceLoader.cookedBurnt;
            // -------------------------------------------------------------------------------- \\

            // ------------------------ Two-Topping Material Initalization --------------------------- \\
            roniAndBaconMaterialForObj = resourceLoader.roniAndBaconMaterial;
            roniAndPeppersMaterialForObj = resourceLoader.roniAndPeppersMaterial;
            roniAndMushMaterialForObj = resourceLoader.roniAndMushMaterial;
            peppersAndMushMaterialForObj = resourceLoader.peppersAndMushMaterial;
            peppersAndBaconMaterialForObj = resourceLoader.peppersAndBaconMaterial;
            baconAndMushMaterialForObj = resourceLoader.baconAndMushMaterial;
            // --------------------------------------------------------------------------------------- \\

            // -------------- Three-Topping Material Variables ---------------------------------------- \\
            roniAndBaconAndPeppersMaterialForObj = resourceLoader.roniAndBaconAndPeppersMaterial;
            roniAndBaconAndMushMaterialForObj = resourceLoader.roniAndBaconAndMushMaterial;
            roniAndPeppersAndMushMaterialForObj = resourceLoader.roniAndPeppersAndMushMaterial;
            mushAndBaconAndPeppersMaterialForObj = resourceLoader.mushAndBaconAndPeppers;
            // ---------------------------------------------------------------------------------------- \\

            // -------------- Specialty Material Variables --------------------------- \\
            theWorksMaterialForObj = resourceLoader.theWorksMaterial;
            // ----------------------------------------------------------------------- \\

            // --------------- Cooked Single Topping Material Variables --------------------------------------------- \\
            cookedDoughMaterialForObj = resourceLoader.cookedDoughMaterial;
            cookedSauceMaterialForObj = resourceLoader.cookedSauceMaterial;
            cookedCheeseMaterialForObj = resourceLoader.cookedCheeseMaterial;
            cookedRoniMaterialForObj = resourceLoader.cookedRoniMaterial;
            cookedBaconMaterialForObj = resourceLoader.cookedBaconMaterial;
            cookedPeppersMaterialForObj = resourceLoader.cookedPeppersMaterial;
            cookedMushroomsMaterialForObj = resourceLoader.cookedMushMaterial;
            // ------------------------------------------------------------------------------------------------------ \\

            // --------------- Cooked Two-Topping Material Variables --------------------------------------------- \\
            cookedRoniAndBaconMaterialForObj = resourceLoader.cookedRoniAndBaconMaterial;
            cookedRoniAndPeppersMaterialForObj = resourceLoader.cookedRoniAndPeppersMaterial;
            cookedRoniAndMushMaterialForObj = resourceLoader.cookedRoniAndMushMaterial;
            cookedPeppersAndMushMaterialForObj = resourceLoader.cookedPeppersAndMushMaterial;
            cookedPeppersAndBaconMaterialForObj = resourceLoader.cookedPeppersAndBaconMaterial;
            cookedBaconAndMushMaterialForObj = resourceLoader.cookedBaconAndMushMaterial;
            // --------------------------------------------------------------------------------------------------- \\

            // --------------- Cooked Three-Topping Material Variables --------------------------------------------- \\
            cookedRoniAndBaconAndPeppersMaterialForObj = resourceLoader.cookedRoniAndBaconAndPeppersMaterial;
            cookedRoniAndBaconAndMushMaterialForObj = resourceLoader.cookedRoniAndBaconAndMushMaterial;
            cookedRoniAndPeppersAndMushMaterialForObj = resourceLoader.cookedRoniAndPeppersAndMushMaterial;
            cookedMushAndBaconAndPeppersMaterialForObj = resourceLoader.cookedMushAndBaconAndPeppersMaterial;
            // ----------------------------------------------------------------------------------------------------- \\

            // -------------- Specialty Material Variables --------------------------- \\
            cookedTheWorksMaterialForObj = resourceLoader.theWorksMaterial;
            // ----------------------------------------------------------------------- \\
        }

        void ToppingChange()
        {
            int caseSwitch = 0;
            if (isCooked != true && isBurned != true) caseSwitch = 1;
            if (isCooked == true && isBurned != true) caseSwitch = 2;
            if (isCooked == true && isBurned == true) caseSwitch = 3;
            switch (caseSwitch)
            {
                case 1:
                    if (psauce == true && pcheese != true && proni != true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = sauceMaterialForObj;
                        //pizzatype = "sauce";
                    }
                    else if (psauce == true && pcheese == true && proni != true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cheeseMaterialForObj;
                        //pizzatype = "cheese";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = roniMaterialForObj;
                        //pizzatype = "roni";
                    }
                    else if (psauce == true && pcheese == true && ppeppers == true && pmush != true && pbacon != true && proni != true)
                    {
                        active = peppersMaterialForObj;
                        //pizzatype = "peppers";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && proni != true && pbacon != true && ppeppers != true)
                    {
                        active = mushroomsMaterialForObj;
                        //pizzatype = "mushrooms";
                    }
                    else if (psauce == true && pcheese == true && pbacon == true && pmush != true && proni != true && ppeppers != true)
                    {
                        active = baconMaterialForObj;
                        //pizzatype = "bacon";
                    }
                    else if (psauce == true && pcheese == true && proni == true && ppeppers == true && pbacon != true && pmush != true)
                    {
                        active = roniAndPeppersMaterialForObj;
                        //pizzatype = "roniandpeppers";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers != true && pbacon != true)
                    {
                        active = roniAndMushMaterialForObj;
                        //pizzatype = "roniandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && pmush != true && ppeppers != true)
                    {
                        active = roniAndBaconMaterialForObj;
                        //pizzatype = "roniandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && ppeppers == true && pbacon != true && proni != true)
                    {
                        active = peppersAndMushMaterialForObj;
                        //pizzatype = "peppersandmush";
                    }
                    else if (psauce == true && pcheese == true && pbacon == true && ppeppers == true && proni != true && pmush != true)
                    {
                        active = peppersAndBaconMaterialForObj;
                        //pizzatype = "peppersandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && proni != true && ppeppers != true)
                    {
                        active = baconAndMushMaterialForObj;
                        //pizzatype = "baconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && ppeppers == true && pmush != true)
                    {
                        active = roniAndBaconAndPeppersMaterialForObj;
                        //pizzatype = "roniandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers != true)
                    {
                        active = roniAndBaconAndMushMaterialForObj;
                        //pizzatype = "roniandbaconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers == true && pbacon != true)
                    {
                        active = roniAndPeppersAndMushMaterialForObj;
                        //pizzatype = "roniandPepandmush";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && ppeppers == true && proni != true)
                    {
                        active = mushAndBaconAndPeppersMaterialForObj;
                        //pizzatype = "mushandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers == true)
                    {
                        active = theWorksMaterialForObj;
                        //pizzatype = "theworks";
                    }
                    break;
                case 2:
                    if (psauce != true && pcheese != true && proni != true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedDoughMaterialForObj;
                    }
                    else if (psauce == true && pcheese != true && proni != true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedSauceMaterialForObj;
                        pizzatype = "sauce";
                    }
                    else if (psauce == true && pcheese == true && proni != true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedCheeseMaterialForObj;
                        pizzatype = "cheese";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedRoniMaterialForObj;
                        pizzatype = "roni";
                    }
                    else if (psauce == true && pcheese == true && ppeppers == true && pmush != true && pbacon != true && proni != true)
                    {
                        active = cookedPeppersMaterialForObj;
                        pizzatype = "peppers";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && proni != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedMushroomsMaterialForObj;
                        pizzatype = "mushrooms";
                    }
                    else if (psauce == true && pcheese == true && pbacon == true && pmush != true && proni != true && ppeppers != true)
                    {
                        active = cookedBaconMaterialForObj;
                        pizzatype = "bacon";
                    }
                    else if (psauce == true && pcheese == true && proni == true && ppeppers == true && pbacon != true && pmush != true)
                    {
                        active = cookedRoniAndPeppersMaterialForObj;
                        pizzatype = "roniandpeppers";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers != true && ppeppers != true)
                    {
                        active = cookedRoniAndMushMaterialForObj;
                        pizzatype = "roniandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && pmush != true && ppeppers != true)
                    {
                        active = cookedRoniAndBaconMaterialForObj;
                        pizzatype = "roniandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && ppeppers == true && pbacon != true && proni != true)
                    {
                        active = cookedPeppersAndMushMaterialForObj;
                        pizzatype = "peppersandmush";
                    }
                    else if (psauce == true && pcheese == true && pbacon == true && ppeppers == true && proni != true && pmush != true)
                    {
                        active = cookedPeppersAndBaconMaterialForObj;
                        pizzatype = "peppersandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && proni != true && ppeppers != true)
                    {
                        active = cookedBaconAndMushMaterialForObj;
                        pizzatype = "baconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && ppeppers == true && pmush != true)
                    {
                        active = cookedRoniAndBaconAndPeppersMaterialForObj;
                        pizzatype = "roniandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers != true)
                    {
                        active = cookedRoniAndBaconAndMushMaterialForObj;
                        pizzatype = "roniandbaconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers == true && pbacon != true)
                    {
                        active = cookedRoniAndPeppersAndMushMaterialForObj;
                        pizzatype = "roniandPepandmush";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && ppeppers == true && proni != true)
                    {
                        active = cookedMushAndBaconAndPeppersMaterialForObj;
                        pizzatype = "mushandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers == true)
                    {
                        active = cookedTheWorksMaterialForObj;
                        pizzatype = "theworks";
                    }
                    break;
                case 3:
                    active = burntMaterialForObj;
                    break;
            }
        }

        void Cook()
        {
            cookTime += Time.deltaTime;
            if (cookTime >= doneTime && cookTime <= burntTime)
                isCooked = true;
            else if (cookTime >= burntTime)
                isBurned = true;
            ToppingChange();
        }
        void OnTriggerStay(Collider col)
        {
            GameObject other = col.gameObject;
            switch (other.tag)
            {
                case "oven":
                    Cook();
                    break;
            }
        }
        void OnCollisionEnter(Collision col)
        {
            GameObject other = col.gameObject;
            if (isCooked == false)
            {
                switch (other.tag)
                {
                    case "sauce":
                        if (psauce != true)
                        {
                            Destroy(other);
                            //sauceAuto.objs--;
                        }
                        psauce = true;
                        break;
                    case "cheese":
                        if (pcheese != true && psauce == true) Destroy(other);
                        if (psauce == true)
                        {
                            pcheese = true;
                            //cheeseAuto.objs--;
                        }
                        break;
                    case "roni":
                        if (psauce == true && pcheese == true && proni != true) Destroy(other);
                        if (psauce == true && pcheese == true)
                        {
                            proni = true;
                            //roniAuto.objs--;
                        }
                        break;
                    case "peppers":
                        if (psauce == true && pcheese == true && ppeppers != true) Destroy(other);
                        if (psauce == true && pcheese == true)
                        {
                            ppeppers = true;
                            //pepperAuto.objs--;
                        }
                        break;
                    case "mushrooms":
                        if (psauce == true && pcheese == true && pmush != true) Destroy(other);
                        if (psauce == true && pcheese == true)
                        {
                            pmush = true;
                            //mushAuto.objs--;
                        }
                        break;
                    case "bacon":
                        if (psauce == true && pcheese == true && pbacon != true) Destroy(other);
                        if (psauce == true && pcheese == true)
                        {
                            pbacon = true;
                            //baconAuto.objs--;
                        }
                        break;
                }
                ToppingChange();
            }
        }
        public void Update()
        {
            pizza.GetComponent<Renderer>().material = active;
        }
    }
}
