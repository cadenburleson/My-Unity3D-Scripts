using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileService {

//	public FileService() {
//	
//	}

	public Business loadBusinessById(string businessId) {
		Debug.Log (">> FileService is loading Business: " + businessId + ", please wait...");
		Business business = null;
		if (File.Exists (Application.persistentDataPath + "/biz_" + businessId + ".dat") ) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/biz_" + businessId + ".dat", FileMode.Open);

			business = (Business)bf.Deserialize (file);
			file.Close ();

			Debug.Log ("<< FileService returning business: " + business.getId());
			Debug.Log ("<< FileService qtyOwned: " + business.getQuantityOwned());
			Debug.Log ("FileService You have " + business.getQuantityOwned() +" "+ business.getName() + " Businesses.");
			Debug.Log ("FileService - LOAD - Data ~~" + Application.persistentDataPath);
		}
		return business;
	}

	public void saveBusiness(Business business) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/biz_" + business.getId() + ".dat", FileMode.OpenOrCreate);

		bf.Serialize (file, business);
		file.Close ();

		Debug.Log (">> FileService save: " + business.getId() );
		Debug.Log ("<< qtyOwned: " + business.getQuantityOwned());
		Debug.Log ("FileService - SAVE - Data .." + Application.persistentDataPath);

	}

	public void saveMoney(float money){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/money_" + money + ".dat", FileMode.OpenOrCreate);

		bf.Serialize (file, money);
		file.Close ();

	}

	public float loadMoney(float money) {
		if (File.Exists (Application.persistentDataPath + "/money_" + money + ".dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/money_" + money + ".dat", FileMode.OpenOrCreate);

			money = (float)bf.Serialize(file, money);
			file.Close();

		}
		return money;
	}
		

	public void deleteBusinessById(string businessId) {

//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File

		if (File.Exists (Application.persistentDataPath + "/biz_" + businessId + ".dat") ) {
			File.Delete(Application.persistentDataPath + "/biz_" + businessId + ".dat");
		}
			
	}

//
//
//	if (File.Exists (Application.persistentDataPath + "/biz_" + businessId + ".dat") ) {
//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File.Open (Application.persistentDataPath + "/biz_" + businessId + ".dat", FileMode.Open);
//
//		business = (Business)bf.Deserialize (file);
//		file.Close ();
//
//		Debug.Log ("<< FileService returning business: " + business.getId());
//		Debug.Log ("<< qtyOwned: " + business.getQuantityOwned());
//		Debug.Log ("DATATATATATAT ~~" + Application.persistentDataPath);
//	}
//




}
