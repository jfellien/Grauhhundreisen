namespace GrauhundReisen.Contracts.Events
{
	public class BookingOrdered
	{
		public string BookingId { get; set; }

		public string Destination { get; set; }

		public string CreditCardNumber { get; set; }

		public string CreditCardType { get; set; }

		public string Email { get; set; }

		public string FirstName {
			get;
			set;
		}

		public string LastName { get; set; }
	}



}