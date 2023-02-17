using EnvInfo.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
			services.TryAddSingleton<EnvInfoOptions>(p =>
			{
				var configuration = p.GetRequiredService<IConfiguration>();
				var env = p.GetRequiredService<IHostEnvironment>();
				options ??= EnvInfoOptions.CreateDefaultSettings(env);

				var envInfoSection = configuration.GetSection("EnvInfo");
				if (envInfoSection != null)
				{
					envInfoSection.Bind(options);
				}

				return options;
			});

			return services;
		}

        /// <summary>
        /// Adds EnvInfo services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
		/// <param name="name">Default name</param>
        public static IServiceCollection AddEnvInfo(this IServiceCollection services, string name)
		{
            services.TryAddSingleton<EnvInfoOptions>(p =>
            {
                var configuration = p.GetRequiredService<IConfiguration>();
                var env = p.GetRequiredService<IHostEnvironment>();
                var options = EnvInfoOptions.CreateDefaultSettings(env);
                options.Name = name;

                var envInfoSection = configuration.GetSection("EnvInfo");
                if (envInfoSection != null)
                {
                    envInfoSection.Bind(options);
                }

                return options;
            });

            return services;
        }

    }
}
