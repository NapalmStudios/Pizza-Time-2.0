using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
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
    public int tipTimer;
    public int correctPizza = 10;
    private void Start()
    {
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
     
         


        if (col.gameObject.name == "Cheese Pizza" && cheeseTicket == true)
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
        if (col.gameObject.name == "Bacon Pizza" && baconTicket == true)
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
        if (col.gameObject.name == "Bacon Mushroom Pizza" && baconMushTicket == true)
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
        if (col.gameObject.name == "Bacon Mushroom Pepper Pizza" && baconMushPepTicket == true)
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
        if (col.gameObject.name == "Bacon Pepper Pizza" && baconPepTicket == true)
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
        if (col.gameObject.name == "Mushroom Pizza" && mushTicket == true)
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

        if (col.gameObject.name == "Mushroom Pepper Pizza" && mushPepTicket == true)
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
        if (col.gameObject.name == "Pepper Pizza" && pepTicket == true)
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
        if (col.gameObject.name == "Pepperoni Pizza" && roniTicket == true)
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
        if (col.gameObject.name == "Pepperoni Bacon Pizza" && roniBaconTicket == true)
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
        if (col.gameObject.name == "Pepperoni Bacon Mushroom Pizza" && roniBaconMushTicket == true)
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
        if (col.gameObject.name == "Pepperoni Bacon Pepper Pizza" && roniBaconPepTicket == true)
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
        if (col.gameObject.name == "Pepperoni Mushroom Pizza" && roniMushTicket == true)
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
        if (col.gameObject.name == "Pepperoni Mushroom Pepper Pizza" && roniMushPepTicket == true)
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
        if (col.gameObject.name == "Pepperoni Pepper Pizza" && roniPepTicket == true)
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
        if (col.gameObject.name == "Pepperoni Pepper Bacon Pizza" && roniPepBaconMushTicket == true)
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
            tipTimer = 0;
            Destroy(col.gameObject);
        }
    }

}
