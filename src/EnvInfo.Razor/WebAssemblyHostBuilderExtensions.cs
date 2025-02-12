using EnvInfo.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EnvInfo.Razor
{
	public static class WebAssemblyHostBuilderExtensions
	{
		/// <summary>
		/// Adds EnvInfo services to the specified <see cref="WebAssemblyHostBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="WebAssemblyHostBuilder" /> to add services to.</param>
		/// <param name="options">Default options</param>
		public static async Task<WebAssemblyHostBuilder> AddEnvInfo(this WebAssemblyHostBuilder builder, EnvInfoOptions options = null!)
		{
			await LoadAppSettingsAsync(builder);

			builder.Services.TryAddSingleton(p =>
			{
				options = options ?? EnvInfoOptions.InitializeDefaultOptions(builder.HostEnvironment.Environment);
				var envInfoSection = builder.Configuration.GetSection("EnvInfo");
				envInfoSection?.Bind(options);
				return options;
			});

			return builder;
		}

		/// <summary>
		/// Adds EnvInfo services to the specified <see cref="WebAssemblyHostBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="WebAssemblyHostBuilder" /> to add services to.</param>
		/// <param name="envName">Custom enviroment name</param>
		public static async Task<WebAssemblyHostBuilder> AddEnvInfo(this WebAssemblyHostBuilder builder, string envName)
		{
			await LoadAppSettingsAsync(builder);

			builder.Services.TryAddSingleton(p =>
			{
				var options = EnvInfoOptions.InitializeDefaultOptions(builder.HostEnvironment.Environment);
				var envInfoSection = builder.Configuration.GetSection("EnvInfo");
				envInfoSection?.Bind(options);
				options.Name = envName;
				return options;
			});

			return builder;
		}

		/// <summary>
		/// Adds EnvInfo services to the specified <see cref="WebAssemblyHostBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="WebAssemblyHostBuilder" /> to add services to.</param>
		public static async Task<WebAssemblyHostBuilder> AddEnvInfo(this WebAssemblyHostBuilder builder)
		{
			return await builder.AddEnvInfo(default(EnvInfoOptions)!);
		}

		private static async Task LoadAppSettingsAsync(WebAssemblyHostBuilder builder)
		{
			// read JSON file as a stream for configuration
			var client = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
			// UseBlazorEnvInfo middleware url
			using var response = await client.GetAsync("_envinfo");
			using var stream = await response.Content.ReadAsStreamAsync();
			builder.Configuration.AddJsonStream(stream);
		}
	}
}
