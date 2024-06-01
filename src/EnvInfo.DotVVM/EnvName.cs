using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using EnvInfo.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EnvInfo.DotVVM
{
	public class EnvName : CompositeControl
	{
		public static DotvvmControl GetContents(IDotvvmRequestContext context)
		{
			var options = context.Services.GetRequiredService<EnvInfoOptions>();

			if (options.Visible)
			{
				return new HtmlGenericControl("div")
					.AddCssClass("env-info-name")
					.SetProperty(p => p.InnerText, options.Name);
			}

			else
			{
				return new HtmlGenericControl(null);
			}
		}
	}
}
