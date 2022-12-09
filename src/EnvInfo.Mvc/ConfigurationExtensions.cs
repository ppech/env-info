using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvInfo.Mvc.TagHelpers
{
	public static class ConfigurationExtensions
	{
		public static IMvcBuilder AddEnvInfoTagHelpers(this IMvcBuilder builder)
		{
			builder.Services.AddTransient<ITagHelperComponent, EnvInfoTagHelperComponent>();

			return builder;
		}
	}
}
