using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PizzaTime;

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
    public float tipTime;
    public int ticketWorth;
    public int dirtyNeg;
    public Material pizzaMat;
    private TicketSpawn ticketSpawn;

    private void Start()
    {
        isActive = true;
        ticketSpawn = GetComponent<TicketSpawn>();
    }

    private void Update()
    {
        TipTiming();
        if (isActive == false)
        {

        }
    }

    private void TipTiming()
    {
        if(tipTime > 0)
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
        }

        if(isActive == false)
        {
          //  Destroy(gameObject);
        }
    }
}
