using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class Player : MonoBehaviour {

	public string playerId;

	public string playerName = "vagina";

	[SerializeField]
	float moneyChecker; //used to see what the players money is in the inspector

	public float money;

	public Text moneyText;

	FileService fileService;

	Player myPlayer;
			

	void Start () {
		
		fileService = new FileService ();

		if (myPlayer == null) {
			myPlayer = new Player (playerId);
		}

		fileService.loadPlayer (myPlayer);

		updateMoneyText ();
	}
		
	void Update () {
		moneyChecker = money;
	}
		

	// Constructors
	public Player () {}

	// Class can have multiple constructor methods
	public Player(string newPlayerId) {
		playerId = newPlayerId;
		//this.id = name;
	}
		

	public string getName() {
		return playerName;
	}
	public void setName(string name) {
		playerName = name;
	}

	public float getMoneyVal() {
		return money;
	}
	public void setMoneyVal(float newMoneyVal) {
		money = newMoneyVal;
//		fileService.savePlayer (myPlayer);
	}
	public void updateMoneyText () {
		moneyText.text = money.ToString("C");
//		Debug.Log("update Money Text >> player.money = " + money);
	}
		
}

[Serializable]
class PlayerData {
	public float money;
}
