using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using EnvInfo.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EnvInfo.DotVVM
{
	public class BootstrapBreakpoints : CompositeControl
	{
		private static readonly char[] separators = new char[] { ' ', ',', ';' };

		public static DotvvmControl GetContents(string breakpoints, IDotvvmRequestContext context)
		{
			return GetContentsInternal(breakpoints, context);
		}

		internal static DotvvmControl GetContentsInternal(
			string breakpoints,
			IDotvvmRequestContext context)
		{
			var options = context.Services.GetRequiredService<EnvInfoOptions>();

			if (options.Visible)
			{
				var c = new HtmlGenericControl("div")
					.AddCssClass("env-info-bs-breakpoints");

				var bs = breakpoints.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				var first = new HtmlGenericControl("div")
					.AddCssClass($"d-{bs[1]}-none")
					.SetProperty(p => p.InnerText, bs[0]);
				c.Children.Add(first);

				for (int i = 1; i < bs.Length - 1; i++)
				{
					var b = new HtmlGenericControl("div")
						.AddCssClass($"d-none d-{bs[i]}-block d-{bs[i + 1]}-none")
						.SetProperty(p => p.InnerText, bs[i]);
					c.Children.Add(b);
				}

				var last = new HtmlGenericControl("div")
					.AddCssClass($"d-none d-{bs[bs.Length - 1]}-block")
					.SetProperty(p => p.InnerText, bs[bs.Length - 1]);
				c.Children.Add(last);

				return c;
			}

			else
			{
				return new HtmlGenericControl(null);
			}
		}
	}

	public class Bootstrap4Breakpoints : CompositeControl
	{
		public static DotvvmControl GetContents(IDotvvmRequestContext context)
		{
			return BootstrapBreakpoints.GetContentsInternal("xs sm md lg xl", context);
		}
	}

	public class Bootstrap5Breakpoints : CompositeControl
	{
		public static DotvvmControl GetContents(IDotvvmRequestContext context)
		{
			return BootstrapBreakpoints.GetContentsInternal("xs sm md lg xl xxl", context);
		}
	}
}
