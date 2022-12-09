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
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddEnvInfo(this IServiceCollection services)
		{
			services.TryAddSingleton<EnvInfoOptions>(p =>
			{
				var configuration = p.GetRequiredService<IConfiguration>();
				var env = p.GetRequiredService<IHostEnvironment>();
				var options = EnvInfoOptions.CreateDefaultSettings(env);

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
