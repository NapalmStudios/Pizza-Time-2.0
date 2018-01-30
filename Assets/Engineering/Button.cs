namespace VRTK.Examples {
    using UnityEngine;
    using UnityEventHelper;

    public class Button : MonoBehaviour {
        public GameObject topping;
        public Transform spawner;

        private VRTK_Button_UnityEvents buttonEvents;

        private void Start() {
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null) {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }
        private void handlePush(object sender, Control3DEventArgs e) {
            GameObject newGo = (GameObject)Instantiate(topping, spawner.position, Quaternion.identity);
            }
    }
}