using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaTime
{
    public class GameStartLoader : MonoBehaviour
    {
        public int gameStartSceneIndex;
        private ResourceLoader resourceLoader;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        }

        void OnCollisionEnter(Collision col)
        {
            GameObject obj = col.gameObject;
            if (obj.tag.Equals(resourceLoader.gameStartObj.tag))
            {
                //Starts Game from Menu Scene
                Destroy(obj);
                SceneManager.LoadScene(gameStartSceneIndex, LoadSceneMode.Single);
            }
        }
    }
}

