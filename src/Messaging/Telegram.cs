using System;

namespace NiceFSM.Messaging 
{
	public struct Telegram {
		public int sender; // sender id
		public int receiver; // receiver id
		public int message; // message id
		
		public DateTime dispatchTime; // delay before send
		public Object addInfo; // addtional parameter
	
		public Telegram(int sender, int receiver, int message, DateTime dispatchTime, Object addInfo) {
		    this.sender = sender;
		    this.receiver = receiver;
		    this.message = message;
		    this.dispatchTime = dispatchTime;
		    this.addInfo = addInfo;
		}
	}
}
