using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileService {

	// *********** BUSINESS *******************************************************
	public Business loadBusinessById(string businessId) {
		Debug.Log (">> FileService is loading Business by the id of : " + businessId + ", please wait...");

		Business business = null;

		if (File.Exists (Application.persistentDataPath + "/biz_" + businessId + ".dat") ) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/biz_" + businessId + ".dat", FileMode.Open);
			business = (Business)bf.Deserialize (file);
			file.Close ();

			Debug.Log ("<< FileService returning business: " + business.getId());
			Debug.Log ("FileService - LOAD - Data ~~" + Application.persistentDataPath);
		}
		return business;
	}

	public void saveBusiness(Business business) {
		BinaryFormatter bf = new BinaryFormatter ();

		FileStream file = File.Open (Application.persistentDataPath + "/biz_" + business.getId() + ".dat", FileMode.OpenOrCreate);

		bf.Serialize (file, business);
		file.Close ();
//		Debug.Log (">> FileService save: " + business.getId() );
//		Debug.Log (">> FileService save: " + business.getName() );
//		Debug.Log ("<< qtyOwned: " + business.getQuantityOwned());
		//		Debug.Log ("FileService - SAVE - Data .." + Application.persistentDataPath);
	}

	public void deleteBusinessById(string businessId) {
		if (File.Exists (Application.persistentDataPath + "/biz_" + businessId + ".dat") ) {
			Debug.Log ("Business : " + businessId + " has just been deleted.");
			File.Delete(Application.persistentDataPath + "/biz_" + businessId + ".dat");
		}
	}

	// *********** Player *******************************************************
	public Player loadPlayer(Player player) {
		Debug.Log (">> FileService is loading PlayerData: " + player.getName() + ", please wait...");
//		Player player = null;
		if (File.Exists (Application.persistentDataPath + "/player_" + player.getName() + ".dat") ) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/player_" + player.getName() + ".dat", FileMode.Open);
//			player = (Player)bf.Deserialize (file);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();

			Player p;
			p = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
			p.money = data.money;

			Debug.Log ("<< FileService returning Player: " + player.getName ());
//			Debug.Log ("FileService - LOAD - Data ~~" + Application.persistentDataPath);
		}
		return player;
	}
		
	public void savePlayer(Player player) {
		BinaryFormatter bf = new BinaryFormatter ();

//		FileStream file = File.Open (Application.persistentDataPath + "/player_" + player.getName() + ".dat", FileMode.OpenOrCreate);
		FileStream file = File.Create (Application.persistentDataPath + "/player_" + player.getName() + ".dat");

		PlayerData p = new PlayerData ();

		p.money = player.money;

		bf.Serialize (file, p);

		file.Close ();

//		Debug.Log (">> FileService save: " + player.getName());

	}

	// *********** Player *******************************************************
	public ManagerData loadManager(string managerName) {	
		
		ManagerData mgd = null;	

		if (File.Exists (Application.persistentDataPath + "/manager_" + managerName + ".dat") ) {
			
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream file = File.Open (Application.persistentDataPath + "/manager_" + managerName + ".dat", FileMode.Open);

			mgd = (ManagerData)bf.Deserialize(file);

			file.Close ();

			Debug.Log ("<< FileService returning Manager: " + managerName);
		}

		return mgd;

	}
		
	public void saveManager(ManagerData managerData) {
		
		BinaryFormatter bf = new BinaryFormatter ();

//		FileStream file = File.Open (Application.persistentDataPath + "/manager_" + managerData.getName() + ".dat", FileMode.OpenOrCreate);
		FileStream file = File.Create (Application.persistentDataPath + "/manager_" + managerData.getName() + ".dat");

		bf.Serialize (file, managerData);

		file.Close ();
	}
		

}
