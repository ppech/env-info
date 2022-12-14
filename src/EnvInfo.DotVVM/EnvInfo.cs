using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using EnvInfo.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EnvInfo.DotVVM
{

	public class EnvInfo : CompositeControl
	{
		public DotvvmControl GetContents(IDotvvmRequestContext context, ITemplate? content = null)
		{
			var options = context.Services.GetRequiredService<EnvInfoOptions>();

			if (options.Visible)
			{
				var control = new HtmlGenericControl("div")
					.AddCssClass("env-info");

				if (content != null)
				{
					control.AppendChildren(
						new HtmlGenericControl("div")
							.AddCssClass("content")
							.AppendChildren(
								new TemplateHost(content)
					));
				}

				return control;
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
