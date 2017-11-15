using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameEntityManager
{
	private static GameEntityManager instance = null;
	private GameEntityManager() { }
	public static GameEntityManager getInstance()
	{
		if (instance == null)
		{
			instance = new GameEntityManager();
		}
		return instance;
	}

	Dictionary<int,BaseEntity> entityIDDic = new Dictionary<int,BaseEntity>();


	public void Register(BaseEntity entity){
		if (!entityIDDic.ContainsKey (entity.GetID())) {
			entityIDDic.Add (entity.GetID(), entity);
		}
	}
	public void Remove(int ID){
		if (entityIDDic.ContainsKey (ID)) {
			entityIDDic.Remove (ID);
		}
	}
	public void Clear(){
		entityIDDic.Clear ();
	}
	public BaseEntity GetEntity(int ID){
		if(entityIDDic.ContainsKey(ID)){
			return entityIDDic [ID];
		}else{
			return null;
		}
	}
	public BaseEntity GetEntity(string targetEntityName){
		foreach (BaseEntity entity in entityIDDic.Values) {
			if (entity.GetName().Equals(targetEntityName)) {
				return entity;
			}
		}
		return null;
	}
	public T GetEntityByType<T>(int ID) where T:BaseEntity{
		if ( ContainsEntity(ID)) {
			return (T)entityIDDic [ID];
		}
		return null;
	}
	public T GetEntityByType<T>(string targetEntityName)where T:BaseEntity{
		foreach (BaseEntity entity in entityIDDic.Values) {
			if (entity.name.Equals (targetEntityName)) {
				return (T)entity;
			}
		}
		return null;
	}
	public List<T> getEntitiesByTag<T>(string tag)where T:BaseEntity{
		List<T> returnList = new List<T> ();
		foreach (BaseEntity entity in entityIDDic.Values) {
			if(entity.tag.Equals(tag)){
				returnList.Add((T)entity);
			}
		}
		return returnList;
	}


	public bool ContainsEntity(int ID){
		return entityIDDic.ContainsKey (ID);
	}
	public bool ContainsEntity(string name){
		foreach (BaseEntity entity in entityIDDic.Values) {
			if (entity.name.Equals(name)) {
				return true;
			}
		}
		return false;
	}

}