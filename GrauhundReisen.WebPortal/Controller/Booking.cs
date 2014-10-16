using Nancy;
using System.Threading.Tasks;

namespace GrauhundReisen.WebPortal
{
	public class Booking : NancyModule
	{
		public Booking ()
		{
			Get ["change-booking/{id}"] = _ => GetBookingFormFor ((string)_.id);
			Post ["change-booking", true] = async(parameters, cancel) => await UpdateBooking ();
		}

		object GetBookingFormFor (string bookingId)
		{
			return View ["change-booking", new{
				FirstName = "Jan", 
				LastName = "Fellien", 
				EMail = "ich@you.com", 
				Destination = "Berlin",
				CreditCardNumber = "1234-5678-9012-3456",
				CreditCardType = "Visa"}];
		}

		async Task<object> UpdateBooking ()
		{
			var bookingId = this.Request.Form ["BookingId"].Value;
			var email = this.Request.Form ["EMail"].Value;
			var creditCardNumber = this.Request.Form ["CreditCardNumber"].Value;

			return View ["change-confirmation"];
		}
	}
}
