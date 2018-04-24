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
    public int amountTicket = 50;
    public Ticket ticketToSpawn;
    public Ticket[] currentTickets;

    void Start()
    {
        StartCoroutine(SpawnTickets(Day, amountTicket));
    }

    public void SpawnTicket()
    {
        for (int j = 0; j < currentTickets.Length; j++)
        {
            if (currentTickets[j] == null)
            {
                currentTickets[j] = (Instantiate(ticketToSpawn, spawnPoints[j].position, spawnPoints[j].rotation));
                break;

            }

        }
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

                    SpawnTicket();
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

                    SpawnTicket();
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

                    SpawnTicket();
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

                    SpawnTicket();
                    yield return new WaitForSeconds(TimeBetweenSpawn);
                }

                break;

            default:

                for (int i = 0; i < amountToSpawn; i++)
                {
                    randomTicket = Random.Range(0, ticket.Count);
                    ticketToSpawn = ticket[randomTicket];

                    SpawnTicket();
                    yield return new WaitForSeconds(TimeBetweenSpawn);
                }

                break;
        }
    }
}
