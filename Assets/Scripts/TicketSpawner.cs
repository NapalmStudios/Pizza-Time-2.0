using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSpawner : MonoBehaviour {

    private List<Ticket> possibleTickets = new List<Ticket>();
    private Transform ticketPole;
    private Ticket currentTicket;


    public Ticket SpawnTickets(Ticket toSpawn)
    {
        Instantiate(currentTicket, ticketPole.position, ticketPole.rotation);
        return toSpawn;
    }

	
}
