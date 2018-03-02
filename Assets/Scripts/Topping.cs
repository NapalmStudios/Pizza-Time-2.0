using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pizza Topping")]
public class Topping : ScriptableObject {

    public string ToppingName;
    public Material toppingMaterial;
    public Material cookedPizzaMaterial;
    public Material burntPizzaMaterial;
    public List<Topping> multiTopping = new List<Topping>();
	
}
