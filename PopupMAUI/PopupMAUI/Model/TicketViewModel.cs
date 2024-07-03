using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.ListView;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PopupMAUI
{
	/// <summary>
	/// A ViewModel for TicketBooking sample.
	/// </summary>
	public class TicketBookingViewModel : INotifyPropertyChanged
	{
		#region Fields

		/// <summary>
		/// backing field for TimingCommand.
		/// </summary>
		private Command<Syncfusion.Maui.Popup.SfPopup> timingCommand;

		/// <summary>
		/// backing field for BookingCommand.
		/// </summary>
		private Command<SfListView> bookingCommand;

		/// <summary>
		/// backing field for ProceedCommand.
		/// </summary>
		private Command<Syncfusion.Maui.Popup.SfPopup> proceedCommand;

		/// <summary>
		/// backing field for AcceptCommand.
		/// </summary>
		private Command<Syncfusion.Maui.Popup.SfPopup> acceptCommand;

		/// <summary>
		/// backing field for DeclineCommand.
		/// </summary>
		private Command declineCommand;

		/// <summary>
		/// backing field for DeclineCommand.
		/// </summary>
		private Command<Label> seatSelectionCommand;

		/// <summary>
		/// backing field for OpenInfoCommand.
		/// </summary>
		private Command<InfoPopupParameters> openInfoCommand;

		/// <summary>
		/// Current Terms and Conditions Popup in view.
		/// </summary>
		private Syncfusion.Maui.Popup.SfPopup? currentTermsAndConditionsPopup;

		/// <summary>
		/// Current TicketBooking popup.
		/// </summary>
		public Syncfusion.Maui.Popup.SfPopup? currentTicketBookingPopup { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the TicketBookingViewModel class.
		/// </summary>
		public TicketBookingViewModel()
		{
			var details = new TicketInfoRepository();
			this.TheaterInformation = details.GetDetails();
			this.timingCommand = new Command<Syncfusion.Maui.Popup.SfPopup>(this.OnTimingButtonClicked);
			this.bookingCommand = new Command<SfListView>(this.OnBookingButtonClicked);
			this.proceedCommand = new Command<Syncfusion.Maui.Popup.SfPopup>(this.OnProceedButtonClicked);
			this.acceptCommand = new Command<Syncfusion.Maui.Popup.SfPopup>(this.OnAcceptButtonClicked);
			this.declineCommand = new Command(this.OnDeclineButtonClicked);
			this.seatSelectionCommand = new Command<Label>(this.SelectSeat);
			this.openInfoCommand = new Command<InfoPopupParameters>(this.OpenInfoPopup);
			this.SetBindingImageSource();
		}

		#endregion

		#region Events

		/// <summary>
		/// Event that triggers when the property is changed.
		/// </summary>
		public event PropertyChangedEventHandler? PropertyChanged;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the Command that is called when the timing button is called.
		/// </summary>
		public Command<Syncfusion.Maui.Popup.SfPopup> TimingCommand
		{
			get
			{
				return this.timingCommand;
			}

			set
			{
				this.timingCommand = value;
				this.RaisePropertyChanged("TimingCommand");
			}
		}

		/// <summary>
		/// Gets or sets the Command that will is called when the book button is clicked.
		/// </summary>
		public Command<SfListView> BookingCommand
		{
			get
			{
				return this.bookingCommand;
			}

			set
			{
				this.bookingCommand = value;
				this.RaisePropertyChanged("BookingCommand");
			}
		}

		/// <summary>
		/// Gets or sets the command that is executed when the Proceed button is clicked.
		/// </summary>
		public Command<Syncfusion.Maui.Popup.SfPopup> ProceedCommand
		{
			get
			{
				return this.proceedCommand;
			}

			set
			{
				this.proceedCommand = value;
				this.RaisePropertyChanged("ProceedCommand");
			}
		}

		/// <summary>
		/// Gets or sets the command that is executed when the Accept button is clicked.
		/// </summary>
		public Command<Syncfusion.Maui.Popup.SfPopup> AcceptCommand
		{
			get
			{
				return this.acceptCommand;
			}

			set
			{
				this.acceptCommand = value;
				this.RaisePropertyChanged("AcceptCommand");
			}
		}

		/// <summary>
		/// Gets or sets the command that is executed when the Decline button is clicked.
		/// </summary>
		public Command DeclineCommand
		{
			get
			{
				return this.declineCommand;
			}

			set
			{
				this.declineCommand = value;
				this.RaisePropertyChanged("DeclineCommand");
			}
		}

		/// <summary>
		/// Gets or sets the command that is executed when the seat is selected.
		/// </summary>
		public Command<Label> SeatSelectionCommand
		{
			get
			{
				return this.seatSelectionCommand;
			}

			set
			{
				this.seatSelectionCommand = value;
				this.RaisePropertyChanged("SeatSelectionCommand");
			}
		}

		/// <summary>
		/// Gets or sets the command that is executed when the information image is clicked.
		/// </summary>
		public Command<InfoPopupParameters> OpenInfoCommand
		{
			get
			{
				return this.openInfoCommand;
			}

			set
			{
				this.openInfoCommand = value;
				this.RaisePropertyChanged("OpenInfoCommand");
			}
		}

		#region ItemsSource

		/// <summary>
		/// Gets or sets the TheaterInformation which is ObservableCollection of TicketBookingInfo type.
		/// </summary>
		public ObservableCollection<TicketBookingInfo> TheaterInformation { get; set; }

		#endregion

		#endregion

		#region Private Methods

		/// <summary>
		/// Action to be performed when timing button is clicked.
		/// </summary>
		/// <param name="termsAndConditionsPopup">Popup to be displayed.</param>
		private void OnTimingButtonClicked(Syncfusion.Maui.Popup.SfPopup termsAndConditionsPopup)
		{
			this.currentTermsAndConditionsPopup = termsAndConditionsPopup;
			this.currentTermsAndConditionsPopup.Show();
		}

		/// <summary>
		/// Action to be performed when book button is clicked.
		/// </summary>
		/// <param name="dataGridObject">DataGrid's object in view</param>
		private void OnBookingButtonClicked(SfListView dataGridObject)
		{
			if (dataGridObject != null)
			{
				(dataGridObject.Parent as ContentPage)!.Navigation.PushAsync(new TicketBooking());
			}
		}

		/// <summary>
		/// Action to be performed when proceed button is clicked.
		/// </summary>
		/// <param name="confirmationPopup">Confirmation popup to be displayed.</param>
		private async void OnProceedButtonClicked(Syncfusion.Maui.Popup.SfPopup confirmationPopup)
		{
			if (this.currentTicketBookingPopup != null)
			{
				this.currentTicketBookingPopup.Dismiss();				
            }

			await Task.Delay(200);
			confirmationPopup.Show();
		}

		/// <summary>
		/// Action to be performed when accept button is clicked.
		/// </summary>
		/// <param name="ticketBookingPopup">Popup to be displayed.</param>
		private async void OnAcceptButtonClicked(Syncfusion.Maui.Popup.SfPopup ticketBookingPopup)
		{
			this.CloseCurrentTermsAndConditionsPopup();
			await Task.Delay(200);
			//this.currentTicketBookingPopup = ticketBookingPopup;
			this.currentTicketBookingPopup.Show();
		}

		/// <summary>
		/// Action to be performed when decline button is clicked.
		/// </summary>
		private void OnDeclineButtonClicked()
		{
			this.CloseCurrentTermsAndConditionsPopup();
		}

		/// <summary>
		/// Closes the current TermsAndConditionsPopup.
		/// </summary>
		private void CloseCurrentTermsAndConditionsPopup()
		{
			if (this.currentTermsAndConditionsPopup != null)
			{
				this.currentTermsAndConditionsPopup.IsOpen = false;
			}
		}

		/// <summary>
		/// Action to be performed when seats is selected.
		/// </summary>
		/// <param name="label">The view that is clicked</param>
		private void SelectSeat(Label label)
		{
			foreach (var children in (label.Parent as StackLayout)!.Children)
			{
				//children.Background = Colors.White;
				var seat = children as Label;				
                seat!.TextColor = Colors.Black;
				seat.BackgroundColor = Colors.Transparent;
			}
		// Color.FromHex("#007CEE");
			label.TextColor = Colors.White;
            label.BackgroundColor = Color.FromHex("#6750A4");
        }

		/// <summary>
		/// Action to be performed when Info image is clicked.
		/// </summary>
		/// <param name="infoPopupParameters">InfoPopupParameters needed for displaying InfoPopup</param>
		private void OpenInfoPopup(InfoPopupParameters infoPopupParameters)
		{
			infoPopupParameters.InfoPopup!.HeaderTitle = infoPopupParameters.TheatreLabel!.Text;
			infoPopupParameters.InfoPopup.Show();
		}

		/// <summary>
		/// Sets the ImageSource for the Images.
		/// </summary>
		private void SetBindingImageSource()
		{
		}

		#endregion

		#region INotifyPropertyChanged implementation

		/// <summary>
		/// Triggers when Items Collections Changed.
		/// </summary>
		/// <param name="name">string type parameter named as name</param>
		private void RaisePropertyChanged(string name)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		#endregion
	}
}
