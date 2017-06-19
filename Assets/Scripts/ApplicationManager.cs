using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

	public void NextLevelButton(string levelName)
	{
		Application.LoadLevel(levelName);
	}
	

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
