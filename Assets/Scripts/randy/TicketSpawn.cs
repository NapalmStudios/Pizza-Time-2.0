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

    void Update()
    {
        //int time++;
        //if (time >= spawnTicket)
        //{
        //    int pointIndex = Random.Range(0, points.Length);

        //    index = Random.Range(0, listOfTickets.Length);
        //    currentTicket = listOfTickets[index];

        //    ticketspawning = Instantiate(currentTicket, points[pointIndex].position, Quaternion.identity);
        //    time = 0;
        //}

    }

    public IEnumerator SpawnTickets(int Day, int amountToSpawn)
    {
        if (Day == 0)
        { 
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
        }
        else if (Day == 1)
        {
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
        }
        else if (Day == 2)
        {
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
        }
        else if (Day == 3)
        {
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
        }
        else if (Day > 3)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                randomTicket = Random.Range(0, ticket.Count);
                ticketToSpawn = ticket[randomTicket];

                currentTickets.Add(Instantiate(ticketToSpawn, spawnPoints[i].position, spawnPoints[i].rotation));
                yield return new WaitForSeconds(TimeBetweenSpawn);
            }
        }

    }
}
