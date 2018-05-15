using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaTime
{
    public class MenuSelector : MonoBehaviour
    {
        public bool isStartObj;
        public bool isExitInGameObj;
        public bool isExitObj;

        void Start()
        {
            isStartObj = gameObject.GetComponent<MenuSelector>().isStartObj;
            isExitObj = gameObject.GetComponent<MenuSelector>().isExitObj;
            isExitInGameObj = gameObject.GetComponent<MenuSelector>().isExitInGameObj;
        }

        void OnCollisionEnter(Collision col)
        {
            var Obj = col.gameObject;
            if (col.gameObject.GetComponent<Pizza_Controller>() != null)
            {
                if(isStartObj)
                {
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                    Destroy(this.gameObject);
                }
                else if(isExitObj)
                {
                    Application.Quit();
                    Destroy(this.gameObject);
                }
                else if (isExitInGameObj)
                {
                    SceneManager.LoadScene(0, LoadSceneMode.Single);
                    Time.timeScale = 1;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
