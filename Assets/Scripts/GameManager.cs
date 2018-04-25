using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int cookTimer;
    public int burnTimmer;
    public List<Topping> multipleToppings = new List<Topping>();

    public List<Ticket> currentTickets = new List<Ticket>();

    public void AddToTicketList()
    {
        // Add new ticket to list od tickets
        //currentTickets.Add()
    }

    private void RemoveFromList()
    {
        // remove forom list when pizza complete
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }        
    }

    public void PizzaCheck()
    {
        // check if pizza is correct to  a tick vurrent on a list
    }
}
