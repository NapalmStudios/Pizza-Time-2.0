using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawner : MonoBehaviour {

    private List<ToppingController> fridgeToppings = new List<ToppingController>();
    private List<Transform> fridgeSpace = new List<Transform>();
    private List<ToppingController> sliceToppings = new List<ToppingController>();
    private List<Transform> spawnPoint = new List<Transform>();

    public Collider slicer;

    private void FrigeSpawner()
    {
        // check if there is already a topping in there
        for (var i = 0; i < fridgeToppings.Count; i++)
        {
             Instantiate(fridgeToppings[i], fridgeSpace[i].position, fridgeSpace[i].rotation);
        }
    }

    private void SlicerSpawner()
    {
        // do something maybe
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ToppingSpawner>() != null)
        {
            // if pull lever will is conut everything
        }
    }
}
