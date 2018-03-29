using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delivered : MonoBehaviour {


    public static int score;
    Text text;

    //test
    void Awake()
    {
        text = GetComponent<Text>();
        score = 2;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            text.text = "Pizzas Delivered: " + score;
        }
    }
}
