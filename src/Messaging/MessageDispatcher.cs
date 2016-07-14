using System;
using System.Collections.Generic;

namespace NiceFSM.Messaging 
{
	public class MessageDispatcher {
		List<Telegram> delayedTelegrams = new List<Telegram>();
	
		public static MessageDispatcher Instance {
			get { 
				if (instance == null)
					instance = new MessageDispatcher();
				return instance;
			}
		}
		static MessageDispatcher instance;
		
		MessageDispatcher() {}
	
		public void DispatchMessage(int senderId, int receiverId, int msg, int delay = 0, object additionalInfo = null) {
			Telegram t = new Telegram() {
				sender = senderId,
				receiver = receiverId,
				message = msg,
				addInfo = additionalInfo
			};
	
			if (delay > 0) {
				t.dispatchTime = (DateTime.Now + TimeSpan.FromSeconds(delay));
				delayedTelegrams.Add(t);
			} else {
				Dispatch(t);
			}
		}
		
		public void HandleDelayedMessages() {
			foreach (var t in delayedTelegrams.ToArray()) {
				if (DateTime.Now > t.dispatchTime) {
					Dispatch(t);
					delayedTelegrams.Remove(t);
				}
			}
		}
		
		public void ClearMessages() {
			delayedTelegrams.Clear();
		}
	
		void Dispatch(Telegram t) {
			var receiver = Entities.FSMEntityManager.Instance.GetEntityById(t.receiver);
			receiver.HandleMessage(t);
		}
	}
}
