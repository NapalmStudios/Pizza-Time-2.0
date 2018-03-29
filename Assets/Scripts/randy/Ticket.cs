using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TicketType
{
    IsCheese,
    IsSingle,
    IsDouble,
    IsTripple
}

public class Ticket : MonoBehaviour
{

    public TicketType ticketType;
   
    public bool isActive;

    public float ticketTime;
    public float tipTime; // counts down not up
    public int ticketWorth;
    public int dirtyNeg;


    private void Start()
    {
        isActive = true;
    }

    private void Update()
    {
        if (tipTime > 0)
        {
            tipTime -= Time.deltaTime;
        }

        if (tipTime < 0)
        {
            tipTime = 0;
        }

        if (ticketTime > 0)
        {
            ticketTime -= Time.deltaTime;
        }

        if (ticketTime <= 0)
        {
            isActive = false;
            //failed ticket
        }
    }

}
