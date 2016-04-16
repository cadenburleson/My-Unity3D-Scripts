using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PullUpHud : MonoBehaviour {

	public GameObject uiHud;
	private bool isTheHudOn;

	// Use this for initialization
	void Start () {
		uiHud.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// If you press the E key do :
		if (Input.GetKeyUp(KeyCode.E)) {
			checkStateOfHud ();
		}
	}

	void checkStateOfHud () {
		if (uiHud.activeSelf == false) {
			uiHud.SetActive (true);	
		} else {
			uiHud.SetActive (false);
		}
	}


}
