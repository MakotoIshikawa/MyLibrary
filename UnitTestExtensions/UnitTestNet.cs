using System;
using System.Linq;
using System.Threading.Tasks;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetLibrary.Extensions;
using UnitTestExtensions.Data;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestNet {
		#region メソッド

		[TestMethod]
		[Owner(nameof(NetLibrary))]
		[TestCategory("取得")]
		public async Task 降水量情報取得() {
			var lat = 139.732293;
			var lon = 35.663613;
			var appid = "dj0zaiZpPTAxaDBCNkxtd2hVTSZzPWNvbnN1bWVyc2VjcmV0Jng9ZTM-";
			var url = $@"https://map.yahooapis.jp/weather/V1/place";
			var para = $@"coordinates={lat},{lon}&output=json&appid={appid}";
			var uri = new Uri($@"{url}?{para}");

			var json = await uri.GetJsonAsync<PrecipitationModel>();

			Assert.IsNotNull(json);

			var jobj = await uri.GetObjectAsync();
			var jstr = jobj.ToString();
			var feature = jobj[nameof(Feature)].FirstOrDefault();
			var weathers = (feature[nameof(Property)][nameof(WeatherList)][nameof(Weather)]);
			var ws = weathers.Select(w => new {
				Type = w[nameof(Weather.Type)],
				Date = w[nameof(Weather.Date)],
				Rainfall = w[nameof(Weather.Rainfall)],
			}).ToList();

			Assert.AreEqual(ws[0].Type, json.Feature[0].Property.WeatherList.Weather[0].Type);
		}

		[TestMethod]
		[Owner(nameof(NetLibrary))]
		[TestCategory("取得")]
		public async Task カテゴリID取得API() {
			var appid = "dj0zaiZpPTAxaDBCNkxtd2hVTSZzPWNvbnN1bWVyc2VjcmV0Jng9ZTM-";
			{
				var url = $@"https://shopping.yahooapis.jp/ShoppingWebService/V1/json/categorySearch";
				var category_id = 1;
				var para = $@"category_id={category_id}&appid={appid}";
				var uri = new Uri($@"{url}?{para}");

				var jobj = await uri.GetObjectAsync();
				var jstr = jobj.ToString();

				var result = jobj["ResultSet"]["0"]["Result"];
				var children = result["Categories"]["Children"];

				var cs = children.Select(c => c.First()).Where(c => c.HasValues).Select(c => new {
					sortOrder = c["_attributes"]["sortOrder"],
					Id = c["Id"],
					Url = c["Url"],
					Title = c["Title"]["Long"],
				}).ToList();

				Assert.IsNotNull(cs);
			}
		}

		[TestMethod]
		[Owner(nameof(NetLibrary))]
		[TestCategory("取得")]
		public async Task ショッピング商品検索API() {
			var appid = "dj0zaiZpPTAxaDBCNkxtd2hVTSZzPWNvbnN1bWVyc2VjcmV0Jng9ZTM-";
			{
				var url = $@"https://shopping.yahooapis.jp/ShoppingWebService/V1/json/itemSearch";
				var category_id = 635;
				var sort = "-sold";
				var para = $@"category_id={category_id}&sort={sort}&appid={appid}";
				var uri = new Uri($@"{url}?{para}");

				var jobj = await uri.GetObjectAsync();
				var jstr = jobj.ToString();

				var result = jobj["ResultSet"]["0"]["Result"];

				var cs = result.Select(c => c.First()).Where(c => c.HasValues).Select(c => new {
					Name = c["Name"],
					Url = c["Url"],
				}).Where(c => c.Name != null).ToList();

				Assert.IsNotNull(cs);
			}
		}

		#endregion
	}

	#region ショッピング


	#endregion
}
