namespace GrauhundReisen.Contracts.Events
{

	public class BookingCreditCardNumberChanged
	{
		public string BookingId { get; set; }

		public string CreditCardNumber { get; set; }
	}

}