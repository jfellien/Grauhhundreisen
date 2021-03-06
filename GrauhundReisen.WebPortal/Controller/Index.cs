﻿using System;
using GrauhundReisen.Domain.Services;
using Nancy;
using GrauhundReisen.ReadModel.Repositories;
using System.Threading.Tasks;

namespace GrauhundReisen.WebPortal
{
	public class Index : NancyModule
	{
		readonly BookingService _bookingService;

		public Index (BookingForm bookingForm, BookingService bookingService)
		{
			_bookingService = bookingService;

			Get [""] = _ => View ["index", new { bookingForm.CreditCardTypes, bookingForm.Destinations }];

			Post ["", runAsync: true] = async(parameters, cancel) => await ProceedBooking();
		}

		async Task<object> ProceedBooking()
		{
		    var bookingId = Guid.NewGuid().ToString();
		    var destination = this.Request.Form["Destination"].Value;
		    var creditCardNumber = this.Request.Form["PaymentCreditCardNumber"].Value;
		    var creditCardType = this.Request.Form["PaymentCreditCardType"].Value;
		    var email = this.Request.Form["TravellerEmail"].Value;
		    var firstName = this.Request.Form["TravellerFirstName"].Value;
		    var lastName = this.Request.Form["TravellerLastName"].Value;

		    await _bookingService.OrderBooking(bookingId,
		        destination,
		        creditCardNumber, creditCardType,
		        email, firstName, lastName);

			return View ["confirmation", new {BookingId = bookingId}];
		}
	}
}