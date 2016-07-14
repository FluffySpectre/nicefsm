using NiceFSM.Messaging;

namespace NiceFSM.Entities
{
	public interface IFSMEntity {
		int Id { get; set; }
		void EntityUpdate();
		bool HandleMessage(Telegram message);
	}
}
