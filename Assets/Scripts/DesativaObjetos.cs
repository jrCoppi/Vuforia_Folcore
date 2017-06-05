using UnityEngine;
using UnityEngine.UI;



    // Update is called once per frame
    public class DesativaObjetos : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>();
            foreach (GameObject a in allObjects)
            {
                if (a.name == "Vitoria_Regia")
                {
                    a.SetActive(false);
                }
                if (a.name == "Negrinho_Pastoreiro")
                {
                    a.SetActive(false);
                }
                if (a.name == "Boto")
                {
                    a.SetActive(false);
                }
                if (a.name == "Mula_Sem_Cabeca")
                {
                    a.SetActive(false);
                }
                if (a.name == "Curupira") {
                    a.SetActive(false);
                }
				if (a.name == "Saci")
				{
					a.SetActive(false);
				}
				/*if (a.name == "Boitata")
				{
					a.SetActive(false);
				}*/

		}
        }

    void Update() { }

    }








