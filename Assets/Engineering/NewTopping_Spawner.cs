using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewTopping_Spawner : MonoBehaviour {
    //Test commit
    public GameObject spawn;
    public GameObject sspawn;
    public GameObject cspawn;
    public GameObject rspawn;
    public GameObject bspawn;
    public GameObject pspawn;
    public GameObject mspawn;
    public GameObject pizza;
    public GameObject sauce;
    public GameObject cheese;
    public GameObject roni;
    public GameObject bacon;
    public GameObject pepper;
    public GameObject mush;

    public bool reset = false;

    public Transform position;
    Transform oldposition;

	void Start () {
        oldposition = position;
	}
	
	void Update () {
	}

    void OnCollisionEnter(Collision col) {
        GameObject coll = col.gameObject;
        if (coll.tag == "dbutton") {
            Instantiate(pizza, spawn.transform.position, spawn.transform.rotation);
        }
        if (coll.tag == "tbutton") {
            GameObject[] s = GameObject.FindGameObjectsWithTag("sauce");
            for (int i = 0; i < s.Length; i++) Destroy(s[i].gameObject);
            GameObject[] c = GameObject.FindGameObjectsWithTag("cheese");
            for (int i = 0; i < c.Length; i++) Destroy(c[i].gameObject);
            GameObject[] r = GameObject.FindGameObjectsWithTag("roni");
            for (int i = 0; i < r.Length; i++) Destroy(r[i].gameObject);
            GameObject[] b = GameObject.FindGameObjectsWithTag("bacon");
            for (int i = 0; i < b.Length; i++) Destroy(b[i].gameObject);
            GameObject[] p = GameObject.FindGameObjectsWithTag("peppers");
            for (int i = 0; i < p.Length; i++) Destroy(p[i].gameObject);
            GameObject[] m = GameObject.FindGameObjectsWithTag("mushrooms");
            for (int i = 0; i < m.Length; i++) Destroy(m[i].gameObject);
            for (int i = 0; i < 2; i++) Instantiate(sauce, sspawn.transform.position, sspawn.transform.rotation);
            for (int i = 0; i < 2; i++) Instantiate(cheese, cspawn.transform.position, cspawn.transform.rotation);
            for (int i = 0; i < 4; i++) Instantiate(bacon, bspawn.transform.position, bspawn.transform.rotation);
            for (int i = 0; i < 4; i++) Instantiate(roni, rspawn.transform.position, rspawn.transform.rotation);
            for (int i = 0; i < 4; i++) Instantiate(pepper, pspawn.transform.position, pspawn.transform.rotation);
            for (int i = 0; i < 2; i++) Instantiate(mush, mspawn.transform.position, mspawn.transform.rotation);
        }
        if (coll.tag == "button") {
            SceneManager.LoadScene("Level_GreyBox");
        }
        if (coll.tag == "reset")
        {
            SceneManager.LoadScene("Level_GreyBox");
        }
    }
}
