using System;

namespace GrauhundReisen.Infrastructure
{
  public class EventStoreClientConfiguration
  {
    public Uri ServerUri { get; set; }
    public string InitActionName { get; set; }
    public string StoreActionName { get; set; }
    public string RetrieveActionName { get; set; }

    public string RemoveActionName { get; set; }

    public string AccountId { get; set; }

    public bool IsComplete()
    {
      return ServerUri.ToString().IsNotNullOrEmpty()
             && InitActionName.IsNotNullOrEmpty()
             && StoreActionName.IsNotNullOrEmpty()
             && RetrieveActionName.IsNotNullOrEmpty()
             && AccountId.IsNotNullOrEmpty();
    }
  }
}