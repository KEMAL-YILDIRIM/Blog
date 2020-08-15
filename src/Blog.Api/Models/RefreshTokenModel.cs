using System;

namespace Blog.Api.Models
{
	public class RefreshTokenModel
	{
		public string RefreshToken { get; set; }
		public DateTime Expires { get; set; }
		public DateTime Created { get; set; }
		public string CreatedByIp { get; set; }
	}
}