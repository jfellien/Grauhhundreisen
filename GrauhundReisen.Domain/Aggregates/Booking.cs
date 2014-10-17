using System.Collections.Generic;

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

    public Booking(IEnumerable<object> history)
    {
      _history = history;
    }

    public IEnumerable<object> Changes
    {
      get { return _changes; }
    } 
  }
}