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
		/// The requested thread.
		/// </summary>
		private Thread RequestedThread;

		/// <summary>
		/// Gets/sets the new thread command.
		/// </summary>
		/// <value>The new thread command.</value>
		public static ICommand NewThreadCommand { get; private set; }

		/// <summary>
		/// Navigates the user to requested thread
		/// </summary>
		/// <value>The goto thread command.</value>
		public static ICommand GoToThreadCommand { get; private set; }

		/// <summary>
		/// Command to leave a comment on the current thread
		/// </summary>
		/// <value>The leave comment command.</value>
		public static ICommand LeaveCommentCommand { get; private set; }

		/// <summary>
		/// The navigation service.
		/// </summary>
		private IMyNavigationService navigationService;

		/// <summary>
		/// Gets/sets the forum list.
		/// </summary>
		/// <value>The forum list.</value>
		public ObservableCollection<Thread> ForumList {
			get { 
				var database = new ForumsDatabase(); 
				return new ObservableCollection<Thread>(database.GetAll());
			}
		}

		/// <summary>
		/// Gets the user comments.
		/// </summary>
		/// <value>The user comments.</value>
		public ObservableCollection<UserComment> UserComments {
			get {
				var database = new ForumsDatabase ();
				return new ObservableCollection<UserComment>(database.GetThreadComments(this.RequestedThread.id));
			}
		}

		/// <summary>
		/// The current thread being viewed.
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
		/// The name of the topic.
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
		/// The topic comments.
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
		/// The topic author.
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
		/// The topic creation date.
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
		/// The content of the topic.
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
		/// The user comment input.
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
		/// The thread comments.
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
		/// Gets the new thread command.
		/// </summary>
		/// <returns>The new thread command.</returns>
		public ICommand GetNewThreadCommand() {
			return NewThreadCommand;
		}

		/// <summary>
		/// Returns the command that loads the thread and corresponding data
		/// </summary>
		/// <returns>The go to thread command.</returns>
		/// <param name="RequestedThread">Requested thread.</param>
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
		/// Updates the thread comments list given the thread id.
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
		/// <returns>The requested thread.</returns>
		public Thread GetRequestedThread() {
			return RequestedThread;
		}

		/// <summary>
		/// Gets the leave comment command.
		/// </summary>
		/// <returns>The leave comment command.</returns>
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

