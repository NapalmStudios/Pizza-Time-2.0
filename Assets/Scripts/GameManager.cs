using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public int cookTimer;
    public int burnTimmer;
    public List<Topping> multipleToppings = new List<Topping>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }        
    }
}
