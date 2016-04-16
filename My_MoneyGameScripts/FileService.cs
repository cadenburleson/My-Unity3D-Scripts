﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileService {

	public FileService() {
	
	}

	public Business load(string businessId) {

		Debug.Log (">> FileService load: " + businessId);

		Business business = null;

		if (File.Exists (Application.persistentDataPath + "/biz_" + businessId + ".dat") ) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/biz_" + businessId + ".dat", FileMode.Open);

			business = (Business)bf.Deserialize (file);
			file.Close ();

			Debug.Log ("<< FileService returning business: " + business.getId());
			Debug.Log ("<< qtyOwned: " + business.getQuantityOwned());
			Debug.Log ("FileService - LOAD - DATATATATATAT ~~" + Application.persistentDataPath);
		}
		return business;
	}

	public void save(Business business) {

		Debug.Log (">> FileService save: " + business.getId() );

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/biz_" + business.getId() + ".dat", FileMode.OpenOrCreate);

		bf.Serialize (file, business);
		file.Close ();

		Debug.Log (">> FileService save: " + business.getId() );
		Debug.Log ("<< qtyOwned: " + business.getQuantityOwned());
		Debug.Log ("FileService - SAVE - DATATATATATAT .." + Application.persistentDataPath);
	}

	public void delete(string businessId) {

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
