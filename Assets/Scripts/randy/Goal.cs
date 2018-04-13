using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PizzaTime;

public class Goal : MonoBehaviour
{  
    public int tip;
    public int score;
    public int pizzasMade;

    TicketSpawn ticketSpawner;

    void Start()
    {
        ticketSpawner = FindObjectOfType<TicketSpawn>();
    }

    void Update()
    {
        //ticketSpawner = FindObjectOfType<TicketSpawn>();
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
                    score += (ticket.ticketWorth + (tip * (int)ticket.tipTime)) - ticket.dirtyNeg;
                }
                else
                {
                    score += ticket.ticketWorth + (tip * (int)ticket.tipTime);
                }

                ticket.isActive = false;
                pizzasMade++;
                Destroy(col.gameObject);
                break;
            }
            Destroy(col.gameObject);
        }

        //TODO maybe lose money if wrong pizza
    }
}
