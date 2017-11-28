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

	public void GiveFragile(Creature target){
		Dictionary<string,System.Object> param = new Dictionary<string, object> ();
		param.Add ("target", target);
		param.Add("buff",new Buff_Fragile(2.0f));
		NotifySystem.NotificationCenter.getInstance ().postNotification (
			new NotifySystem.NotifyEvent (NotifySystem.NotifyType.BUFF_ADD,param)
		);
	}
}

