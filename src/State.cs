using NiceFSM.Messaging;

namespace NiceFSM 
{
	public abstract class State<T> where T : class {
		public abstract void Enter(T owner);
		public abstract void Execute(T owner);
		public abstract void Exit(T owner);
		public abstract bool OnMessage(T sender, Telegram message);
	}
}
