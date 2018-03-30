using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaTime
{
    public class PunchCardScoreClamp : MonoBehaviour
    {
        public Text nameLabel;

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(PunchCardText());
        }

        private IEnumerator PunchCardText()
        {
            Vector3 scorePos = Camera.main.WorldToScreenPoint(this.transform.position);
            nameLabel.transform.position = scorePos;
            nameLabel.transform.rotation = this.transform.rotation;
            yield return null;
        }
    }
}
