using Newtonsoft.Json;

namespace backendangular
{
	internal class AccessTokenResponse {
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }
		[JsonProperty("token_type")]
		public string TokenType { get; set; }
		[JsonProperty("expires_in")]
		public string ExpiresIn { get; set; }
	}


}
