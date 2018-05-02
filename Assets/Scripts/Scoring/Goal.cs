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

    private bool waitDestroy;

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
        if((score == targetScore) || strikeCount >= 3)
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
            for (int i = 0; i < ticketSpawner.currentTickets.Length; i++)
            {
                var ticket = ticketSpawner.currentTickets[i];

                if (pizzaObj.activePizzaTexture.Equals(ticket.pizzaMat) && ticket.isActive == true)
                {
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
                    ticketSpawner.currentTickets[i] = null;
                    Destroy(col.gameObject);
                    break;
                }
                else
                {
                    strikeCount++;
                    if(strikeCount == 1)
                    {
                        strikes.text = "Strikes: X";
                    }
                    else if (strikeCount == 2)
                    {
                        strikes.text = "Strikes: X  X";
                    }
                    else if(strikeCount == 3)
                    {
                        strikes.text = "Strikes: X  X  X";
                    }
                    Destroy(col.gameObject);
                    break;
                }
            }
        }
    }
}
