using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PizzaTime;

public class Goal : MonoBehaviour
{
    //private ResourceLoader resourceLoader;
    //public GameObject[] roniPepBaconMushTicket;
    //public GameObject[] roniPepTicket;
    //public GameObject[] roniMushPepTicket;
    //public GameObject[] roniMushTicket;
    //public GameObject[] roniBaconPepTicket;
    //public GameObject[] roniBaconMushTicket;
    //public GameObject[] roniBaconTicket;
    //public GameObject[] roniTicket;
    //public GameObject[] pepTicket;
    //public GameObject[] mushPepTicket;
    //public GameObject[] mushTicket;
    //public GameObject[] baconPepTicket;
    //public GameObject[] baconMushPepTicket;
    //public GameObject[] baconMushTicket;
    //public GameObject[] baconTicket;
    //public GameObject[] cheeseTicket;

    TicketSpawn ticketSpawner;

    //public int multiplier = 2;
    //public int maxTipTime = 500;
    //private int tipTimer;
    //public int correctPizza = 10;

    public int tip;

    private void Start()
    {
       // resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        
    }
    void Update()
    {
        ticketSpawner = FindObjectOfType<TicketSpawn>();

        //roniPepBaconMushTicket = GameObject.FindGameObjectsWithTag("roniPepBaconMushTicket");
        //roniPepTicket = GameObject.FindGameObjectsWithTag("roniPepTicket");
        //roniMushPepTicket = GameObject.FindGameObjectsWithTag("roniMushPepTicket");
        //roniMushTicket = GameObject.FindGameObjectsWithTag("roniMushTicket");
        //roniBaconPepTicket = GameObject.FindGameObjectsWithTag("roniBaconPepTicket");
        //roniBaconMushTicket = GameObject.FindGameObjectsWithTag("roniBaconMushTicket");
        //roniBaconTicket = GameObject.FindGameObjectsWithTag("roniBaconTicket");
        //roniTicket = GameObject.FindGameObjectsWithTag("roniTicket");
        //pepTicket = GameObject.FindGameObjectsWithTag("pepTicket");
        //mushPepTicket = GameObject.FindGameObjectsWithTag("mushPepTicket");
        //mushTicket = GameObject.FindGameObjectsWithTag("mushTicket");
        //baconPepTicket = GameObject.FindGameObjectsWithTag("baconPepTicket");
        //baconMushPepTicket = GameObject.FindGameObjectsWithTag("baconMushPepTicket");
        //baconMushTicket = GameObject.FindGameObjectsWithTag("baconMushTicket");
        //baconTicket = GameObject.FindGameObjectsWithTag("baconTicket");
        //cheeseTicket = GameObject.FindGameObjectsWithTag("cheeseTicket");
    }

    private void OnTriggerEnter(Collider col)
    {
        var pizzaObj = col.gameObject.GetComponent<Pizza_Controller>();

        for (int i = 0; i < ticketSpawner.currentTickets.Count; i++)
        {
            var ticket = ticketSpawner.currentTickets[i];

            if (pizzaObj.activePizzaTexture.Equals(ticket.pizzaMat) && ticket.isActive == true)
            {
                if (pizzaObj.isDirty)
                {
                    Score.score += (ticket.ticketWorth + (tip * (int)ticket.tipTime)) - ticket.dirtyNeg;
                }
                else
                {
                    Score.score += ticket.ticketWorth + (tip * (int)ticket.tipTime);
                }

                ticket.isActive = false;
                Destroy(col.gameObject);
                break;
            }

           // Destroy(col.gameObject);
        }

        //for (int i = 0; i<cheeseTicket.Length; i++)
        //{
        //    var cheese = cheeseTicket[i].GetComponent<Ticket>();

        //    if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedCheeseMaterial) && cheese.isActive == true)
        //    {
        //        if (pizzaObj.isDirty)
        //        {
        //            Score.score += (cheese.ticketWorth + (tip * cheese.tipTime)) - cheese.dirtyNeg;
        //        }
        //        else
        //        {
        //            Score.score += cheese.ticketWorth + (tip * cheese.tipTime);
        //        }
            
        //        cheese.isActive = false;

        //        break;
        //    }
        //}

        //for (int i = 0; i < baconTicket.Length; i++)
        //{
        //    var bacon = baconTicket[i].GetComponent<Ticket>();

        //    if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedBaconMaterial) && bacon.isActive == true)
        //    {
        //        if (pizzaObj.isDirty)
        //        {
        //            Score.score += (bacon.ticketWorth + (tip * bacon.tipTime)) - bacon.dirtyNeg;
        //        }
        //        else
        //        {
        //            Score.score += bacon.ticketWorth + (tip * bacon.tipTime);
        //        }

        //        bacon.isActive = false;

        //        break;
        //    }
        //}

        //for (int i = 0; i < cheeseTicket.Length; i++)
        //{
        //    var cheese = cheeseTicket[i].GetComponent<Ticket>();

        //    if (pizzaObj.activePizzaTexture.Equals(resourceLoader.cookedCheeseMaterial) && cheese.isActive == true)
        //    {
        //        if (pizzaObj.isDirty)
        //        {
        //            Score.score += (cheese.ticketWorth + (tip * cheese.tipTime)) - cheese.dirtyNeg;
        //        }
        //        else
        //        {
        //            Score.score += cheese.ticketWorth + (tip * cheese.tipTime);
        //        }

        //        cheese.isActive = false;

        //        break;
        //    }
        //}

    }
}
