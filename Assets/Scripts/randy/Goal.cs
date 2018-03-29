using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PizzaTime;

public class Goal : MonoBehaviour
{
    private ResourceLoader resourceLoader;
    public Pizza_Controller pizzaController;
    public GameObject roniPepBaconMushTicket;
    public GameObject roniPepTicket;
    public GameObject roniMushPepTicket;
    public GameObject roniMushTicket;
    public GameObject roniBaconPepTicket;
    public GameObject roniBaconMushTicket;
    public GameObject roniBaconTicket;
    public GameObject roniTicket;
    public GameObject pepTicket;
    public GameObject mushPepTicket;
    public GameObject mushTicket;
    public GameObject baconPepTicket;
    public GameObject baconMushPepTicket;
    public GameObject baconMushTicket;
    public GameObject baconTicket;
    public GameObject cheeseTicket;

    public int multiplier = 2;
    public int maxTipTime = 500;
    private int tipTimer;
    public int correctPizza = 10;

    private void Start()
    {
        resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        // tipTimer = 600;
    }
    void Update()
    {
        // if orange name doesnt work check tag for spaces
        roniPepBaconMushTicket = GameObject.FindGameObjectWithTag("roniPepBaconMushTicket");
        roniPepTicket = GameObject.FindGameObjectWithTag("roniPepTicket");
        roniMushPepTicket = GameObject.FindGameObjectWithTag("roniMushPepTicket");
        roniMushTicket = GameObject.FindGameObjectWithTag("roniMushTicket");
        roniBaconPepTicket = GameObject.FindGameObjectWithTag("roniBaconPepTicket");
        roniBaconMushTicket = GameObject.FindGameObjectWithTag("roniBaconMushTicket");
        roniBaconTicket = GameObject.FindGameObjectWithTag("roniBaconTicket");
        roniTicket = GameObject.FindGameObjectWithTag("roniTicket");
        pepTicket = GameObject.FindGameObjectWithTag("pepTicket");
        mushPepTicket = GameObject.FindGameObjectWithTag("mushPepTicket");
        mushTicket = GameObject.FindGameObjectWithTag("mushTicket");
        baconPepTicket = GameObject.FindGameObjectWithTag("baconPepTicket");
        baconMushPepTicket = GameObject.FindGameObjectWithTag("baconMushPepTicket");
        baconMushTicket = GameObject.FindGameObjectWithTag("baconMushTicket");
        baconTicket = GameObject.FindGameObjectWithTag("baconTicket");
        cheeseTicket = GameObject.FindGameObjectWithTag("cheeseTicket");

        tipTimer++;
    }

    private void OnCollisionEnter(Collision col)
    {
        var pizzaObj = col.gameObject.GetComponent<Pizza_Controller>();
        
       // Debug.Log(pizzaObj.activePizzaTexture);

        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedCheeseMaterial) && cheeseTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedBaconMaterial) && baconTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedBaconAndMushMaterial) && baconMushTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedMushAndBaconAndPeppersMaterial) && baconMushPepTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedPeppersAndBaconMaterial) && baconPepTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedMushMaterial) && mushTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }

        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedPeppersAndMushMaterial) && mushPepTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedPeppersMaterial) && pepTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedRoniMaterial) && roniTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedRoniAndBaconMaterial) && roniBaconTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedRoniAndBaconAndMushMaterial) && roniBaconMushTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedRoniAndBaconAndPeppersMaterial) && roniBaconPepTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedRoniAndMushMaterial) && roniMushTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedRoniAndPeppersAndMushMaterial) && roniMushPepTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedRoniAndPeppersMaterial) && roniPepTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedTheWorksMaterial) && roniPepBaconMushTicket == true)
        {
            if (tipTimer < maxTipTime)
            {
                Score.score += correctPizza * multiplier;
            }
            else
            {
                Score.score += correctPizza;
            }
        }
        if (col.gameObject.tag == "Pizza")
        {
            Delivered.score++;
            tipTimer = 0;
            Destroy(col.gameObject);
        }
    }
}
