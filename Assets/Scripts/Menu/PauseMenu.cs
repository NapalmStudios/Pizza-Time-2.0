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

        void Start()
        {
            follower = GameObject.Find("HeadsetFollower");
        }

        public void Pause()
        {
            /*if(menu.activeSelf)
            {
                //resume
                menu.SetActive(false);
            }
            else
            {
                //pause
                menu.SetActive(true);
            } */
            var pos = follower.transform.position;
            if(!exitObj.activeSelf)
            {
                exitObj.SetActive(true);
                exitPizza.SetActive(true);
                exitObj.transform.position = new Vector3(pos.x+.4f, pos.y, pos.z-.2f);
                exitPizza.transform.position = new Vector3(pos.x+.4f, pos.y, pos.z+.2f);
            }
            else
            {
                exitObj.SetActive(false);
                exitPizza.SetActive(false);
            }
        }
    }
}