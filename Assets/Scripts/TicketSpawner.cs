using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSpawner : MonoBehaviour
{
    public Ticket currentTicket;

    private List<Ticket> possibleTickets = new List<Ticket>();
    private Transform ticketPole;

    public Ticket RandomTicket()
    {
        int randomNum = Random.Range(0, possibleTickets.Count - 1);
        Ticket spawnTicket = possibleTickets[randomNum];
        return spawnTicket;
    }
    public Ticket SpawnTickets(Ticket toSpawn)
    {
        currentTicket = Instantiate(toSpawn, ticketPole.position, ticketPole.rotation);
        return currentTicket;
    }	
}
