using System.Globalization;

namespace PopupMAUI
{
	/// <summary>
	/// Converter for PopupCustomization samples.
	/// </summary>
	public class TimingVisibilityConverter : IValueConverter
	{
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((value as TicketBookingInfo)!.Timing2 == null)
                {
                    return false;
                }

                return true;
            }

            return true;
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
