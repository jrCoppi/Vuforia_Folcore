using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativaObjetos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] allObjects = FindObjectsOfType<GameObject>();
		foreach (GameObject a in allObjects) {
			/*if (a.name == "vitoriaRegia") {
				a.SetActive (false);
			}*/
			if (a.name == "pastoreiro") {
				a.SetActive (false);
			}
			if (a.name == "boto") {
				a.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
