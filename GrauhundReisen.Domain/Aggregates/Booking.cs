using System.Collections.Generic;
using GrauhundReisen.Contracts.Events;

namespace GrauhundReisen.Domain.Aggregates
{
  public class Booking
  {
    private readonly IEnumerable<object> _history;
    private readonly IList<object> _changes;

    public static Booking FromEvents(IEnumerable<object> events)
    {
      return new Booking(events);
    }

    public Booking()
    {
      _changes = new List<object>();
    }

    protected Booking(IEnumerable<object> history) : this()
    {
      _history = history;
    }

    public IEnumerable<object> Changes
    {
      get { return _changes; }
    }

    public void Order(string bookingId, string destination,
      string creditCardNumber, string creditCardType,
      string email, string firstName, string lastName)
    {
      var bookingOrdererd = new BookingOrdered
      {
        BookingId = bookingId,
        Destination = destination,
        CreditCardNumber = creditCardNumber,
        CreditCardType = creditCardType,
        Email = email,
        LastName = lastName
      };

      _changes.Add(bookingOrdererd);
    }
  }
}