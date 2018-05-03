using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioLoader : MonoBehaviour {

	void Awake () {
		SceneManager.LoadScene("Audio", LoadSceneMode.Additive);
		// Fabric.EventManager.Instance.PostEvent("Music - Start Main Music");
	}
}
