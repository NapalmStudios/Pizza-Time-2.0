using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
namespace PizzaTime
{
    public class Pizza_Controller : MonoBehaviour
    {
        public float cookTime = 0;
        public float doneTime = 10;
        public float burntTime = 20;
        public bool isCooked = false;
        public bool isBurned = false;

        public Pizza_Controller S;

        public Material active;
        public Material sauceMaterialForObj;
        public Material cheeseMaterialForObj;
        public Material roniMaterialForObj;
        public Material peppersMaterialForObj;
        public Material mushroomsMaterialForObj;
        public Material baconMaterialForObj;
        public Material roniandbacon;
        public Material roniandpeppers;
        public Material roniandmush;
        public Material peppersandmush;
        public Material peppersandbacon;
        public Material baconandmush;
        public Material roniandbaconandpep;
        public Material roniandbaconandmush;
        public Material roniandPepandmush;
        public Material mushandbaconandpep;
        public Material theworks;
        public Material doughMaterialForObj;
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

            // --------------------------------------------------------------------------------------- \\
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
                        active = roniandpeppers;
                        //pizzatype = "roniandpeppers";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers != true && pbacon != true)
                    {
                        active = roniandmush;
                        //pizzatype = "roniandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && pmush != true && ppeppers != true)
                    {
                        active = roniandbacon;
                        //pizzatype = "roniandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && ppeppers == true && pbacon != true && proni != true)
                    {
                        active = peppersandmush;
                        //pizzatype = "peppersandmush";
                    }
                    else if (psauce == true && pcheese == true && pbacon == true && ppeppers == true && proni != true && pmush != true)
                    {
                        active = peppersandbacon;
                        //pizzatype = "peppersandbacon";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && proni != true && ppeppers != true)
                    {
                        active = baconandmush;
                        //pizzatype = "baconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pbacon == true && ppeppers == true && pmush != true)
                    {
                        active = roniandbaconandpep;
                        //pizzatype = "roniandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers != true)
                    {
                        active = roniandbaconandmush;
                        //pizzatype = "roniandbaconandmush";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && ppeppers == true && pbacon != true)
                    {
                        active = roniandPepandmush;
                        //pizzatype = "roniandPepandmush";
                    }
                    else if (psauce == true && pcheese == true && pmush == true && pbacon == true && ppeppers == true && proni != true)
                    {
                        active = mushandbaconandpep;
                        //pizzatype = "mushandbaconandpep";
                    }
                    else if (psauce == true && pcheese == true && proni == true && pmush == true && pbacon == true && ppeppers == true)
                    {
                        active = theworks;
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
