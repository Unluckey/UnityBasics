using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class World:MonoBehaviour
{
	static World instance = null;
	public static World Instance{
		get{
			if(instance == null)
				instance = new World();
			return instance;
		}
		set{ }
	}

	public void ChangeScene(string targetSceneName){
		
		SceneLoader.targetSceneName = targetSceneName;
		SceneManager.LoadScene ("LoadingScene");
	}
}

