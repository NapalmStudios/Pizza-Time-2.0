using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Anim : MonoBehaviour {

    Animation button;
    public GameObject topping;
    public GameObject spawner;
    public GameObject buttonObject;
    /*
    public GameObject roniSpawner;
    public GameObject doughSpawner;
    public GameObject cheeseSpawner;
    public GameObject baconSpawner;
    public GameObject mushroomSpawner;
    public GameObject pepperSpawner;
    public GameObject sauceSpawner;
    public GameObject sauce;
    public GameObject cheese;
    public GameObject roni;
    public GameObject mushroom;
    public GameObject bacon;
    public GameObject pepper;
    public GameObject dough;
    */

    void Start () {
        buttonObject = this.gameObject;
	}
	
	
	void Update () {
		//if () {
        //    buttonType();
        //}
	}

    public void Spawn() {
        Instantiate(topping, spawner.transform.position, spawner.transform.rotation);
    }

    public void buttonType() {
        /*
        if (buttonObject.tag == "rbutton")
            Instantiate(roni, roniSpawner.transform.position, roniSpawner.transform.rotation);
        else if (buttonObject.tag == "pbutton")
            Instantiate(pepper, pepperSpawner.transform.position, pepperSpawner.transform.rotation);
        else if (buttonObject.tag == "bbutton")
            Instantiate(bacon, baconSpawner.transform.position, baconSpawner.transform.rotation);
        else if (buttonObject.tag == "cbutton")
            Instantiate(cheese, cheeseSpawner.transform.position, cheeseSpawner.transform.rotation);
        else if (buttonObject.tag == "mbutton")
            Instantiate(mushroom, mushroomSpawner.transform.position,mushroomSpawner.transform.rotation);
        else if (buttonObject.tag == "sbutton")
            Instantiate(sauce, sauceSpawner.transform.position, sauceSpawner.transform.rotation);
        else if (buttonObject.tag == "dbutton") {
            Instantiate(dough, doughSpawner.transform.position, doughSpawner.transform.rotation);
        }
        */
    }
}
