using System;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace EnvInfo.Core
{
	public class EnvInfoOptions
	{
		public string Name { get; set; } = string.Empty;
		public bool Visible { get; set; }

		public static EnvInfoOptions CreateDefaultSettings(IHostEnvironment env)
		{
			return new EnvInfoOptions()
			{
				Name = GetName(),
				Visible = env.IsDevelopment()
			};


			string GetName()
			{
				if (env.IsDevelopment())
					return "DEV";
				if (env.IsStaging())
					return "STAG";
				if (env.IsProduction())
					return "PROD";

				return env.EnvironmentName;
			}
		}
	}
}