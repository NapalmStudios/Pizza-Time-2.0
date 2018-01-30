using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour {

	public GameObject pie;
	public GameObject pieloc;

	public class ingredients
	{
		public bool sauce;
		public bool cheese;
		public bool roni;
		public bool peppers;
		public bool mushrooms;
		public bool bacon;

		public bool dough;
		public bool cooked;
		public bool burnt;
	
	//constructor
		public ingredients ()
		{
			sauce = false;
			cheese = false;
			roni = false;
			peppers = false;
			mushrooms = false;
			bacon = false;



		}
	}


	public ingredients pizzaInstance = new ingredients ();


	void Start () {



		Debug.Log (pizzaInstance.sauce);
	}
}