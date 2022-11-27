using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RomanAparin.Common.DataBuilders.Models.Responses
{
    public class CouponResponse
    {
        [JsonPropertyName("discount")]
        public int Discount { get; set; }
    }
}
