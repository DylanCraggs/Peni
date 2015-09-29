using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Diagnostics;
using Peni.Data.ViewModel;
using System.Collections.Generic;

namespace Peni.Data
{
	public class ForumPageViewModel : ViewModelBase
	{
		/// <summary>
		/// Variable holding the thread that a user has requested
		/// </summary>
		private Thread RequestedThread;

		/// <summary>
		/// ICommand which navigates user to the thread creation
		/// </summary>
		public static ICommand NewThreadCommand { get; private set; }

		/// <summary>
		/// ICommand which navigates the user to requested thread
		/// </summary>
		public static ICommand GoToThreadCommand { get; private set; }

		/// <summary>
		/// ICommand to leave a comment on the current thread
		/// </summary>
		public static ICommand LeaveCommentCommand { get; private set; }

		/// <summary>
		/// The navigation service.
		/// </summary>
		private IMyNavigationService navigationService;

		/// <summary>
		/// Stores a list of Threads to bind to a list from our view
		/// </summary>
		public ObservableCollection<Thread> ForumList {
			get { 
				var database = new ForumsDatabase(); 
				return new ObservableCollection<Thread>(database.GetAll());
			}
		}

		/// <summary>
		/// Stores a list of user comments to display in a binding list from our view
		/// </summary>
		/// <value>The user comments.</value>
		public ObservableCollection<UserComment> UserComments {
			get {
				var database = new ForumsDatabase ();
				return new ObservableCollection<UserComment>(database.GetThreadComments(this.RequestedThread.id));
			}
		}

		/// <summary>
		/// Stores the thread that we are viewing.
		/// </summary>
		private ObservableCollection<Thread> currentViewingThread = new ObservableCollection<Thread>();
		public ObservableCollection<Thread> CurrentViewingThread {
			get { return currentViewingThread; }
			set {
				currentViewingThread = value;
				RaisePropertyChanged (() => CurrentViewingThread);
			}
		}

		/// <summary>
		/// Data binding for the thread/topic name
		/// </summary>
		private string topicName;
		public string TopicName
		{
			get { return topicName; }
			set { 
				topicName = value;
				RaisePropertyChanged(() => TopicName); 
			}
		}

		/// <summary>
		/// Data binding for the number of comments the thread contains
		/// </summary>
		private string topicComments;
		public string TopicComments {
			get { return topicComments; }
			set {
				topicComments = value;
				RaisePropertyChanged (() => TopicComments);
			}
		}

		/// <summary>
		/// Data binding for the author of the thread
		/// </summary>
		private string topicAuthor;
		public string TopicAuthor {
			get { return topicAuthor; }
			set {
				topicAuthor = value;
				RaisePropertyChanged (() => TopicAuthor);
			}
		}

		/// <summary>
		/// Data binding for the date the thread was created
		/// </summary>
		private string topicCreationDate;
		public string TopicCreationDate {
			get { return topicCreationDate; }
			set {
				topicCreationDate = value;
				RaisePropertyChanged (() => TopicCreationDate);
			}
		}

		/// <summary>
		/// Data binding for the main details about the thread / threa content / what the user wants to say
		/// </summary>
		private string topicContent;
		public string TopicPostContent {
			get { return topicContent; }
			set {
				topicContent = value;
				RaisePropertyChanged (() => TopicPostContent);
			}
		}

		/// <summary>
		/// Data binding for user comment input
		/// </summary>
		private string userCommentInput;
		public string UserCommentInput {
			get { return userCommentInput; }
			set {
				userCommentInput = value;
				RaisePropertyChanged (() => UserCommentInput);
			}
		}

		/// <summary>
		/// Contains a list of user comments related to a thread
		/// </summary>
		private List<UserComment> threadComments;
		public List<UserComment> ThreadComments {
			get { return threadComments; }
			set {
				threadComments = value;
				RaisePropertyChanged (() => ThreadComments);
			}
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumPageViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public ForumPageViewModel(IMyNavigationService navigationService) {
			this.navigationService = navigationService;

			// Add commands to our ICommands defined above so they actually do something
			NewThreadCommand = new Command (() => {
				this.navigationService.NavigateTo(ViewModelLocator.ForumsNewThreadPageKey);
			});

			GoToThreadCommand = new Command (() => {
				this.navigationService.NavigateTo(ViewModelLocator.ForumsViewThreadPageKey);
			});

			LeaveCommentCommand = new Command (() => {
				if(RequestedThread == null)
					return;
				var database = new ForumsDatabase();
				UserComment comment = new UserComment(RequestedThread.id, "Anonymous", userCommentInput, DateTime.Now.ToString());
				database.InsertComment(comment);
				UpdateThreadComments(this.RequestedThread.id);
			});
		}

		/// <summary>
		/// Gets the new thread ICommand.
		/// </summary>
		/// <returns>The NewThreadCommand ICommand.</returns>
		public ICommand GetNewThreadCommand() {
			return NewThreadCommand;
		}

		/// <summary>
		/// Returns the command that loads the thread and corresponding data
		/// </summary>
		/// <returns>The GetGoToThreadCommand ICommand.</returns>
		/// <param name="RequestedThread">The thread object of the thread a user has requested.</param>
		public ICommand GetGoToThreadCommand(Thread RequestedThread) {
			this.RequestedThread = RequestedThread;

			this.currentViewingThread.Clear ();
			this.currentViewingThread.Add(RequestedThread);

			// Thread Data Stuff
			this.topicName = this.RequestedThread.TopicName;
			this.topicAuthor = this.RequestedThread.TopicAuthor;
			this.topicComments = this.RequestedThread.TopicComments;
			this.topicCreationDate = this.RequestedThread.TopicCreationDate;
			this.TopicPostContent = this.RequestedThread.TopicPostContent;

			// Thread Comment Stuff
			UpdateThreadComments(this.RequestedThread.id);
			
			return GoToThreadCommand;
		}

		/// <summary>
		/// Updates the thread comments given the thread id.
		/// </summary>
		/// <param name="threadid">ThreadID for comments to update on.</param>
		private void UpdateThreadComments(int threadid) {
			ForumsDatabase database = new ForumsDatabase ();
			this.threadComments = database.GetThreadComments (threadid);
			this.userCommentInput = null;
			RaisePropertyChanged (() => ThreadComments);
		}

		/// <summary>
		/// Gets the requested thread.
		/// </summary>
		/// <returns>Thread object of the current RequestedThread variable.</returns>
		public Thread GetRequestedThread() {
			return RequestedThread;
		}

		/// <summary>
		/// Gets the ICommand for our LeaveCommentCommand
		/// </summary>
		/// <returns>LeaveCommentCommand ICommand.</returns>
		public ICommand GetLeaveCommentCommand() {
			return LeaveCommentCommand;
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		public void OnAppearing(){
			RaisePropertyChanged (() => ForumList);
			RaisePropertyChanged (() => UserComments);
		}
	}
}

