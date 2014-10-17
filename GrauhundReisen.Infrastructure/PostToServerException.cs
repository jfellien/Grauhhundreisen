using System;
using System.Collections.Generic;
using System.Linq;
using GrauhundReisen.Contracts;
using RestSharp;
using RestSharp.Deserializers;
using fastJSON;
using GrauhundReisen.Infrastructure;

namespace Grauhundreisen.Infrastructure
{

	public class PostToServerException : Exception
	{
		public PostToServerException (string message) : base(message)
		{

		}
	}

}