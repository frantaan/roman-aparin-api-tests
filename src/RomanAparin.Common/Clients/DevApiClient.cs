using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using RomanAparin.Common.DataBuilders.Models.Requests;
using RomanAparin.Common.DataBuilders.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RomanAparin.Common.Clients
{
    public interface IDevApiClient
    {
        Task<T> GetItems<T>(CancellationToken token = default);
        Task<T> PostCoupon<T>(Dictionary<string, string> query, CancellationToken token = default);
        Task<T> PostCheckout<T>(CheckoutRequest requestData, CancellationToken token = default);
    }
    public class DevApiClient : BaseHttpClient, IDevApiClient
    {
        public DevApiClient(IOptions<TestServicesOptions> options) : base(options)
        {
        }

        public async Task<T> GetItems<T>(CancellationToken token = default)
        {
            var result = await SendAsync<T>(HttpMethod.Get, "Dev/items", requestData: null);
            return result;
        }

        public async Task<T> PostCoupon<T>(Dictionary<string,string> query, CancellationToken token = default)
        {
            var endpoint = QueryHelpers.AddQueryString("Dev/coupon", query);
            var result = await SendAsync<T>(HttpMethod.Post, endpoint, requestData: query, token: token);
            return result;
        }

        public async Task<T> PostCheckout<T>(CheckoutRequest requestData, CancellationToken token = default)
        {
            var result = await SendAsync<T>(HttpMethod.Post, "Dev/checkout", requestData!, token: token);
            return result;
        }
    }
}
