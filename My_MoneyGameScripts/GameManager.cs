using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker.Actions;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance;

	public Player player;

	public ManagerController[] managers;

	public BusinessController[] business;

	void Awake(){
		if (Instance == null){
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}else if (Instance != this){
			Destroy (gameObject);
		}
	}


	void Start(){

	}


//**************************************************************************
//************** BUSINESS **************************************************
//**************************************************************************

	public void workBusiness(int businessNumberToWork){
		if (businessNumberToWork == 0) {
			business [0].WorkBusiness ();
		}
		if (businessNumberToWork == 1) {
			business [1].WorkBusiness ();
		}
		if (businessNumberToWork == 2) {
			business [2].WorkBusiness ();
		}
		if (businessNumberToWork == 3) {
			business [3].WorkBusiness ();
		}
		if (businessNumberToWork == 4) {
			business [4].WorkBusiness ();
		}
		if (businessNumberToWork == 5) {
			business [5].WorkBusiness ();
		}
			
	}
		
	public void buyBusiness(int businessNumberToBuy){
		if (businessNumberToBuy == 0) {
			business [0].BuyBusiness ();
		}
		if (businessNumberToBuy == 1) {
			business [1].BuyBusiness ();
		}
		if (businessNumberToBuy == 2) {
			business [2].BuyBusiness ();
		}
		if (businessNumberToBuy == 3) {
			business [3].BuyBusiness ();
		}
		if (businessNumberToBuy == 4) {
			business [4].BuyBusiness ();
		}
		if (businessNumberToBuy == 5) {
			business [5].BuyBusiness ();
		}


	}



}