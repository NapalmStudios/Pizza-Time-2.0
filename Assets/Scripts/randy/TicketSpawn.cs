using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSpawn : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public List<Ticket> ticket = new List<Ticket>();
    public int TimeBetweenSpawn;
    public int randomTicket;
    public int Day;
    public Ticket ticketToSpawn;
    public List<Ticket> currentTickets = new List<Ticket>();

    void Start()
    {
        StartCoroutine(SpawnTickets(Day, 3));
    }

    public IEnumerator SpawnTickets(int Day, int amountToSpawn)
    {
        switch (Day)
        {
            case 0:

                for (int i = 0; i < amountToSpawn; i++)
                {
                    do
                    {
                        randomTicket = Random.Range(0, ticket.Count);
                        ticketToSpawn = ticket[randomTicket];
                    }
                    while (ticketToSpawn.ticketType != TicketType.IsCheese);

                    currentTickets.Add(Instantiate(ticketToSpawn, spawnPoints[i].position, spawnPoints[i].rotation));
                    yield return new WaitForSeconds(TimeBetweenSpawn);
                }

                break;

            case 1:

                for (int i = 0; i < amountToSpawn; i++)
                {
                    do
                    {
                        randomTicket = Random.Range(0, ticket.Count);
                        ticketToSpawn = ticket[randomTicket];
                    }
                    while (ticketToSpawn.ticketType != TicketType.IsSingle);

                    currentTickets.Add(Instantiate(ticketToSpawn, spawnPoints[i].position, spawnPoints[i].rotation));
                    yield return new WaitForSeconds(TimeBetweenSpawn);
                }

                break;

            case 2:

                for (int i = 0; i < amountToSpawn; i++)
                {
                    do
                    {
                        randomTicket = Random.Range(0, ticket.Count);
                        ticketToSpawn = ticket[randomTicket];
                    }
                    while (ticketToSpawn.ticketType != TicketType.IsDouble);

                    currentTickets.Add(Instantiate(ticketToSpawn, spawnPoints[i].position, spawnPoints[i].rotation));
                    yield return new WaitForSeconds(TimeBetweenSpawn);
                }

                break;

            case 3:

                for (int i = 0; i < amountToSpawn; i++)
                {
                    do
                    {
                        randomTicket = Random.Range(0, ticket.Count);
                        ticketToSpawn = ticket[randomTicket];
                    }
                    while (ticketToSpawn.ticketType != TicketType.IsTripple);

                    currentTickets.Add(Instantiate(ticketToSpawn, spawnPoints[i].position, spawnPoints[i].rotation));
                    yield return new WaitForSeconds(TimeBetweenSpawn);
                }

                break;

            default:

                for (int i = 0; i < amountToSpawn; i++)
                {
                    randomTicket = Random.Range(0, ticket.Count);
                    ticketToSpawn = ticket[randomTicket];

                    currentTickets.Add(Instantiate(ticketToSpawn, spawnPoints[i].position, spawnPoints[i].rotation));
                    yield return new WaitForSeconds(TimeBetweenSpawn);
                }

                break;
        }     
    }
}
