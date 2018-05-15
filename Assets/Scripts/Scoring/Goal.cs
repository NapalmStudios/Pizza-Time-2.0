using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PizzaTime;
using TMPro;

public class Goal : MonoBehaviour
{
    public int tip;
    public int score;
    public int targetScore;
    public int pizzasMade;
    public int strikeCount;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI strikes;

    private Ticket ticket;
    private bool populate = false;
    public bool match = false;
    public bool noMatch = false;
    public bool completed = false;
    public List<Material> test = new List<Material>();

    public TicketSpawn ticketSpawner;

    void Start()
    {
        ticketSpawner = FindObjectOfType<TicketSpawn>();
    }

    void Update()
    {
        //ticketSpawner = FindObjectOfType<TicketSpawn>();
        StartCoroutine(CheckForScore());
        
    }

    private IEnumerator CheckForScore()
    {
        if ((score == targetScore) || strikeCount >= 3)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        yield return null;
    }

    private void OnTriggerEnter(Collider col)
    {
        var pizzaObj = col.gameObject.GetComponent<Pizza_Controller>();
        if (pizzaObj != null)
        {
            //StartCoroutine(Scoring(col.gameObject, pizzaObj));
            LoopThroughTickets(pizzaObj);
            
                if (match)
                {
                    Fabric.EventManager.Instance.PostEvent("State - Success (Random)");
                    if (pizzaObj.isDirty)
                    {
                        score += (ticket.ticketWorth + (tip * (int)ticket.tipTime)) - ticket.dirtyNeg;
                    }
                    else
                    {
                        score += ticket.ticketWorth + (tip * (int)ticket.tipTime);
                    }
                    tmp.text = "Today's Earnings = $" + score;
                    ticket.isActive = false;
                    pizzasMade++;
                    //ticketSpawner.currentTickets[i] = null;
                    Destroy(col.gameObject);
                    match = false;
                }
                else if(noMatch)
                {
                    strikeCount++;
                    Fabric.EventManager.Instance.PostEvent("State - Ticket Failure");
                    if (strikeCount == 1)
                    {
                        strikes.text = "Strikes: X";
                    }
                    else if (strikeCount == 2)
                    {
                        strikes.text = "Strikes: X  X";
                    }
                    else if (strikeCount == 3)
                    {
                        strikes.text = "Strikes: X  X  X";
                    }
                    Destroy(col.gameObject);
                    noMatch = false;
                }
        }
    }

    public void LoopThroughTickets(Pizza_Controller pizzaObj)
    {
        var test = GameObject.FindObjectsOfType<Ticket>();
        foreach (Ticket obj in test)
        {
            if (pizzaObj.activePizzaTexture.Equals(obj.pizzaMat))
            {
                ticket = obj;
                match = true;
            }
            else
            {
                noMatch = true;
            }
        }
    }
}
