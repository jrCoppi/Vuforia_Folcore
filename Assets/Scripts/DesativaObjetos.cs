using UnityEngine;

public class DesativaObjetos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] allObjects = FindObjectsOfType<GameObject>();
		foreach (GameObject a in allObjects) {
			if (a.name == "Vitoria_Regia") {
				a.SetActive (false);
			}
			if (a.name == "Negrinho_Pastoreiro") {
				a.SetActive (false);
			}
			if (a.name == "Boto") {
				a.SetActive (false);
			}
			if (a.name == "Mula_Sem_Cabeca") {
				a.SetActive (false);
			}
			/*if (a.name == "Curupira") {
				a.SetActive(false);
			}*/




		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
