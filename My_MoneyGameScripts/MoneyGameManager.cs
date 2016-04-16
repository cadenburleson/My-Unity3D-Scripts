using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;

public class MoneyGameManager : MonoBehaviour {

	public static float money = 0;
	public Text moneyText;
//	private string timeSinceStartFloat_Handle;
//	public Text timeSinceGameStart_Text;
//	private float myTime;
//	public float timer;

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
//		PlayerPrefs.SetFloat ("playerMoney", money);
		// Put this in one of the increase functions or decrease functions 
		moneyText.text = money.ToString ("C");
//		moneyText.text = ("$" + money.ToString("N"));
	}

	public void DecreaseMoney(float amount) {
		money = money - amount;
//		PlayerPrefs.SetFloat ("playerMoney", money);
		// Put this in one of the increase functions or decrease functions 
		moneyText.text = money.ToString ("C");
//		moneyText.text = ("$" + money.ToString());
	}



}

