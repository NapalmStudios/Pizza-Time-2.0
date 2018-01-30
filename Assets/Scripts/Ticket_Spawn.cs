using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ticket_Spawn : MonoBehaviour
{

    public NewTopping_Spawner toppingSpawner;

	public GameObject[] tickets;
    public GameObject reset;
	public string[] order;
	public Material cheese;
	public Material roni;
	public Material peppers;
	public Material mushrooms;
	public Material bacon;
	public Material roniandbacon;
	public Material roniandpeppers;
	public Material roniandmush;
	public Material peppersandmush;
	public Material peppersandbacon;
	public Material baconandmush;
	public Material roniandbaconandpep;
	public Material roniandbaconandmush;
	public Material roniandPepandmush;
	public Material mushandbaconandpep;
	public Material theworks;

    public float fullPoints = 1;
    public float multiplier = 3;
    int ticketNumber;
    float totalScore = 0;
    /*
    float timeOne = 0;
    float timeTwo = 0;
    float timeThree = 0;
    float timeFour = 0;
    float timeFive= 0;
    float timeSix = 0;
    */

	public int randticket;
	public int ticketnum = 5;
	public int currentticket = 0;
	public int spawndelay;

    //public AudioSource pizzaTime;
    public Transform audioPlay;

	private bool iscorrect = false;
	public int strikes = 0;
	public int points = 0;

	public Text scoreText;
	public Text strikeText;
	public Text winText;

	public string ezmode = "";

	void SpawnTicket ()
	{
		tickets [currentticket].SetActive (true);
		if (ezmode == "yes") {
			randticket = Random.Range (1, 6);
		} else {
			randticket = Random.Range (1, 16);
		}
		switch (randticket) {
		case 1:
			tickets [currentticket].GetComponent<Renderer> ().material = cheese;
			order [currentticket] = "cheese";
			break;

		case 2:
			tickets [currentticket].GetComponent<Renderer> ().material = roni;
			order [currentticket] = "roni";
			break;

		case 3:
			tickets [currentticket].GetComponent<Renderer> ().material = peppers;
			order [currentticket] = "peppers";
			break;

		case 4:
			tickets [currentticket].GetComponent<Renderer> ().material = mushrooms;
			order [currentticket] = "mushrooms";
			break;

		case 5:
			tickets [currentticket].GetComponent<Renderer> ().material = bacon;
			order [currentticket] = "bacon";
			break;

		case 6:
			tickets [currentticket].GetComponent<Renderer> ().material = roniandbacon;
			order [currentticket] = "roniandbacon";
			break;

		case 7:
			tickets [currentticket].GetComponent<Renderer> ().material = roniandpeppers;
			order [currentticket] = "roniandpeppers";
			break;

		case 8:
			tickets [currentticket].GetComponent<Renderer> ().material = roniandmush;
			order [currentticket] = "roniandmush";
			break;

		case 9:
			tickets [currentticket].GetComponent<Renderer> ().material = peppersandmush;
			order [currentticket] = "peppersandmush";
			break;


		case 10:
			tickets [currentticket].GetComponent<Renderer> ().material = peppersandbacon;
			order [currentticket] = "peppersandbacon";
			break;

		case 11:
			tickets [currentticket].GetComponent<Renderer> ().material = baconandmush;
			order [currentticket] = "baconandmush";
			break;

		case 12:
			tickets [currentticket].GetComponent<Renderer> ().material = roniandbaconandpep;
			order [currentticket] = "roniandbaconandpep";
			break;

		case 13:
			tickets [currentticket].GetComponent<Renderer> ().material = roniandbaconandmush;
			order [currentticket] = "roniandbaconandmush";
			break;

		case 14:
			tickets [currentticket].GetComponent<Renderer> ().material = roniandPepandmush;
			order [currentticket] = "roniandPepandmush";
			break;

		case 15:
			tickets [currentticket].GetComponent<Renderer> ().material = mushandbaconandpep;
			order [currentticket] = "mushandbaconandpep";
			break;

		case 16:
			tickets [currentticket].GetComponent<Renderer> ().material = theworks;
			order [currentticket] = "theworks";
			break;

		}
		currentticket = currentticket + 1;
		spawndelay = Random.Range (10, 20);

	}
    

	void Start ()
	{
        scoreText.text = "Score: " + totalScore;
        winText.text = "Noob";
        StartCoroutine (TicketSpawn ());
	}

	IEnumerator TicketSpawn()
	{
		SpawnTicket ();
		yield return new WaitForSeconds(spawndelay);
		SpawnTicket ();
		yield return new WaitForSeconds(spawndelay);
		SpawnTicket ();
		yield return new WaitForSeconds(spawndelay);
		SpawnTicket ();
		yield return new WaitForSeconds(spawndelay);
		SpawnTicket ();
		yield return new WaitForSeconds(spawndelay);
		SpawnTicket ();
	}
    
	void SetScoreText(int num)
	{
        switch (num) {
            case 0:
                totalScore = totalScore + (fullPoints * multiplier);
                scoreText.text = "Score: " + totalScore;
                break;
            case 1:
                totalScore = totalScore + (fullPoints * multiplier);
                scoreText.text = "Score: " + totalScore;
                break;
            case 2:
                totalScore = totalScore + (fullPoints * multiplier);
                scoreText.text = "Score: " + totalScore;
                break;
            case 3:
                totalScore = totalScore + (fullPoints * multiplier);
                scoreText.text = "Score: " + totalScore;
                break;
            case 4:
                totalScore = totalScore + (fullPoints * multiplier);
                scoreText.text = "Score: " + totalScore;
                break;
            case 5:
                totalScore = totalScore + (fullPoints * multiplier);
                scoreText.text = "Score: " + totalScore;
                break;
            case 6:
                strikeText.text = "Strikes: " + strikes + "/3";
                multiplier--;
                break;
        }

        if (totalScore == 0) winText.text = "Noob";
        else if (totalScore <= 600) winText.text = "Novice";
        else if (totalScore <= 1200) winText.text = "Hobbyist";
        else if (totalScore < 1800) winText.text = "Pro";
        else if (totalScore == 1800) winText.text = "Pizza God";
        if (strikes >= 3 && totalScore > 600) {
			winText.text = "You're Fired!";
            reset.SetActive(true);
		} else if (strikes >= 3 && totalScore <= 600) {
            winText.text = "Just Leave";
            reset.SetActive(true);

        }

	}

	void OnCollisionEnter (Collision col)
    {
        for (int i = 0; i < order.Length; i++) {
			if (order [i] == col.gameObject.GetComponent<Pizza_Controller> ().pizzatype) {
                ticketNumber = i;
				iscorrect = true;
				tickets [i].SetActive (false);
				order [i] = "done";
                break;
			}
			else {
                ticketNumber = 6;
				print ("nope");
				iscorrect = false;
            }
        }
        if (iscorrect == true && col.gameObject.tag == "dough")
        {
            SetScoreText(ticketNumber);
            points++;
            Destroy(col.gameObject);
        }
        else if (iscorrect == false && col.gameObject.tag == "dough")
        {
            strikes = strikes + 1;
            SetScoreText(ticketNumber);
            Destroy(col.gameObject);
        }
        if (points == 6) reset.SetActive(true);
    }
}
