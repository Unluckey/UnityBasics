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



	protected void Awake(){
		SetID ();
		GameEntityManager.getInstance().Register (this);
	}
	protected void Start(){

	}

	protected void Update(){
	}
	public BaseEntity(string name){
		SetName (name);

	}
	public BaseEntity(){
	}
		
	protected void SetID(){
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
}

