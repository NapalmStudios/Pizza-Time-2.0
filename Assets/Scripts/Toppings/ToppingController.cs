using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public enum TOPPING
    {
        Sauce,
        Cheese,
        Roni,
        Bacon,
        Peppers,
        Mushrooms
    };

    public class ToppingController : MonoBehaviour
    {
        public TOPPING toppingType;
        public bool dirtyTopping = false;
        public int timeToDirty;
        private ResourceLoader resourceLoader;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        }

        private void OnCollisionStay(Collision col)
        {
            var objTag = col.gameObject.tag;
            if(objTag.Equals(resourceLoader.floorObj.tag) && !gameObject.tag.Equals(resourceLoader.sauceObj.tag))
            {
                StartCoroutine(DirtyTopping());
            }
        }

        private IEnumerator DirtyTopping()
        {
            yield return new WaitForSeconds(timeToDirty);
            dirtyTopping = true;
        }
    }
}
