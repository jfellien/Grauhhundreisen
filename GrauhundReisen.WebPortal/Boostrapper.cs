using Nancy;
using Nancy.TinyIoc;
using System;
using GrauhundReisen.Domain.Services;
using Nancy.Bootstrapper;
using GrauhundReisen.ReadModel;

namespace GrauhundReisen.WebPortal
{
	public class Boostrapper : DefaultNancyBootstrapper
	{
		// Auskommentieren und anpassen für die eigene Umgebung
		// const string ConnectionString = @"C:\[Path to your Development Folder]\GrauhundReisen\GrauhundReisen.WebPortal\Content\DataStore\Bookings\";
		const String ConnectionString = "Content/DataStore/Bookings/";

		protected override void ApplicationStartup (TinyIoCContainer container, IPipelines pipelines)
		{
			StaticConfiguration.DisableErrorTraces = false;

			SetupIoC (container);

			base.ApplicationStartup (container, pipelines);
		}

		private static void SetupIoC (TinyIoCContainer container)
		{
			var bookingService = new BookingService ();
			var bookingHandler = new BookingHandler (ConnectionString);

			bookingService.WhenStatusChanged (bookingHandler.Handle);

			container.Register (bookingService);
		}
	}
}
