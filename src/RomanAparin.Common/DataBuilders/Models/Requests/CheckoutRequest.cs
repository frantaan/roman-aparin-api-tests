using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RomanAparin.Common.DataBuilders.Models.Requests
{
    public class CheckoutRequest
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("cc-name")]
        public string CcName { get; set; }

        [JsonPropertyName("cc-number")]
        public string CcNumber { get; set; }

        [JsonPropertyName("ccexpiration")]
        public string Ccexpiration { get; set; }

        [JsonPropertyName("cc-cvv")]
        public string CcCvv { get; set; }
    }
}
