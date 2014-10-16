using Nancy;
using System.Collections.Generic;

namespace GrauhundReisen.WebPortal.Controller
{
	public class Admin : NancyModule
	{
		public Admin ()
		{
			Get ["show-all-my-events"] = _ => {

				return View ["show-all-my-events", new List<string> ()];
			};
		}
	}
}