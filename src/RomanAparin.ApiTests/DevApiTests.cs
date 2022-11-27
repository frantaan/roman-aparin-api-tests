using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RomanAparin.ApiTests;
using RomanAparin.Common;
using RomanAparin.Common.DataBuilders;
using RomanAparin.Common.DataBuilders.Models.Responses;
using RomanAparin.Common.DataBuilders.TestData;
using RomanAparin.Common.Helpers;
using static RomanAparin.Common.TestServices;

namespace RomanAparin.ApiTests
{
    [TestFixture]
    public class DevApiTests : TestBase
    {
        [TestCaseSource(typeof(DevApiTestsCases), nameof(DevApiTestsCases.CalculateDiscount))]
        public async Task DevApi_CalculateDiscount_VerifyValue(TestData data)
        {
            var couponResult = await DevApiClient.PostCoupon<CouponResponse>(data.DictionariesOfStrings["query"]);
            Assert.IsTrue(couponResult.Discount <= 100, $"Coupon discount more than 100. Current discount value = {couponResult.Discount}");
        }


        [TestCaseSource(typeof(DevApiTestsCases), nameof(DevApiTestsCases.Checkout_ValidateCardNumbers))]
        public async Task DevApi_Сheckout_VerifyCardNumber(TestData data)
        {
            var result = await data.ChechoutRequests["1"].SendToApi();
            Assert.That(data.Booleans["expected"], Is.EqualTo(result.Success), $"Success status should be: {result.Success} for {data.ChechoutRequests["1"].CcNumber.Length} lenght card");
            Assert.Multiple(() =>
            {
                Assert.That(data.ChechoutRequests["1"].FirstName, Is.EqualTo(result.Event.FirstName));
                Assert.That(data.ChechoutRequests["1"].LastName, Is.EqualTo(result.Event.LastName));
                Assert.That(data.ChechoutRequests["1"].CcName, Is.EqualTo(result.Event.CcName));
                Assert.That(data.ChechoutRequests["1"].Ccexpiration, Is.EqualTo(result.Event.Ccexpiration));
                Assert.That(data.ChechoutRequests["1"].CcNumber, Is.EqualTo(result.Event.CcNumber));
                Assert.That(data.ChechoutRequests["1"].CcCvv, Is.EqualTo(result.Event.CcCvv));
                Assert.That(data.ChechoutRequests["1"].PaymentMethod, Is.EqualTo(result.Event.PaymentMethod));
            });
        }

        [TestCaseSource(typeof(DevApiTestsCases), nameof(DevApiTestsCases.GetItems))]
        public async Task DevApi_GetItems_DataShouldBeReturn(TestData data)
        {
            var items = await DevApiClient.GetItems<ItemsResponse[]>();
            Assert.NotNull(items.Where(x => x.Name == data.Strings["name_expeted"]).FirstOrDefault());
            Assert.NotNull(items.Where(x => x.Description == data.Strings["description_expeted"]).FirstOrDefault());
            Assert.NotNull(items.Where(x => x.Price == data.Integers["price_expeted"]).FirstOrDefault());
            Assert.That(items.Count, Is.EqualTo(data.Integers["count_expeted"]));
        }
    }

    public static class DevApiTestsCases
    {
        public static IEnumerable CalculateDiscount
        {
            get
            {
                var data1 = new TestData();
                var coupon = StringHelper.RandomString(0);
                data1.DictionariesOfStrings["query"] = new Dictionary<string, string>
                {
                    { "coupon", coupon }
                };
                yield return new TestCaseData(data1).SetArgDisplayNames("Сorrectly calculates discount percent | Descount less 100%");

                var data2 = new TestData();
                coupon = StringHelper.RandomString(100);
                data2.DictionariesOfStrings["query"] = new Dictionary<string, string>
                {
                    { "coupon", coupon }
                };
                yield return new TestCaseData(data2).SetArgDisplayNames("Сorrectly calculates discount percent | Descount equal 100%");

                var data3 = new TestData();
                coupon = StringHelper.RandomString(101);
                data3.DictionariesOfStrings["query"] = new Dictionary<string, string>
                {
                    { "coupon", coupon }
                };
                yield return new TestCaseData(data3).SetArgDisplayNames("Сorrectly calculates discount percent | Descount more 100%");
            }
        }

        public static IEnumerable Checkout_ValidateCardNumbers
        {
            get
            {
                var data1 = new TestData();
                var ccNumber = StringHelper.RandomString(0);
                data1.ChechoutRequests["1"] = CouponRequestExtension.CreateCouponRequest(firstName: "Test1", lastName: "Test1", paymentMethod: "CARD",
                    ccName: "Test1", ccNumber: ccNumber, ccExpDate: "11/25", ccCvv: "123");
                data1.Booleans["expected"] = false;
                yield return new TestCaseData(data1).SetArgDisplayNames("Send checkout request, verify card number | Card number < 16");

                var data2 = new TestData();
                ccNumber = StringHelper.RandomString(17);
                data2.ChechoutRequests["1"] = CouponRequestExtension.CreateCouponRequest(firstName: "Test2", lastName: "Test2", paymentMethod: "CARD",
                    ccName: "Test2", ccNumber: ccNumber, ccExpDate: "11/25", ccCvv: "123");
                data2.Booleans["expected"] = false;
                yield return new TestCaseData(data2).SetArgDisplayNames("Send checkout request, verify card number | Card number > 16");

                var data3 = new TestData();
                ccNumber = StringHelper.RandomString(16);
                data3.ChechoutRequests["1"] = CouponRequestExtension.CreateCouponRequest(firstName: "Test3", lastName: "Test3", paymentMethod: "CARD",
                    ccName: "Test3", ccNumber: ccNumber, ccExpDate: "11/25", ccCvv: "123");
                data3.Booleans["expected"] = true;
                yield return new TestCaseData(data3).SetArgDisplayNames("Send checkout request, verify card number | Card number = 16");
            }
        }
        public static IEnumerable GetItems
        {
            get
            {
                var data1 = new TestData();
                data1.Integers["count_expeted"] = 2;
                data1.Strings["name_expeted"] = "T-Shirt"; 
                data1.Strings["description_expeted"] = "Small T-Shirt";
                data1.Integers["price_expeted"] = 3;
                yield return new TestCaseData(data1).SetArgDisplayNames("Get all items | Verify mock data");
            }
        }
    }
}