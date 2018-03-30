using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PizzaTime;

public class Goal : MonoBehaviour
{  
    public int tip;
    TicketSpawn ticketSpawner;

    void Update()
    {
        ticketSpawner = FindObjectOfType<TicketSpawn>();
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
        }
    }
}
