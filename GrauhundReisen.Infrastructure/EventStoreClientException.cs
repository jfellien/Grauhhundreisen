using System;

namespace GrauhundReisen.Infrastructure
{
  public class EventStoreClientException : Exception
  {
    public EventStoreClientException(string message) : base(message) { }
  }
}