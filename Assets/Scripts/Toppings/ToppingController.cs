using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

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
        public GameObject toppingObject;
        public bool dirtyTopping = false;
        public int timeToDirty;
        private ResourceLoader resourceLoader;

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            toppingObject = this.gameObject;
        }

        void Update()
        {
            StartCoroutine(Grabbable());
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

        private IEnumerator Grabbable()
        {
            if(Time.timeScale < 1 && toppingObject.activeSelf)
            {
                toppingObject.SetActive(false);
                //GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                toppingObject.SetActive(true);
                //GetComponent<BoxCollider>().enabled = true;
            }
            yield return null;
        }
    }
}
