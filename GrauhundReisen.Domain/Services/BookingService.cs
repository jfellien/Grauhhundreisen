using System.Threading.Tasks;

namespace GrauhundReisen.Domain.Services
{
  public class BookingService
  {
    public async Task Orderbooking(string bookingId,
      string destination,
      string creditCardNumber, string creditCardType,
      string email, string firstName, string lastName)
    {
      var booking = new Booking();

      booking.Order(bookingId,
        destination,
        creditCardNumber, creditCardType,
        email, firstName, lastName);

      await Task.Factory.StartNew(() => booking.Changes.ToList().ForEach(
        change =>
        {
          _eventStoreClient.Store(bookingId, change);
          _eventHandling(change);
        }));
    }
  }
}