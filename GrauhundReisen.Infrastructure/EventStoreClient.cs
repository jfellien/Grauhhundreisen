﻿using System;
using System.Runtime.Remoting.Messaging;
using Grauhundreisen.Infrastructure;
using RestSharp;

namespace GrauhundReisen.Infrastructure
{
  public class EventStoreClient
  {
    public static EventStoreClient InitWith(
      EventStoreClientConfiguration configuration)
    {
      if (configuration.IsComplete())
        return new EventStoreClient(configuration);

      throw new EventStoreClientException("The configuration is incomplete");
    }

    public EventStoreClient(EventStoreClientConfiguration configuration)
    {
      ServerUri = configuration.ServerUri;
      AccountId = configuration.AccountId;

      SetUpUris(configuration);

      InitEventStore();
    }

    public string AccountId { get; set; }
    public Uri ServerUri { get; set; }

    private void InitEventStore()
    {
      var restClient = new RestClient(InitUri.ToString());
      var request = new RestRequest(Method.POST);
    }

    private void SetUpUris(EventStoreClientConfiguration configuration)
    {
      InitUri = ServerUri
        .Add(configuration.InitActionName)
        .Add(configuration.AccountId);

      StoreUri = ServerUri
        .Add(configuration.RetrieveActionName)
        .Add(configuration.AccountId);

      RetrieveUri = ServerUri
        .Add(configuration.RemoveActionName)
        .Add(configuration.AccountId);

      RemoveUri = ServerUri
        .Add(configuration.RemoveActionName)
        .Add(configuration.AccountId);
    }

    public Uri RemoveUri { get; private set; }
    public Uri RetrieveUri { get; private set; }
    public Uri StoreUri { get; private set; }
    public Uri InitUri { get; private set; }
  }
}