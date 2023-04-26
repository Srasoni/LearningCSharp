using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace CookieLogin
{
	public class ConfigureMyCookie : IConfigureNamedOptions<CookieAuthenticationOptions>
	{
		private readonly MyService _myService;

		// You can inject services here
		public ConfigureMyCookie(MyService myService)
		{
			_myService = myService;
		}

		// AddSchemeHelper from builder.Services.AddAuthentication.AddCookie
		public void Configure(string? name, CookieAuthenticationOptions options)
		{
			if (name == null || options == null)
			{
				throw new ArgumentNullException(nameof(options));
			}

			// Only configure the schemes you want
			if (name == CookieScheme.Name)
			{
				//options.LoginPath = "/someotherpath";
			}

			// use the injected service here
			//_myService.DoSomething();
		}

		public void Configure(CookieAuthenticationOptions options)
		{
			throw new NotImplementedException();
		}
	}
}
