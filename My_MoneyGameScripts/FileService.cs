using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileService {

	public Business loadBusinessById(string businessId) {
		Debug.Log (">> FileService is loading Business: " + businessId + ", please wait...");
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
//		FileStream file = File.Open (Application.persistentDataPath + "/biz_" +  + ".dat", FileMode.OpenOrCreate);

		bf.Serialize (file, business);
		file.Close ();

		Debug.Log (">> FileService save: " + business.getId() );
		Debug.Log ("<< qtyOwned: " + business.getQuantityOwned());
//		Debug.Log ("FileService - SAVE - Data .." + Application.persistentDataPath);


	}
		
	public void deleteBusinessById(string businessId) {
		if (File.Exists (Application.persistentDataPath + "/biz_" + businessId + ".dat") ) {
			Debug.Log ("Business : " + businessId + " has just been deleted.");
			File.Delete(Application.persistentDataPath + "/biz_" + businessId + ".dat");
		}
			
	}



		

}
