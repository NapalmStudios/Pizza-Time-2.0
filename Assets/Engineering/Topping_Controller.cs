using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public enum ToppingType {
    none,
    sauce,
    cheese,
    roni,
    peppers,
    mushroom,
    bacon
}

public class ToppingDefinition {
    public ToppingType type = ToppingType.none;
    public GameObject none;
    public GameObject sauce;
    public GameObject cheese;
    public GameObject roni;
    public GameObject peppers;
    public GameObject mushroom;
    public GameObject bacon;
}

public class Topping_Controller : MonoBehaviour {

    public static Topping_Controller S;

    public ToppingDefinition def;
    [SerializeField]
    public ToppingType _type = ToppingType.none;

    void Awake() {
        S = this;
    }

    void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void changeType (float level) {
        if(level == 0) {
            def.type = ToppingType.none;
        }
        if (level == 1) {
            def.type = ToppingType.sauce;
        }
        if (level == 2) {
            def.type = ToppingType.cheese;
        }
        if (level == 3) {
            def.type = ToppingType.roni;
        }
        if (level == 4) {
            def.type = ToppingType.peppers;
        }
        if (level == 5) {
            def.type = ToppingType.mushroom;
        }
        if (level == 6) {
            def.type = ToppingType.bacon;
        }
    }

}
