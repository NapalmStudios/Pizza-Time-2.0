using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject exitObj;
        public GameObject exitPizza;
        private GameObject follower;
        private Quaternion exitRot;
        private Quaternion exitPizRot;
        private bool isPaused;

        private GameObject[] sauceObjects;
        private GameObject[] cheeseObjects;
        private GameObject[] roniObjects;
        private GameObject[] baconObjects;
        private GameObject[] pepperObjects;
        private GameObject[] mushroomObjects;
        private ResourceLoader resourceLoader;

        void Start()
        {
            follower = GameObject.Find("HeadsetFollower");
            exitRot = exitObj.transform.rotation;
            exitPizRot = exitPizza.transform.rotation;
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        }

        void Update()
        {
            StartCoroutine(PauseUp());
        }

        public void Pause()
        {
            var pos = follower.transform.position;
            if(!exitObj.activeSelf)
            {
                sauceObjects = GameObject.FindGameObjectsWithTag(resourceLoader.sauceObj.tag);
                cheeseObjects = GameObject.FindGameObjectsWithTag(resourceLoader.cheeseObj.tag);
                roniObjects = GameObject.FindGameObjectsWithTag(resourceLoader.roniObj.tag);
                baconObjects = GameObject.FindGameObjectsWithTag(resourceLoader.baconObj.tag);
                pepperObjects = GameObject.FindGameObjectsWithTag(resourceLoader.pepperObj.tag);
                mushroomObjects = GameObject.FindGameObjectsWithTag(resourceLoader.mushObj.tag);
                exitObj.SetActive(true);
                exitPizza.SetActive(true);
                exitObj.transform.position = new Vector3(pos.x+.4f, pos.y-.13f, pos.z-.2f);
                exitObj.transform.rotation = new Quaternion(exitRot.x, exitRot.y, exitRot.z, exitRot.w);
                exitPizza.transform.position = new Vector3(pos.x+.4f, pos.y-.13f, pos.z+.2f);
                exitPizza.transform.rotation = new Quaternion(exitPizRot.x, exitPizRot.y, exitPizRot.z, exitPizRot.w);
                isPaused = true;
            }
            else
            {
                exitObj.SetActive(false);
                exitPizza.SetActive(false);
                isPaused = false;
            }
            ArrayComb(sauceObjects);
            ArrayComb(cheeseObjects);
            ArrayComb(roniObjects);
            ArrayComb(baconObjects);
            ArrayComb(pepperObjects);
            ArrayComb(mushroomObjects);
        }

        private void ArrayComb(GameObject[] objs)
        {
            if(isPaused)
            {
                foreach (GameObject obj in objs)
                {
                    obj.SetActive(false);
                }
            }
            else
            {
                foreach (GameObject obj in objs)
                {
                    obj.SetActive(true);
                }
            }
        }

        private IEnumerator PauseUp()
        {
            if(isPaused)
            {
                Time.timeScale = .00035f;
            }
            else
            {
                Time.timeScale = 1;
            }
            yield return null;
        }
    }
}