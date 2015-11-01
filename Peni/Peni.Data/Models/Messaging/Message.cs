using System;
using SQLite.Net.Attributes;

namespace Peni.Data
{
	public class Message
	{
		[PrimaryKey, AutoIncrement]
		public Guid id { get; set; }

		public Guid SendingUserID { get; set; }
		public string SendingUserUsername { get; set; }

		public Guid ReceivingUserID { get; set; }
		public string ReceivingUserUsername { get; set; }

		public string MessageContent { get; set; }

		public Message() { }

		public Message (Guid SendingUserID, string sender, Guid ReceivingUserID, string receiver, string MessageContent) {
			this.SendingUserID = SendingUserID;
			this.SendingUserUsername = sender;
			this.ReceivingUserID = ReceivingUserID;
			this.ReceivingUserUsername = receiver;
			this.MessageContent = MessageContent;
		}
	}
}

