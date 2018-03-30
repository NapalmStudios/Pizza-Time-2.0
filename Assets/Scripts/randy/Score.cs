using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public static int score;
    Text text;
    
    ///test
    void Awake()
    {
        text = GetComponent<Text>();
        score = 10;
    }

    void Update()
    {
    //    if (Input.GetKey(KeyCode.Space))
    //    {           
            text.text = "Score: " + score;
    //    }
    }
}