using UnityEngine;
using System;

class Idle:State<Player>{
  override public virtual void Enter(Player owner){
    
  }
  override public virtual void Execute(Player owner){
    Keycheck();
  }
  override public virtual void Exit(Player owner){

  }
}
