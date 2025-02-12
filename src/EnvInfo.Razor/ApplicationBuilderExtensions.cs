using EnvInfo.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvInfo.Razor
{
	public static class ApplicationBuilderExtensions
	{
		/// <summary>
		/// Adds a middleware that returns the environment information as JSON.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance of server application.</param>
		public static IApplicationBuilder UseBlazorEnvInfo(this IApplicationBuilder app)
		{
			app.Use(async (context, next) =>
			{
				if (context.Request.Path == "/_envinfo")
				{
					var envInfoOptions = context.RequestServices.GetRequiredService<EnvInfoOptions>();
					var json = System.Text.Json.JsonSerializer.Serialize(new { EnvInfo = envInfoOptions });

					context.Response.StatusCode = 200;
					context.Response.ContentType = "application/json";
					context.Response.Headers["Cache-Control"] = "no-store";
					context.Response.Headers["Pragma"] = "no-cache";

					await context.Response.WriteAsync(json);
				}
				else
				{
					await next();
				}
			});

			return app;
		}
	}
}
