using UnityEngine;
using System;

class Buff<T>{
	Time startTime;
	float duration;
	int ID;
	string buffName;
	public int GetID(){
		return ID;
	}
	public Buff(){
	}

	public virtual void OnAttach(T owner){

	}
	public virtual void Run(T owner){

	}
	public virtual void OnRemove(T owner){

	}
	public virtual void OnCover(T owner){

	}

	//
	public virtual float OnHurt(float damage){
		return 0;
	}
	public virtual float OnHeal(float healValue){
		return 0;
	}
	public virtual void OnJump(){

	}
}
