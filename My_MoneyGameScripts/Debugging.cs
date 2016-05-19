using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debugging : MonoBehaviour {
	
	[SerializeField]
	private GameObject debugPanel;

	public Text d_moneyText;


	public bool isDebugMenuActive;

	// Use this for initialization
	void Start () {
//		debugPanel.SetActive (true);
	}

	// Update is called once per frame
	void Update () {

//		toggleBool = !toggleBool;
//		this.gameObject.SetActive (toggleBool);
//
		if (Input.GetKeyUp (KeyCode.Space)) {
			Debug.Log ("You have pressed the debugger");
			isDebugMenuActive = !isDebugMenuActive;
			debugPanel.SetActive (isDebugMenuActive);
		}

	}



}
