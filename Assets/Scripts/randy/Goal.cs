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
        tipTimer++;
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "Cheese Pizza" && cheeseTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Bacon Pizza" && baconTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Bacon Mushroom Pizza" && baconMushTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Bacon Mushroom Pepper Pizza" && baconMushPepTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Bacon Pepper Pizza" && baconPepTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Mushroom Pizza" && mushTicket.activeInHierarchy == true)
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

        if (col.gameObject.name == "Mushroom Pepper Pizza" && mushPepTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepper Pizza" && pepTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Pizza" && roniTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Bacon Pizza" && roniBaconTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Bacon Mushroom Pizza" && roniBaconMushTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Bacon Pepper Pizza" && roniBaconPepTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Mushroom Pizza" && roniMushTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Mushroom Pepper Pizza" && roniMushPepTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Pepper Pizza" && roniPepTicket.activeInHierarchy)
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
        if (col.gameObject.name == "Pepperoni Pepper Bacon Pizza" && roniPepBaconMushTicket.activeInHierarchy)
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
