using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaTime
{
    public class MenuSelector : MonoBehaviour
    {
        public bool isStartObj;
        public bool isExitObj;

        void Start()
        {
            isStartObj = gameObject.GetComponent<MenuSelector>().isStartObj;
            isExitObj = gameObject.GetComponent<MenuSelector>().isExitObj;
            
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
            }
        }
    }
}
