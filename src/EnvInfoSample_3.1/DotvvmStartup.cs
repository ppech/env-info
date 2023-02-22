﻿using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using EnvInfo.DotVVM;
using Microsoft.Extensions.DependencyInjection;

namespace EnvInfoSample
{
	public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
	{
		// For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
		public void Configure(DotvvmConfiguration config, string applicationPath)
		{
			config.AddEnvInfoConfiguration();

			ConfigureRoutes(config, applicationPath);
			ConfigureControls(config, applicationPath);
			ConfigureResources(config, applicationPath);
		}

		private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
		{
			config.RouteTable.Add("Default", "dotvvm", "Pages/Default.dothtml");
		}

		private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
		{
			// register code-only controls and markup controls
		}

		private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
		{
			// register custom resources and adjust paths to the built-in resources
			config.Resources.Register("Styles", new StylesheetResource()
			{
				Location = new UrlResourceLocation("~/Resources/style.css")
			});
		}

		public void ConfigureServices(IDotvvmServiceCollection options)
		{
			options.AddDefaultTempStorages("temp");
			options.AddHotReload();
		}
	}
}
