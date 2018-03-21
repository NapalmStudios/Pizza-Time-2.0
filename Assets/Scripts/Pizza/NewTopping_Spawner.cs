using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace PizzaTime
{
    public class NewTopping_Spawner : MonoBehaviour
    {

        private GameObject spawn;
        private GameObject sspawn;
        private GameObject cspawn;
        private GameObject rspawn;
        private GameObject bspawn;
        private GameObject pspawn;
        private GameObject mspawn;
        private GameObject pizzaObjForSpawner;
        private GameObject sauceObjForSpawner;
        private GameObject cheeseObjForSpawner;
        private GameObject roniObjForSpawner;
        private GameObject baconObjForSpawner;
        private GameObject pepperObjForSpawner;
        private GameObject mushObjForSpawner;
        private ResourceLoader resourceLoader = new ResourceLoader();
        public bool reset = false;

        public Transform position;
        Transform oldposition;

        void Start()
        {
            oldposition = position;
            // ------------------- Object Initalization ------------------------ \\
            
            pizzaObjForSpawner = resourceLoader.pizza;
            sauceObjForSpawner = resourceLoader.sauce;
            cheeseObjForSpawner = resourceLoader.cheese;
            roniObjForSpawner = resourceLoader.roni;
            baconObjForSpawner = resourceLoader.bacon;
            pepperObjForSpawner = resourceLoader.pepper;

            // ------------------------------------------------------------------ \\
        }

        void Update()
        {
        }

        void OnCollisionEnter(Collision col)
        {
            GameObject coll = col.gameObject;
            if (coll.tag == "dbutton")
            {
                Instantiate(pizzaObjForSpawner, spawn.transform.position, spawn.transform.rotation);
            }
            if (coll.tag == "tbutton")
            {
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
                for (int i = 0; i < 2; i++) Instantiate(sauceObjForSpawner, sspawn.transform.position, sspawn.transform.rotation);
                for (int i = 0; i < 2; i++) Instantiate(cheeseObjForSpawner, cspawn.transform.position, cspawn.transform.rotation);
                for (int i = 0; i < 4; i++) Instantiate(baconObjForSpawner, bspawn.transform.position, bspawn.transform.rotation);
                for (int i = 0; i < 4; i++) Instantiate(roniObjForSpawner, rspawn.transform.position, rspawn.transform.rotation);
                for (int i = 0; i < 4; i++) Instantiate(pepperObjForSpawner, pspawn.transform.position, pspawn.transform.rotation);
                for (int i = 0; i < 2; i++) Instantiate(mushObjForSpawner, mspawn.transform.position, mspawn.transform.rotation);
            }
            if (coll.tag == "button")
            {
                SceneManager.LoadScene("Level_GreyBox");
            }
            if (coll.tag == "reset")
            {
                SceneManager.LoadScene("Level_GreyBox");
            }
        }
    }
}
