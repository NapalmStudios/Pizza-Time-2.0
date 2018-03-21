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

        public Pizza_Controller S;

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
        
        public Material cookedDough;
        public Material burnt;
        public Material cooked;
        public Material cookedSauce;
        public Material cookedCheese;
        public Material cookedRoni;
        public Material cookedPeppers;
        public Material cookedMushrooms;
        public Material cookedBacon;
        public Material cookedroniandbacon;
        public Material cookedroniandpeppers;
        public Material cookedroniandmush;
        public Material cookedpeppersandmush;
        public Material cookedpeppersandbacon;
        public Material cookedbaconandmush;
        public Material cookedroniandbaconandpep;
        public Material cookedroniandbaconandmush;
        public Material cookedroniandPepandmush;
        public Material cookedmushandbaconandpep;
        public Material cookedtheworks;

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
            // ------------------------ Base Material Initalization --------------------------- \\
            doughMaterialForObj = resourceLoader.pizzaDoughMaterial;
            sauceMaterialForObj = resourceLoader.sauceMaterial;
            cheeseMaterialForObj = resourceLoader.cheeseMaterial;
            roniMaterialForObj = resourceLoader.roniMaterial;
            baconMaterialForObj = resourceLoader.baconMaterial;
            peppersMaterialForObj = resourceLoader.peppersMaterial;
            mushroomsMaterialForObj = resourceLoader.mushMaterial;
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

            // -------------- Load Specialty Material Variables ------------------------------------------------------------- \\
            theWorksMaterialForObj = resourceLoader.theWorksMaterial;
            // -------------------------------------------------------------------------------------------------------------- \\

            S = this;
            active = doughMaterialForObj;
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
                        active = cookedDough;
                    }
                    else if (psauce == true && pcheese != true && proni != true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedSauce;
                        pizzatype = "sauce";
                    }
                    else if (psauce == true && pcheese == true && proni != true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedCheese;
                        pizzatype = "cheese";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedRoni;
                        pizzatype = "roni";
                    }
                    else if (psauce == true && pcheese == true && ppeppers == true && pmush != true && pbacon != true && proni != true)
                    {
                        active = cookedPeppers;
                        pizzatype = "peppers";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && proni != true && pbacon != true && ppeppers != true)
                    {
                        active = cookedMushrooms;
                        pizzatype = "mushrooms";
                    }
                    else if (psauce == true && pcheese == true && pbacon == true && pmush != true && proni != true && ppeppers != true)
                    {
                        active = cookedBacon;
                        pizzatype = "bacon";
                    }
                    else if (psauce == true && pcheese == true && proni == true && ppeppers == true && pbacon != true && pmush != true)
                    {
                        active = cookedroniandpeppers;
                        pizzatype = "roniandpeppers";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers != true && ppeppers != true)
                    {
                        active = cookedroniandmush;
                        pizzatype = "roniandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && pmush != true && ppeppers != true)
                    {
                        active = cookedroniandbacon;
                        pizzatype = "roniandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && ppeppers == true && pbacon != true && proni != true)
                    {
                        active = cookedpeppersandmush;
                        pizzatype = "peppersandmush";
                    }
                    else if (psauce == true && pcheese == true && pbacon == true && ppeppers == true && proni != true && pmush != true)
                    {
                        active = cookedpeppersandbacon;
                        pizzatype = "peppersandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && proni != true && ppeppers != true)
                    {
                        active = cookedbaconandmush;
                        pizzatype = "baconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && ppeppers == true && pmush != true)
                    {
                        active = cookedroniandbaconandpep;
                        pizzatype = "roniandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers != true)
                    {
                        active = cookedroniandbaconandmush;
                        pizzatype = "roniandbaconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers == true && pbacon != true)
                    {
                        active = cookedroniandPepandmush;
                        pizzatype = "roniandPepandmush";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && ppeppers == true && proni != true)
                    {
                        active = cookedmushandbaconandpep;
                        pizzatype = "mushandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers == true)
                    {
                        active = cookedtheworks;
                        pizzatype = "theworks";
                    }
                    break;
                case 3:
                    active = burnt;
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
