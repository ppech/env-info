using EnvInfo.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>
	/// Extension methods for setting up EnvInfo services in an <see cref="IServiceCollection" />.
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds EnvInfo services to the specified <see cref="IServiceCollection" />.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
		/// <param name="options">Default options</param>
		public static IServiceCollection AddEnvInfo(this IServiceCollection services, EnvInfoOptions options = null)
		{
			services.TryAddSingleton(p =>
			{
				var configuration = p.GetRequiredService<IConfiguration>();
				var env = p.GetRequiredService<IHostEnvironment>();
				options = options ?? EnvInfoOptions.InitializeDefaultOptions(env.EnvironmentName);

				var envInfoSection = configuration.GetSection("EnvInfo");
				envInfoSection?.Bind(options);

				return options;
			});

			return services;
		}

		/// <summary>
		/// Adds EnvInfo services to the specified <see cref="IServiceCollection" />.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
		/// <param name="envName">Custom enviroment name</param>
		public static IServiceCollection AddEnvInfo(this IServiceCollection services, string envName)
		{
			services.TryAddSingleton(p =>
			{
				var configuration = p.GetRequiredService<IConfiguration>();
				var env = p.GetRequiredService<IHostEnvironment>();
				var options = EnvInfoOptions.InitializeDefaultOptions(env.EnvironmentName);

				var envInfoSection = configuration.GetSection("EnvInfo");
				envInfoSection?.Bind(options);

				options.Name = envName;

				return options;
			});

			return services;
		}

		/// <summary>
		/// Adds EnvInfo services to the specified <see cref="IServiceCollection" />.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
		/// <param name="envInfoSection">Custom configuration section</param>
		public static IServiceCollection AddEnvInfo(this IServiceCollection services, IConfiguration envInfoSection)
		{
			services.TryAddSingleton(p =>
			{
				var configuration = p.GetRequiredService<IConfiguration>();
				var env = p.GetRequiredService<IHostEnvironment>();
				var options = EnvInfoOptions.InitializeDefaultOptions(env.EnvironmentName);

				envInfoSection.Bind(options);

				return options;
			});

			return services;
		}

	}
}
