using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_collider : MonoBehaviour {

    public int moveTime = 5;

    public GameObject button;

    private Vector3 oldPosition;
    private Quaternion oldRotation;

    public GameObject spawner;
    public GameObject topping;
    // Use this for initialization
    void Start () {

        oldPosition = button.transform.position;
        oldRotation = button.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void moveDough(GameObject top) {

    //}

    private void OnCollisionEnter(Collision coll) {
        GameObject col = coll.gameObject;
        if (col.tag == "tbutton") {
            Instantiate(topping, spawner.transform.position, spawner.transform.rotation);
            button.transform.position = oldPosition;
            button.transform.rotation = oldRotation;
        }
        if (col.tag == "dbutton") {
            Instantiate(topping, spawner.transform.position, spawner.transform.rotation);
            //for (int i = 0; i <= 5; i++) {
              //  moveDough(topping);
            //}
            button.transform.position = oldPosition;
            button.transform.rotation = oldRotation;

        }
    }

}
