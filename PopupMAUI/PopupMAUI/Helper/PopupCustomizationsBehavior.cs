

namespace PopupMAUI
{
	/// <summary>
	/// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
	/// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  SeatSelection samples
	/// </summary>
	public class PopupCustomizationsBehavior : Behavior<ContentPage>
	{
		/// <summary>
		/// You can override this method to subscribe to AssociatedObject events and initialize properties.
		/// </summary>
		/// <param name="bindable">Label type of parameter bindAble</param>
		protected override void OnAttachedTo(ContentPage bindable)
		{
			base.OnAttachedTo(bindable);
			(bindable.Resources["BookingNotification"] as Syncfusion.Maui.Popup.SfPopup)!.Show();			
		}
	}
}
