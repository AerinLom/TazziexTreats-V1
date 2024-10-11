using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;

namespace TazzieXTreats_Webapp.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Checkout(int subtotal)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = subtotal, // Use the subtotal in cents
                            Currency = "zar",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Payment" // Replace with your product name or logic to get the product name
                            }
                        },
                        Quantity = 1 // Use the total quantity of items if needed
                    }
                },
                Mode = "payment",
                SuccessUrl = "https://localhost:7269/home/dashboard",
                CancelUrl = "https://localhost:5000/cancel"
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url);
        }
    }
}