using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendangular.Middleware {
	public class SecurityMiddleware {

		private RequestDelegate m_next;

		public SecurityMiddleware(RequestDelegate next) {
			m_next = next;
		}

		public async Task Invoke(HttpContext context) {
			
			// compare host with allowed stored host names
			var allowedHost = "localhost:32760";
			
			if (context.Request.Host.ToString() != allowedHost)
				throw new UnauthorizedAccessException();
			else
				await m_next.Invoke(context);
		}
	}
}
