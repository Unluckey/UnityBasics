using UnityEngine;
using System;

class BuffBar<T>{
  T owner;
  List<Buff<T>> buffList;
  public BuffBar(T owner){
    this.owner = owner;
    buffList = new List<Buff<T>>();
  }

  public void AttachBuff(Buff<T> buff){
    Buff<T> temp = TryGetBuff(buff);
    if(temp!=null){
      temp.OnCover(owner);
    }else{
      buffList.Append(buff);
      buff.OnAttach(owner);
    }
  }
  public void RemoveBuff(Buff<T> buff){
    Buff<T> temp = TryGetBuff(buff.GetID);
    if(temp != null){
      buff.OnRemove(ower);
    }
    //buffList.pop();
  }
  public void RemoveAllBuff(){
    foreach(Buff<T> o in buffList){
      o.OnRemove(owner);
    }
    buffList = new List<Buff<T>>();
  }

  public void Update(){
    foreach(Buff<T> o in buffList){
      o.Run(owner);
    }
  }
  void Buff<T> TryGetBuff(Buff<T> buff){
      foreach(Buff<T> o in buffList){
        if(o.GetID() == buff.GetID){
          return o;
        }
      }
      return null;
    }
    void Buff<T> TryGetBuff(int buffID){
        foreach(Buff<T> o in buffList){
          if(o.GetID() == buffID){
            return o;
          }
        }
        return null;
      }

}
