using UnityEngine;
using System.Collections;
namespace message{
	public enum MessageType{
		Msg_ImHome,
		Msg_StewReady,
		Msg_Shake
	};
	public class Telegram : MonoBehaviour
	{
		
		public int senderID;
		public int receiverID;
		public MessageType message;
		public float delay;
		public Object extra;

		public Telegram (int senderId, int receiverId, MessageType messageType, float delayTime, Object extraInfo = null){
			senderID = senderId;
			receiverID = receiverId;
			message = messageType;
			delay = delayTime;
			extra = extraInfo;
		}
	}

}