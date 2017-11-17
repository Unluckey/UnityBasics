using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public static string targetSceneName;


	AsyncOperation asyncO;
	public Texture2D[] animations;
	private int nowFram;

	float progress = 0;

	void Awake(){
		StartCoroutine (LoadScene());
	}
	IEnumerator LoadScene(){
		asyncO = SceneManager.LoadSceneAsync (targetSceneName);
		yield return asyncO;
	}

	void OnGUI(){
	}
	void Update(){
		
		progress = asyncO.progress * 100;
		Debug.Log("Loading:"+((int)progress).ToString()+"%");
	}
}