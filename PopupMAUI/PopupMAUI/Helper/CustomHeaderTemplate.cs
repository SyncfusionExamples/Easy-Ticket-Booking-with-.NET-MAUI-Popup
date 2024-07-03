using Microsoft.Maui.Controls;
using Syncfusion.Maui.Core;
using StackLayout = Microsoft.Maui.Controls.StackLayout;

namespace PopupMAUI
{
	/// <summary>
	/// A class contains custom header template.
	/// </summary>
	public class CustomHeaderTemplate : SfView
	{
		/// <summary>
		/// Gets or sets the NumberOfLabel
		/// </summary>
		public int NumberOfLabel { get; set; } = 7;

        public CustomHeaderTemplate()
		{ 
			for (var i = 0; i < this.NumberOfLabel; i++)
			{
                this.Children.Add(this.CreateDateLayout(i));                
			}
		}

        protected override Size ArrangeContent(Rect bounds)
        {
            double w = 0;            
            for (var i = 0; i < this.NumberOfLabel; i++)
            {
				this.Children[i].Arrange(new Rect(w, 0, bounds.Width / this.NumberOfLabel, bounds.Height));
                w = w + (bounds.Width / this.NumberOfLabel);
            }
            return new Size(bounds.Width, bounds.Height);
        }

		/// <summary>
		/// Used to Creates Date Layout
		/// </summary>
		/// <param name="i">integer type parameter named as i</param>
		/// <returns>returns the StackLayout value</returns>
		private View CreateDateLayout(int i)
		{
			StackLayout layout = new StackLayout();
			layout.BackgroundColor = Colors.White;
			//layout.Padding = new Thickness(0, 0, 0, 10);
			layout.Orientation = StackOrientation.Vertical;

			layout.Children.Add(this.CreateDayLabel(i));
			layout.Children.Add(this.CreateDateLabel(i));
			var boxView = new BoxView()
			{
				VerticalOptions = LayoutOptions.End,
				WidthRequest = 31,
				BackgroundColor = Color.FromArgb("#6750A4"),
				HeightRequest = 3,
				CornerRadius = new CornerRadius(2, 2, 0, 0),
			};
			layout.Children.Add(boxView);
			this.SetBackgroundColorForLabels(i, layout);
			this.AddTapGesture(layout);
			return layout;
		}

		/// <summary>
		/// Adding TapGesture to StackLayout
		/// </summary>
		/// <param name="layout">StackLayout type parameter named as layout</param>
		private void AddTapGesture(StackLayout layout)
		{
			var tapGesture = new TapGestureRecognizer();
			layout.GestureRecognizers.Add(tapGesture);
			tapGesture.Tapped += this.DateLayout_Tapped;
		}

		/// <summary>
		/// Triggers when DateLayout is tapped.
		/// </summary>
		/// <param name="sender">DateLayout_Tapped event sender</param>
		/// <param name="e">DateLayout_Tapped args e</param>
		private void DateLayout_Tapped(object? sender, TappedEventArgs e)
		{
			var stackLayout = sender as StackLayout;

            // Update background color for other date cells            
            foreach (var children in this.Children)
			{
				((children as StackLayout)!.Children[0] as Label)!.TextColor = Color.FromArgb("#49454F");
				((children as StackLayout)!.Children[1] as Label)!.TextColor = Color.FromArgb("#49454F");
				((children as StackLayout)!.Children[2] as BoxView)!.IsVisible = false;
			}

			// Update background color for selected date cell
			(stackLayout.Children[0] as Label)!.TextColor = Color.FromArgb("#6750A4");
			(stackLayout.Children[1] as Label)!.TextColor = Color.FromArgb("#6750A4");
			(stackLayout.Children[2] as BoxView)!.IsVisible = true;
			stackLayout = null;
		}

		/// <summary>
		/// Used to Create Date Label.
		/// </summary>
		/// <param name="i">integer type parameter named as i</param>
		/// <returns>returns newly created label</returns>
		private View CreateDateLabel(int i)
		{
			Label dateLabel = new Label();
			dateLabel.FontSize = 14;
			dateLabel.HorizontalOptions = LayoutOptions.Center;
			dateLabel.VerticalOptions = LayoutOptions.Center;
			dateLabel.HeightRequest = 31;
			dateLabel.FontAttributes = FontAttributes.Bold;
			dateLabel.Text = DateTime.Now.AddDays(i).Day.ToString();
			dateLabel.TextColor = Color.FromArgb("#49454F");
			return dateLabel;
		}

		/// <summary>
		/// Used to Create day Label.
		/// </summary>
		/// <param name="i">integer type parameter to add days</param>
		/// <returns>returns newly created label</returns>
		private Label CreateDayLabel(int i)
		{
			Label dayLabel = new Label();
			dayLabel.TextColor = Color.FromArgb("#49454F");
			dayLabel.FontSize = 12;
			dayLabel.HorizontalOptions = LayoutOptions.Center;
			dayLabel.VerticalOptions = LayoutOptions.Center;
			dayLabel.VerticalTextAlignment = TextAlignment.Center;
			dayLabel.HeightRequest = 31;
			dayLabel.Text = DateTime.Now.AddDays(i).DayOfWeek.ToString().Substring(0, 3).ToUpper();
			return dayLabel;
		}

		/// <summary>
		/// Used to Set BackgroundColor For Labels
		/// </summary>
		/// <param name="i">integer typed parameter named as i</param>
		/// <param name="layout">returns the layout</param>
		private void SetBackgroundColorForLabels(int i, StackLayout layout)
		{
			if (i == 0)
			{
				(layout.Children[0] as Label)!.TextColor = Color.FromArgb("#6750A4");
				(layout.Children[1] as Label)!.TextColor = Color.FromArgb("#6750A4");
			}
			else
			{
				(layout.Children[2] as BoxView)!.IsVisible = false;
			}
		}
	}
}
