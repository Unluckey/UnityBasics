using UnityEngine;
using System;

namespace NotifySystem{
  class BuffDealer:Listener{
    GameEntityManager entityManager = GameEntityManager.getInstance();
    public BuffDealer(){
          recieverDic.Add(NotifyType.BUFF_ON_ADD,new EventListenerDelegate(AttachBuff));
          recieverDic.Add(NotifyType.BUFF_ON_REMOVE,new EventListenerDelegate(RemoveBuff));
          register();
    }

    void AttachBuff(NotifyEvent notifyEvent){

    }
    void RemoveBuff(NotifyEvent notifyEvent){

    }

  }


}
