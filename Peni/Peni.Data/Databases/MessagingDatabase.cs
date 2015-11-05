using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Peni.Data
{
	public class MessagingDatabase : CloudDatabase
	{
		public MessagingDatabase ()
		{
			base.Init ();
		}

		/// <summary>
		/// Gets all messages between two users
		/// </summary>
		/// <returns>The all.</returns>
		public async Task<List<Message>> GetConversation(Guid receivingID) {
			return await base.messagesTable.Where (x => x.ReceivingUserID == receivingID && x.SendingUserID == Guid.Parse(Globals.UserSession.id) ||
				x.SendingUserID == receivingID && x.ReceivingUserID == Guid.Parse(Globals.UserSession.id)).ToListAsync();
		}

		/// <summary>
		/// Inserts a message.
		/// </summary>
		/// <param name="sendingID">Sending Id.</param>
		/// <param name="sendingUser">Sending username.</param>
		/// <param name="receivingID">Receiving Id.</param>
		/// <param name="receivinguser">Receiving username.</param>
		/// <param name="message">Message.</param>
		public async Task InsertMessage(Guid sendingID, string sendingUser, Guid receivingID, string receivinguser, string message) {
			await base.messagesTable.InsertAsync(new Message(sendingID, sendingUser, receivingID, receivinguser, message));
		}

		/// <summary>
		/// Gets all conversations active
		/// </summary>
		/// <returns>All conversations</returns>
		public async Task<List<Message>> GetAllConversations() {
			var all = await base.messagesTable.Where (x => x.SendingUserID == Guid.Parse(Globals.UserSession.id)
				|| x.ReceivingUserID == Guid.Parse(Globals.UserSession.id)).ToListAsync ();
			List<Message> msg = new List<Message> ();

			// make sure we dont add duplicates of same conversation
			foreach (Message item in all) {
				bool addme = true;
				foreach (Message uniqueItem in msg) {
					if (item.SendingUserID == uniqueItem.SendingUserID && item.ReceivingUserID == uniqueItem.ReceivingUserID)
						addme = false;
				}
				if (addme) {
					msg.Add (item);
				}
			}

			return msg;

		}
	}
}

