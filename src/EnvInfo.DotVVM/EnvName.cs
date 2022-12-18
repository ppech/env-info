using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using EnvInfo.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvInfo.DotVVM
{
	public class EnvName : CompositeControl
	{
		public DotvvmControl GetContents(IDotvvmRequestContext context)
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

		protected override void OnPreRender(IDotvvmRequestContext context)
		{
			context.ResourceManager.AddRequiredResource(EnvInfoConsts.StyleResourceName);

			base.OnPreRender(context);
		}
	}
}
