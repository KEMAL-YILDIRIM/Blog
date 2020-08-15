using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;
using Blog.ORM.Context;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Integration.Tests.Common
{
	public class Utilities
	{
		public static StringContent GetRequestContent(object obj)
		{
			return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
		}

		public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
		{
			var stringResponse = await response.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<T>(stringResponse);

			return result;
		}

		public static void InitializeDbForTests(BlogContext context)
		{
			var id = Guid.NewGuid().ToString();
			var user = new User(
				"Jason",
				"Taylor",
				"JASON",
				"Jason.cogan@enn.www",
				@"ZCvDWMZLH6l763UjsGxhLsMZnz6/iGp4a9q1/N//XpSC6KI6fvpbEWKt/CQOQyrpjjQ/2V2K72SCm2ro6JmgYw==",
				id,
				new List<Phone> {
					new Phone {
						Number = "01111222333",
						Type=new Domain.PropertyEntities.Type(1,"Home"),
						UserId = id
						}
				},
				null,
				null);
			context.Users.Add(user);
			context.SaveChanges();
		}
	}
}
