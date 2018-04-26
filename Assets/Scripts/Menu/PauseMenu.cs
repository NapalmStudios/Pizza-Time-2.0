using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject menu;

        public void Pause()
        {
            if(menu.activeSelf)
            {
                //resume
                menu.SetActive(false);
            }
            else
            {
                //pause
                menu.SetActive(true);
            }
        }
    }
}