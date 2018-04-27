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

        void Start()
        {
            follower = GameObject.Find("HeadsetFollower");
            exitRot = exitObj.transform.rotation;
            exitPizRot = exitPizza.transform.rotation;
        }

        public void Pause()
        {
            var pos = follower.transform.position;
            if(!exitObj.activeSelf)
            {
                exitObj.SetActive(true);
                exitPizza.SetActive(true);
                exitObj.transform.position = new Vector3(pos.x+.4f, pos.y-.13f, pos.z-.2f);
                exitObj.transform.rotation = new Quaternion(exitRot.x, exitRot.y, exitRot.z, exitRot.w);
                exitPizza.transform.position = new Vector3(pos.x+.4f, pos.y-.13f, pos.z+.2f);
                exitPizza.transform.rotation = new Quaternion(exitPizRot.x, exitPizRot.y, exitPizRot.z, exitPizRot.w);
            }
            else
            {
                exitObj.SetActive(false);
                exitPizza.SetActive(false);
            }
        }
    }
}