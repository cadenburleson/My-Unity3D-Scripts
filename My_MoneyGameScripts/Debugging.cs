using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debugging : MonoBehaviour {
	
	[SerializeField]
	private MoneyGameManager myGame;
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


		if (Input.GetKeyDown(KeyCode.M)) {

			Debug.Log (myGame.getMoneyVal ());
			d_moneyText.text = myGame.getMoneyVal().ToString();
			
//			Debug.Log("" + myGame.getMoney();
//			moneyText.text = money.ToString ("C");
		}

	}



}
