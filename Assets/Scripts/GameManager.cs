using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public int cookTimer;
    public int burnTimmer;
    public List<Topping> multipleToppings = new List<Topping>();
    private List<Ticket> currentTickets = new List<Ticket>();

    private void AddToTicketList()
    {
        //currentTickets.Add() the ticket that spawned
    }

    private void RemoveFromList()
    {

    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }        
    }
}
