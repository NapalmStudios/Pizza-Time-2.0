using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PizzaTime;
using TMPro;

public class Goal : MonoBehaviour
{
    public int tip;
    public int score;
    public int pizzasMade;
    public TextMeshProUGUI tmp;

    public TicketSpawn ticketSpawner;

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
        if (pizzaObj != null)
        {
            for (int i = 0; i < ticketSpawner.currentTickets.Length; i++)
            {
                var ticket = ticketSpawner.currentTickets[i];

                if (pizzaObj.activePizzaTexture.Equals(ticket.pizzaMat) && ticket.isActive == true)
                {
                    Debug.Log("int");
                    if (pizzaObj.isDirty)
                    {
                        score += (ticket.ticketWorth + (tip * (int)ticket.tipTime)) - ticket.dirtyNeg;
                    }
                    else
                    {
                        score += ticket.ticketWorth + (tip * (int)ticket.tipTime);
                    }
                    tmp.text = "Today's Earnings = $" + score;
                    ticket.isActive = false;
                    pizzasMade++;
                    ticketSpawner.currentTickets[i] = null;
                    Destroy(col.gameObject);
                    break;
                }

            }
            Destroy(col.gameObject);
        }


        //TODO maybe lose money if wrong pizza
    }
}
