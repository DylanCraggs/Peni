using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Peni.Data.ViewModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peni.Data
{
	public class MessageMainViewModel : ViewModelBase
	{
		/// <summary>
		/// The conversation list.
		/// </summary>
		private ObservableCollection<Message> conversationList;
		public ObservableCollection<Message> ConversationList {
			get { return conversationList; }
			set {
				conversationList = value;
				RaisePropertyChanged (() => ConversationList);
			}
		}

		/// <summary>
		/// The ID of the user the message is being sent to
		/// </summary>
		private Guid receivingID;
		public Guid ReceivingID {
			get { return receivingID; }
			set {
				receivingID = value;
				RaisePropertyChanged (() => ReceivingID);
			}
		}

		/// <summary>
		/// The receivers username.
		/// </summary>
		private string receivingUsername;
		public string ReceivingUsername {
			get { return receivingUsername; }
			set {
				receivingUsername = value;
				RaisePropertyChanged (() => ReceivingUsername);
			}
		}

		/// <summary>
		/// The list containing previous messages sent / recieved
		/// </summary>
		private List<Message> messageList;
		public List<Message> MessageList {
			get { return messageList; }
			set {
				messageList = value;
				RaisePropertyChanged (() => MessageList);
			}
		}

		/// <summary>
		/// The message to be sent
		/// </summary>
		private string message;
		public string Message {
			get { return message; }
			set { 
				message = value;
				RaisePropertyChanged (() => Message);
			}
		}
			
		/// <summary>
		/// The navigation service.
		/// </summary>
		private IMyNavigationService navigationService;

		/// <summary>
		/// Gets the view conversation command.
		/// </summary>
		public ICommand ViewConversationCommand { get; private set; }

		/// <summary>
		/// Gets the send message command.
		/// </summary>
		/// <value>The send message command.</value>
		public ICommand SendMessageCommand { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.MessageMainViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public MessageMainViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

			ViewConversationCommand = new Command(() => { 
				this.navigationService.NavigateToModal(ViewModelLocator.MessagingPageKey);
			});

			SendMessageCommand = new Command(x => {
				MessagingDatabase database = new MessagingDatabase();
				database.InsertMessage(Guid.Parse(Globals.UserSession.id), Globals.UserSession.Username, ReceivingID, ReceivingUsername, Message);
				UpdateMessages();
			});
		}

		/// <summary>
		/// Updates the messages.
		/// </summary>
		private async void UpdateMessages() {
			MessagingDatabase database = new MessagingDatabase ();
			MessageList = await database.GetConversation(ReceivingID);
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		public async void OnAppearing() {
			MessagingDatabase database = new MessagingDatabase ();
			ConversationList = new ObservableCollection<Message> (await database.GetAllConversations ());
		}

		/// <summary>
		/// Navigates to conversation with another user
		/// </summary>
		/// <param name="receivingUserID">The GUID of the other user in the conversation.</param>
		public async Task<ICommand> GetNavigateToConversation(Guid receivingUserID, string receivingUsername) {
			MessagingDatabase database = new MessagingDatabase ();
			MessageList = await database.GetConversation(receivingUserID);
			ReceivingID = receivingUserID;
			ReceivingUsername = receivingUsername;
			return ViewConversationCommand;
		}
	}
}

