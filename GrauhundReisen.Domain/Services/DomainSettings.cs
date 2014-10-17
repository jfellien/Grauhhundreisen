using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrauhundReisen.Domain.Aggregates;
using GrauhundReisen.Infrastructure;

namespace GrauhundReisen.Domain.Services
{

		class DomainSettings
		{
			public static EventStoreClientConfiguration DefaultEventStoreCleintConfiguration
			{
				get
				{
					var esConfig = new EventStoreClientConfiguration
					{
						AccountId = "MyTestAccount",
						InitActionName = "init",
						RemoveActionName = "remove",
						RetrieveActionName = "events",
						StoreActionName = "store",
						ServerUri = new Uri("http://openspace2014.azurewebsites.net")
					};

					return esConfig;
				}
			}
		}

}
