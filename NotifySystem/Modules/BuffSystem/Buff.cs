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
}
