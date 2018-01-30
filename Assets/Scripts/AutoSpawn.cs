using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawn : MonoBehaviour {


	public GameObject ingredient;
	public GameObject spawnarea;
	public string tagname;
	public int spawnlimit;
	public static int spawnnum;
    public int objs = 0;



	void Start () {
        for (int i =0; i < spawnlimit; i++) {
            Instantiate(ingredient, spawnarea.transform.position, spawnarea.transform.rotation);
            objs++;
        }
    }

	void spawn () {
        if (objs < spawnlimit) Instantiate(ingredient, spawnarea.transform.position, spawnarea.transform.rotation);
    }
}
