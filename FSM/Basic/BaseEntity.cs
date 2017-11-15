using UnityEngine;
using System.Collections;

public abstract class BaseEntity:MonoBehaviour{
	int ID;
	public int id{
		get{
			return ID;
		}
	}


	string entityName = "UnNamedEntity";

	static int NextValidID = 0;



	public void Awake(){
		SetID ();
		GameEntityManager.getInstance().Register (this);
	}
	public void Start(){

	}

	void Update(){
	}
	public BaseEntity(string name){
		SetName (name);

	}
	public BaseEntity(){
	}
		
	private void SetID(){
		ID = NextValidID;
		NextValidID++;
	}

	//public int GetID() { return ID; }
	public int GetID() { 
		return ID; 
	}

	public void SetName(string name){
		entityName = name;
	}

	public string GetName(){
		return entityName;
	}



	public virtual void ReleaseThis() { 
		GameEntityManager.getInstance().Remove (ID);
	}

	public virtual bool HandleMessage (message.Telegram telegram){
		return false;
	}
}

