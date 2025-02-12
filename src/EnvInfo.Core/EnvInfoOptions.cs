using System;

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
		/// Initializes the default options for the EnvInfo service.
		/// </summary>
		/// <param name="environmentName">The name of the environment.</param>
		/// <returns>The default EnvInfo options.</returns>
		public static EnvInfoOptions InitializeDefaultOptions(string environmentName)
		{
			return new EnvInfoOptions()
			{
				Name = GetName(),
				Visible = "Development".Equals(environmentName, StringComparison.OrdinalIgnoreCase)
			};

			string GetName()
			{
				if ("Development".Equals(environmentName, StringComparison.OrdinalIgnoreCase))
					return "DEV";
				if ("Staging".Equals(environmentName, StringComparison.OrdinalIgnoreCase))
					return "STAG";
				if ("Production".Equals(environmentName, StringComparison.OrdinalIgnoreCase))
					return "PROD";

				return environmentName;
			}
		}
	}
}