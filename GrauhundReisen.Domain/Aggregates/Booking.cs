using System.Collections.Generic;
using GrauhundReisen.Contracts.Events;
using System.Linq;

namespace GrauhundReisen.Domain.Aggregates
{
	public class Booking
	{
		private readonly IEnumerable<object> _history;
		private readonly IList<object> _changes;

		public static Booking FromEvents (IEnumerable<object> events)
		{
			return new Booking (events);
		}

		public Booking ()
		{
			_changes = new List<object> ();
		}

		protected Booking (IEnumerable<object> history) : this ()
		{
			_history = history;
		}

		public IEnumerable<object> Changes {
			get { return _changes; }
		}

		public void Order (string bookingId, string destination,
		                   string creditCardNumber, string creditCardType,
		                   string email, string firstName, string lastName)
		{
			var bookingOrdererd = new BookingOrdered {
				BookingId = bookingId,
				Destination = destination,
				CreditCardNumber = creditCardNumber,
				CreditCardType = creditCardType,
				Email = email,
				LastName = lastName
			};

			_changes.Add (bookingOrdererd);
		}

		public void UpdateEmail (string email)
		{
			var updateEmail = new BookingEmailChanged {
				BookingId = this.BookingId,
				Email = email
			};

			_changes.Add (updateEmail);
		}

		public void UpdateCreditCardNumber (string creditCardNumber)
		{
			var updateCreditCardNumber = new BookingCreditCardNumberChanged {
				BookingId = this.BookingId,
				CreditCardNumber = creditCardNumber
			};

			_changes.Add (updateCreditCardNumber);
		}

		public string BookingId {
			get { 
				return _history.OfType<BookingOrdered> ().First ().BookingId;
			}
		}
	}
}