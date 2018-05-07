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
        public bool startMenuPizza;
        public bool isGlutenFree = false;
        public bool hasSauce = false;
        public GameObject pizza;
        public Pizza_Controller pizzaController;
        public Material activePizzaTexture;
        public Material currentPizzaTexture;

        private float cookTime;
        private float cookingSpeed;
        private bool isCooking = false;
        private bool textureChange = false;
        private float maxCookTempature;
        private bool onOven = false;
        private bool doneCheck = false;
        private PIZZA pizzaCase;
        private PIZZA toppingCase;
        private ResourceLoader resourceLoader;
        private AudioSource audio;
        // -------------------------------------------------- \\
        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            audio = GetComponent<AudioSource>();
            //maxCookTempature = GameObject.FindObjectOfType<Oven>().maxTempature;
            pizzaController = this;
            CheckForStartPizza();
            textureChange = true;
        }
        public void Update()
        {
            StartCoroutine(TextureChanger());
            StartCoroutine(AddSauce());
            StartCoroutine(PizzaDoneAudioCheck());
        }

        public void CheckForStartPizza()
        {
            if(startMenuPizza)
            {
                activePizzaTexture = resourceLoader.cheeseMaterial;
            }
            else
            {
                activePizzaTexture = resourceLoader.pizzaDoughMaterial;
            }
        }

        private IEnumerator PizzaDoneAudioCheck()
        {
            if (isCooked && !doneCheck)
            {
                audio.PlayOneShot(audio.clip);
                doneCheck = true;
            }
            yield return null;
        }

        /// <summary>
        /// Waits to see if there is a texture change on the Pizza
        /// </summary>
        /// <returns></returns>
        private IEnumerator TextureChanger()
        {
            if (textureChange)
            {
                pizza.GetComponent<Renderer>().material = activePizzaTexture;
                textureChange = false;
            }
            yield return null;
        }

        /// <summary>
        /// Sauce Texture Change
        /// </summary>
        /// <returns></returns>
        private IEnumerator AddSauce()
        {
            if (hasSauce && activePizzaTexture.Equals(resourceLoader.pizzaDoughMaterial))
            {
                activePizzaTexture = resourceLoader.sauceMaterial;
                textureChange = true;
            }

            yield return null;
        }

        /// <summary>
        /// For topping changing when a topping collides with the pizza
        /// </summary>
        /// <param name="col"></param>
        private void OnCollisionEnter(Collision col)
        {
            Fabric.EventManager.Instance.PostEvent("Diegetic - Pizza Impact", gameObject);

            var toppingControl = col.gameObject.GetComponent<ToppingController>();

            currentPizzaTexture = pizza.GetComponent<Renderer>().sharedMaterial;

            TextureGetter();
            if (!isCooking && !isCooked)
            {
                switch (pizzaCase)
                {
                    case PIZZA.Dough:
                        break;
                    case PIZZA.Sauce:
                        PizzaAddCheeseTopping(toppingControl);
                        break;
                    default:
                        ToppingSelector(toppingControl);
                        break;
                }
            }

        }
        /// <summary>
        /// Logic if the pizza is staying on Certain objects a.k.a the Floor and Oven
        /// </summary>
        /// <param name="col"></param>
        void OnTriggerStay(Collider col)
        {
            GameObject objectPizzaIsTouching = col.gameObject;
            if (objectPizzaIsTouching.tag.Equals(resourceLoader.ovenObj.tag))
            {
                //Cook(objectPizzaIsTouching.GetComponent<Oven>().tempature);
                Cooking(isCooking, cookingSpeed);
            }
            else if (objectPizzaIsTouching.tag.Equals(resourceLoader.floorObj.tag))
            {
                StartCoroutine(PizzaWait());
            }
            else if (objectPizzaIsTouching.tag.Equals(resourceLoader.trashCanObj.tag))
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
        /// Looks at the current texture of the Pizza Object and sets the pizzaCase value
        /// </summary>
        private void TextureGetter()
        {
            //Looks at the current pizza texture and then sets pizzaCase to the correct value
            if (currentPizzaTexture.Equals(resourceLoader.pizzaDoughMaterial) /*|| currentPizzaTexture.Equals(resourceLoader.gfPizzaDoughMaterial)*/)
            {
                //if(currentPizzaTexture.Equals(resourceLoader.gfPizzaDoughMaterial))
                //{
                //    isGlutenFree = true;
                //}
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
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniMush;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.peppersAndBaconMaterial))
            {
                pizzaCase = PIZZA.PeppersBacon;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.peppersAndMushMaterial))
            {
                pizzaCase = PIZZA.PeppersMush;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.baconAndMushMaterial))
            {
                pizzaCase = PIZZA.BaconMush;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndBaconAndPeppersMaterial))
            {
                pizzaCase = PIZZA.RoniPeppersBacon;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.mushAndBaconAndPeppers))
            {
                pizzaCase = PIZZA.PeppersBaconMush;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndBaconAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniBaconMush;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndPeppersAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniPeppersMush;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.theWorksMaterial))
            {
                pizzaCase = PIZZA.TheWorks;
            }
        }

        /// <summary>
        /// Selects the Topping Case to enable putting a topping onto a pizza
        /// </summary>
        /// <param name="topping"></param>
        private void ToppingSelector(ToppingController topping)
        {
            var toppingObj = topping.toppingObject;
            if (topping.dirtyTopping)
            {
                isDirty = true;
            }
            switch (topping.toppingType)
            {
                case TOPPING.Roni:
                    PizzaAddRoniTopping(toppingObj);
                    break;
                case TOPPING.Bacon:
                    PizzaAddBaconTopping(toppingObj);
                    break;
                case TOPPING.Peppers:
                    PizzaAddPeppersTopping(toppingObj);
                    break;
                case TOPPING.Mushrooms:
                    PizzaAddMushroomsTopping(toppingObj);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// If-Else Statement for Adding Cheese Before Able to Add Other Toppings
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddCheeseTopping(ToppingController topping)
        {
            switch (topping.toppingType)
            {
                case TOPPING.Cheese:
                    activePizzaTexture = resourceLoader.cheeseMaterial;
                    textureChange = true;
                    if (topping.dirtyTopping)
                    {
                        isDirty = true;
                    }
                    Destroy(topping.toppingObject);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds Roni To the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void PizzaAddRoniTopping(GameObject topping)
        {
            switch (pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.roniMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.roniAndBaconMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.roniAndPeppersMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.roniAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersMush:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.BaconMush:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBaconMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    textureChange = true;
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
            switch (pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.baconMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndBaconMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.peppersAndBaconMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.baconAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniMush:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPepper:
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersMush:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPeppersMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    textureChange = true;
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
            switch (pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.peppersMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndPeppersMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.peppersAndBaconMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.peppersAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniMush:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.BaconMush:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBaconMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    textureChange = true;
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
            switch (pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.mushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.baconAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.peppersAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPepper:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBacon:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    textureChange = true;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPeppersBacon:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    textureChange = true;
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
            if (cooked)
            {
                switch (pizzaCase)
                {
                    case PIZZA.Dough:
                        activePizzaTexture = resourceLoader.cookedDoughMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.Cheese:
                        activePizzaTexture = resourceLoader.cookedCheeseMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.Roni:
                        activePizzaTexture = resourceLoader.cookedRoniMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.Bacon:
                        activePizzaTexture = resourceLoader.cookedBaconMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.Peppers:
                        activePizzaTexture = resourceLoader.cookedPeppersMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.Mushrooms:
                        activePizzaTexture = resourceLoader.cookedMushMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.RoniPepper:
                        activePizzaTexture = resourceLoader.cookedRoniAndPeppersMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.RoniBacon:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.RoniMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndMushMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.PeppersBacon:
                        activePizzaTexture = resourceLoader.cookedPeppersAndBaconMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.PeppersMush:
                        activePizzaTexture = resourceLoader.cookedPeppersAndMushMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.BaconMush:
                        activePizzaTexture = resourceLoader.cookedBaconAndMushMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.RoniPeppersBacon:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconAndPeppersMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.PeppersBaconMush:
                        activePizzaTexture = resourceLoader.cookedMushAndBaconAndPeppersMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.RoniBaconMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconAndMushMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.RoniPeppersMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndPeppersAndMushMaterial;
                        textureChange = true;
                        break;
                    case PIZZA.TheWorks:
                        activePizzaTexture = resourceLoader.cookedTheWorksMaterial;
                        textureChange = true;
                        break;
                    default:
                        //activePizzaTexture = resourceLoader.cookedTheWorksMaterial;
                        //textureChange = true;
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
            else if (currentOvenTempature >= minCookTempature && currentOvenTempature < midCookTempature)
            {
                isCooking = true;
                cookingSpeed = SetCookingSpeed(currentOvenTempature, minCookTempature, midCookTempature, initialLowestCookSpeedValue);
            }
            else if (currentOvenTempature >= midCookTempature && currentOvenTempature < maxCookTempature)
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

        /// <summary>
        /// Method for Cooking the Pizza as well as Buring the Pizza
        /// </summary>
        /// <param name="isCooking"></param>
        /// <param name="cookingSpeed"></param>
        /// <returns></returns>
        private void Cooking(bool isCooking, float cookingSpeed)
        {
            cookTime += Time.deltaTime;
            isCooking = true;
            if (cookTime >= totalCookTime && cookTime <= totalCookTime + burnTime)
            {

                isCooked = true;
                Fabric.EventManager.Instance.PostEvent("Diegetic - Pizza Cooked", gameObject);
                CookedPizzas(isCooked);
                isCooking = false;
            }
            else if (cookTime >= totalCookTime + burnTime)
            {
                activePizzaTexture = resourceLoader.cookedBurnt;
                Fabric.EventManager.Instance.PostEvent("Diegetic - Pizza Burnt", gameObject);
                textureChange = true;
                isCooking = false;
            }
        }

        /// <summary>
        /// Method for if the Pizza is touching the floor
        /// </summary>
        /// <returns></returns>
        public IEnumerator PizzaWait()
        {
            yield return new WaitForSeconds(timeBeforeDirty);
            isDirty = true;
        }
    }
}