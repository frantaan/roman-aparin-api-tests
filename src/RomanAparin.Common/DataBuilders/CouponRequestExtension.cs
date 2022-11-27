using RomanAparin.Common.DataBuilders.Models.Requests;
using RomanAparin.Common.DataBuilders.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanAparin.Common.DataBuilders
{
    public static class CouponRequestExtension
    {
        public static CheckoutRequest CreateCouponRequest(string firstName, string lastName, string paymentMethod, 
            string ccName, string ccNumber, string ccExpDate, string ccCvv)
        {
            return new CheckoutRequest()
            {
                FirstName = firstName,
                LastName = lastName,
                PaymentMethod = paymentMethod,
                CcName = ccName,
                CcNumber = ccNumber,
                Ccexpiration= ccExpDate,
                CcCvv= ccCvv
            };
        }

        public static async Task<CheckoutResponse> SendToApi(this CheckoutRequest data) => await TestServices.DevApiClient.PostCheckout<CheckoutResponse>(data);
    }
}
