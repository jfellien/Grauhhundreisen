﻿using System;
using Nancy;
using System.Threading.Tasks;
using System.Collections.Generic;
using GrauhundReisen.Domain.Services;

namespace GrauhundReisen.WebPortal
{
	public class Index : NancyModule
	{
		BookingService _bookingService;

		public Index (BookingService bookingService)
		{
			_bookingService = bookingService;

			Get [""] = _ => ShowBookingForm ();

			Post ["", runAsync: true] = async(parameters, cancel) => await ProceedBooking ();
		}

		object ShowBookingForm ()
		{
		
			var creditCardTypes = new List<dynamic> { 
				new {Name = "American Express"},
				new {Name = "Master Card" },
				new {Name = "Visa"}
			};

			var destinations = new List<dynamic> { 
				new {Name = "Berlin"},
				new {Name = "Leipzig" },
				new {Name = "Hamburg"},
				new {Name = "München"}
			};

			return View ["index", new { 
				CreditCardTypes = creditCardTypes, 
				Destinations = destinations }];
		}

		async Task<object> ProceedBooking ()
		{
			var bookingId = Guid.NewGuid ().ToString ();
			var destination = this.Request.Form ["Destination"].Value;
			var creditCardNumber = this.Request.Form ["CreditCardNumber"].Value;
			var creditCardType = this.Request.Form ["CreditCardType"].Value;
			var email = this.Request.Form ["Email"].Value;
			var firstName = this.Request.Form ["FirstName"].Value;
			var lastName = this.Request.Form ["LastName"].Value;

			await _bookingService.OrderBooking (bookingId, 
				destination, 
				creditCardNumber, creditCardType, 
				email, firstName, lastName);

			return View ["confirmation", new {BookingId = bookingId}];
		}
	}
}