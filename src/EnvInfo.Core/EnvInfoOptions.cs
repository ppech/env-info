using System;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace EnvInfo.Core
{
	/// <summary>
	/// Represents the options for the EnvInfo service.
	/// </summary>
	public class EnvInfoOptions
	{
		/// <summary>
		/// Gets or sets the name of the environment.
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a value indicating whether the EnvInfo is visible.
		/// </summary>
		public bool Visible { get; set; }

		/// <summary>
		/// Creates the default settings for the EnvInfo service based on the provided host environment.
		/// </summary>
		/// <param name="env">The host environment.</param>
		/// <returns>The default EnvInfo options.</returns>
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