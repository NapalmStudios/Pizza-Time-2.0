using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
   
    private Material currentPizzaMaterial;
    private Topping pizzaTopping;
    private List<Topping> toppingOrder = new List<Topping>();
    private List<Topping> toppingsPlaced = new List<Topping>();
    private int cookTimer;
    private bool cooked;
    private bool burnt;
    private string tableTag;
    private bool onTheTable;

    private void Start()
    {
        currentPizzaMaterial = GetComponent<Renderer>().material;
    }

    private bool CheckToppingOrder(Topping toppingCheck)
    {
        toppingsPlaced.Add(toppingCheck);

        while (toppingsPlaced.Count < toppingOrder.Count)
        {
            for (var i = 0; i < toppingOrder.Count; i++)
            {
                if (!toppingsPlaced[i].Equals(toppingOrder[i]))
                {
                    toppingsPlaced.Remove(toppingsPlaced[i]);
                    return false;
                }
            }
        }

        return true;
    }

    private void Cooked(int cookedTime, int burntTime)
    {
        cookTimer += (int)Time.deltaTime;

        if (cookTimer > cookedTime && cookTimer < burntTime)
        {
            cooked = true;    
        }
        else if (cookTimer > burntTime)
        {
           burnt = true;
        }
    }

    private Material ChangeTopping(Topping pizzaTopping)
    {
        Material pizzaMaterial;
        pizzaMaterial = pizzaTopping.toppingMaterial;

        if (cooked == true)
        {
            pizzaMaterial = pizzaTopping.cookedPizzaMaterial;
        }
        else if ( burnt == true)
        {
            pizzaMaterial = pizzaTopping.burntPizzaMaterial;
        }
        return pizzaMaterial;
    }

    private void CheckToppings()
    {
        int checkCounter = 0;
        Topping toppingHolder;
        int checkCounterFinal = 0;

        for (var i = 0; i<GameManager.instance.multipleToppings.Count; i++)
        {
            for (var j = 0; j < GameManager.instance.multipleToppings[i].multiTopping.Count; j++)
            {
                for (var k = 0; k < toppingsPlaced.Count; k++)
                {
                    if (toppingsPlaced[k].Equals(GameManager.instance.multipleToppings[j]))
                    {
                        checkCounter++;                      
                    }

                }

                if (checkCounter > checkCounterFinal)
                {
                    checkCounterFinal = checkCounter;
                    toppingHolder = GameManager.instance.multipleToppings[i];
                }

                checkCounter = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ToppingController>() != null)
        {
            // if topping is in hand
            var topper = collision.gameObject.GetComponent<ToppingController>();
            pizzaTopping = topper.topping;
        }

        if (collision.gameObject.CompareTag(tableTag))
        {
            onTheTable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(tableTag))
        {
            onTheTable = false;
        }
    }
}
