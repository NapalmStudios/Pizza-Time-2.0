using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace PizzaTime
{
    public class NewTopping_Spawner : MonoBehaviour
    {

        private GameObject pizzaSpawnPosition;
        private GameObject sauceSpawnPosition;
        private GameObject cheeseSpawnPosition;
        private GameObject roniSpawnPosition;
        private GameObject baconSpawnPosition;
        private GameObject pepperSpawnPosition;
        private GameObject mushSpawnPosition;
        private GameObject pizzaObjForSpawner;
        private GameObject sauceObjForSpawner;
        private GameObject cheeseObjForSpawner;
        private GameObject roniObjForSpawner;
        private GameObject baconObjForSpawner;
        private GameObject pepperObjForSpawner;
        private GameObject mushObjForSpawner;
        private ResourceLoader resourceLoader;
        public bool reset = false;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            // ------------------- Topping Object Initalization ------------------------ \\
            pizzaObjForSpawner = resourceLoader.pizzaObj;
            sauceObjForSpawner = resourceLoader.sauceObj;
            cheeseObjForSpawner = resourceLoader.cheeseObj;
            roniObjForSpawner = resourceLoader.roniObj;
            baconObjForSpawner = resourceLoader.baconObj;
            pepperObjForSpawner = resourceLoader.pepperObj;
            mushObjForSpawner = resourceLoader.mushObj;
            // ------------------------------------------------------------------------- \\

            // ------------------- Topping Spawn Initalization ------------------------- \\
            pizzaSpawnPosition = GameObject.Find("Dough_Spawn");
            sauceSpawnPosition = GameObject.Find("Sauce_Spawn");
            cheeseSpawnPosition = GameObject.Find("Cheese_Spawn");
            roniSpawnPosition = GameObject.Find("Roni_Spawn");
            baconSpawnPosition = GameObject.Find("Bacon_Spawn");
            pepperSpawnPosition = GameObject.Find("Pepper_Spawn");
            mushSpawnPosition = GameObject.Find("Mushroom_Spawn");
            // ------------------------------------------------------------------------- \\
        }

        void OnCollisionEnter(Collision col)
        {
            GameObject coll = col.gameObject;
            if (coll.tag == "dbutton")
            {
                Instantiate(pizzaObjForSpawner, pizzaSpawnPosition.transform.position, pizzaSpawnPosition.transform.rotation);
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
                for (int i = 0; i < 2; i++) Instantiate(sauceObjForSpawner, sauceSpawnPosition.transform.position, sauceSpawnPosition.transform.rotation);
                for (int i = 0; i < 2; i++) Instantiate(cheeseObjForSpawner, cheeseSpawnPosition.transform.position, cheeseSpawnPosition.transform.rotation);
                for (int i = 0; i < 4; i++) Instantiate(baconObjForSpawner, baconSpawnPosition.transform.position, baconSpawnPosition.transform.rotation);
                for (int i = 0; i < 4; i++) Instantiate(roniObjForSpawner, roniSpawnPosition.transform.position, roniSpawnPosition.transform.rotation);
                for (int i = 0; i < 4; i++) Instantiate(pepperObjForSpawner, pepperSpawnPosition.transform.position, pepperSpawnPosition.transform.rotation);
                for (int i = 0; i < 2; i++) Instantiate(mushObjForSpawner, mushSpawnPosition.transform.position, mushSpawnPosition.transform.rotation);
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
