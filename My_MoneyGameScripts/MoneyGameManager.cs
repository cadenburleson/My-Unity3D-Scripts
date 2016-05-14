using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;

public class MoneyGameManager : MonoBehaviour {

	private float money = 0;
	public Text moneyText;

	public GameObject managerWindow;
	public bool isManagersMenuOn = false;

	void Start () {
		// Put this in one of the increase functions or decrease functions 
		moneyText.text = money.ToString ("C");
	}

	void Update () {

		if (isManagersMenuOn == false) {
			
		}

//		timer += Time.deltaTime;
//		string minutes = Mathf.Floor(timer / 60).ToString("00");
//		string seconds = Mathf.Floor(timer % 60).ToString("00");
//		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
//		timeSinceGameStart_Text.text = niceTime;
//		timeSinceGameStart_Text.text = Time.realtimeSinceStartup.ToString("N");
//		timeSinceGameStart_Text.text = Time.realtimeSinceStartup.ToString("00:00");
	
	}

	public void displayManagersWindow () {
		
	}
								
	public void IncreaseMoney(float amount) {
		money = money + amount;
		moneyText.text = money.ToString ("C");
	}

	public void DecreaseMoney(float amount) {
		money = money - amount;
		moneyText.text = money.ToString ("C");
	}
		
	public float getMoneyVal() {
		return money;
	}




}

