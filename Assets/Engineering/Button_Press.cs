using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem {
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class Button_Press : MonoBehaviour {

        public Button_Press S;

        public GameObject dough;
        public GameObject spawner;
        public GameObject topping;
        public UnityEvent onTriggerDown;
        public UnityEvent onTriggerUp;
        //public UnityEvent onGripDown;
        //public UnityEvent onGripUp;
        //public UnityEvent onTouchpadDown;
        //public UnityEvent onTouchpadUp;
        //public UnityEvent onTouchpadTouch;
        //public UnityEvent onTouchpadRelease;

        private void Awake() {
            S = this;
        }

        void Update() {
            for (int i = 0; i < Player.instance.handCount; i++) {
                Hand hand = Player.instance.GetHand(i);

                if (hand.controller != null) {
                    if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
                        onTriggerDown.Invoke();
                        //if (spawner.tag == "ts") {
                        //    Instantiate(topping, spawner.transform.position, spawner.transform.rotation);
                        //} else if (spawner.tag == "ds") {
                        //    Instantiate(topping, spawner.transform.position, spawner.transform.rotation);
                        //}
                        
                    }
                    
                    if (hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
                        onTriggerUp.Invoke();
                    }
                    
                    //if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)) {
                    //    onGripDown.Invoke();
                    //}
                    //
                    //if (hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip)) {
                    //    onGripUp.Invoke();
                    //}
                    //
                    //if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
                    //    onTouchpadDown.Invoke();
                    //}
                    //
                    //if (hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
                    //    onTouchpadUp.Invoke();
                    //}
                    //
                    //if (hand.controller.GetTouchDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
                    //    onTouchpadTouch.Invoke();
                    //}
                    //
                    //if (hand.controller.GetTouchUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
                    //    onTouchpadRelease.Invoke();
                    //}
                    
                }
            }

        }
        void Spawntopping() {
            Instantiate(topping, spawner.transform.position, spawner.transform.rotation);
        }
        void Spawndough() {
            Instantiate(dough, spawner.transform.position, spawner.transform.rotation);
        }
    }
}
