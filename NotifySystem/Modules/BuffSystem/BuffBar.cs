using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public delegate float BuffDelegator(System.Object owner,float value = 0);

public enum BuffCallback{
	VALUE_BEFORE_DAMAGE,
	VALUE_APPLY_DAMAGE,
	VALUE_BEFORE_HEAL,
	VALUE_APPLY_HEAL,
	TRIGGER_HIT,
	TRIGGER_JUMP,
	TRIGGER_GET_HIT
}

public class BuffBar<T>{
	Dictionary<BuffCallback,BuffDelegator> CallbackDic;
	Dictionary<string,object> uiUpdateParam;
	NotifySystem.NotifyEvent uiUpdateEvent;

	T owner;
	public List<Buff<T>> buffList;
	public List<Buff<T>> toBeRemove;
	public BuffBar(T owner){
		this.owner = owner;
		uiUpdateParam = new Dictionary<string, object>();
		uiUpdateParam.Add ("owner", owner);
		uiUpdateEvent = new NotifySystem.NotifyEvent (
			NotifySystem.NotifyType.UI_BUFF_UPDATE,
			uiUpdateParam);
		
		buffList = new List<Buff<T>> ();
		toBeRemove = new List<Buff<T>> ();
		CallbackDic = new Dictionary<BuffCallback, BuffDelegator> ();
	}

	public float OnBuffCallback(BuffCallback callbackType,float value = 0){
		float changeValue = 0;
		BuffDelegator tryDelegator = null;
		if (CallbackDic.TryGetValue (callbackType, out tryDelegator)) {
			if (tryDelegator != null && tryDelegator.GetInvocationList().Length != 0) {
				foreach (BuffDelegator processor in tryDelegator.GetInvocationList()) {
					changeValue += processor.Invoke ((System.Object)owner, value);
				}
			}
		}
		return (value + changeValue);
	}
	public void AttachBuff(Buff<T> buff){
		Buff<T> temp = TryGetBuff (buff);
		if (temp != null) {
			temp.OnCover (owner,buff);
		} else {
			buffList.Add (buff);
			buff.OnAttach (owner,this);
			RegisterBuff (buff);
		}
	}
	void RegisterBuff(Buff<T> buff){
		if (buff.recieverDic != null) {
			foreach (var Key in buff.recieverDic.Keys) {
				RegisterCallback (Key, buff.recieverDic [Key]);
			}
		}
	}
	void RegisterCallback(BuffCallback callBack,BuffDelegator delegator){
		if (delegator == null){
			Debug.LogError("registerObserver: listener不能为空");
			return;
		}
		Debug.Log("NotifacitionCenter: 添加监视" + callBack);

		BuffDelegator tryDelegator = null;
		if (CallbackDic.TryGetValue (callBack, out tryDelegator)) {
			if (tryDelegator != null && tryDelegator.GetInvocationList ().Length != 0) {
				foreach (BuffDelegator dlg in tryDelegator.GetInvocationList ()) {
					if (dlg.Method.Name.Equals (delegator.Method.Name)) {
						return;
					}
				}
			}
		}
		tryDelegator += delegator;
		CallbackDic[callBack] = tryDelegator;
	}

	public void Remove (Buff<T> buff){
		toBeRemove.Add (buff);
	}
	public void RemoveAll(){
		foreach (Buff<T> o in buffList) {
			Remove (o);
		}
		buffList = new List<Buff<T>> ();
	}

	void ApplyRemove (){
		foreach (Buff<T> o in toBeRemove) {
			RemoveBuff (o);
		}
		toBeRemove.Clear ();
	}
	void RemoveBuff(Buff<T> buff){
		Buff<T> temp = TryGetBuff (buff.GetID ());
		if (temp != null) {
			removeCallback (temp);
			buff.OnRemove (owner);
			buffList.Remove (temp);
		}
		Debug.Log ("remove!");
	}

	void removeCallback(Buff<T> buff){
		if (buff.recieverDic != null) {
			foreach (BuffCallback callback in buff.recieverDic.Keys) {
				Debug.Log ("BuffBar: 移除Buff" + callback);
				CallbackDic [callback] -= buff.recieverDic[callback];
			}
		}
	}

	Buff<T> TryGetBuff(Buff<T> buff){
		foreach (Buff<T> o in buffList) {
			if (o.GetID () == buff.GetID ()) {
				return o;
			}
		}
		return null;
	}
	Buff<T> TryGetBuff(int buffID){
		foreach (Buff<T> o in buffList) {
			if (o.GetID () == buffID) {
				return o;
			}
		}
		return null;
	}

	public void Update(){
		foreach (Buff<T> o in buffList) {
			o.Run (owner);
		}
		ApplyRemove ();
		UpdateUI();
	}
	void UpdateUI(){
		NotifySystem.NotificationCenter.getInstance().postNotification(uiUpdateEvent);
	}



}
