using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace backendangular.Controllers {
	
	[ApiController]
	[Route("[controller]")]
	public class OAuthController : ControllerBase {

		[HttpGet]
		[Route("AccessToken")]
		public async System.Threading.Tasks.Task<ActionResult> AccessTokenAsync() {

			string clientId = "dsserver.EMRWLJAdPpZirYLDNAF0gP7QzQaB8OfH";
			string clientSecret = "OGC24l8BcjVpc90SHt0gHJhDjtYJP70a";

			string serviceUrl = "https://trial.dsserver.io";
			string ClientCredentials = "client_credentials";

			AccessTokenResponse token;

			HttpClient m_client = new HttpClient();

			var payload = new Dictionary<string, string> {
				["grant_type"] = ClientCredentials,
			};
			string requestUri = $"{serviceUrl}/oauth/token";
			var tokenRequest = new HttpRequestMessage(HttpMethod.Post, requestUri) {
				Content = new StringContent(UrlEncode(payload), Encoding.UTF8, "application/x-www-form-urlencoded")
			};

			// Add basic auth header containing client id and secret
			string credentials = $"{clientId}:{clientSecret}";
			byte[] credentialsUtf8 = Encoding.UTF8.GetBytes(credentials);
			string credentialsB64 = Convert.ToBase64String(credentialsUtf8);
			tokenRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentialsB64);

			var tokenResponse = await m_client.SendAsync(tokenRequest);

			var tokenResponseStream = await tokenResponse.Content.ReadAsStringAsync();

			token = JsonConvert.DeserializeObject<AccessTokenResponse>(tokenResponseStream);
			
			return Ok(token);
		}

		public string UrlEncode(Dictionary<string, string> dict) {
			return string.Join("&", dict.Keys.Select(k => $"{k}={WebUtility.UrlEncode(dict[k])}"));
		}

	}
}
