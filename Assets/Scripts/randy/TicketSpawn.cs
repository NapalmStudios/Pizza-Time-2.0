using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSpawn : MonoBehaviour
{

    public Transform[] points;
    public GameObject[] listOfTickets;
    public int time;
    public int index;
    private GameObject currentTicket;
    public int spawnTicket;
    public GameObject ticketspawning;

    void Start()
    {

    }

    void Update()
    {
        time++;
        if (time >= spawnTicket)
        {
            int pointIndex = Random.Range(0, points.Length);

            index = Random.Range(0, listOfTickets.Length);
            currentTicket = listOfTickets[index];

            ticketspawning = Instantiate(currentTicket, points[pointIndex].position, Quaternion.identity);
            time = 0;
        }
    }
}
