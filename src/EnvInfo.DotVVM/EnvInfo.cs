using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using EnvInfo.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EnvInfo.DotVVM
{
	public class EnvInfo : CompositeControl
	{
		public DotvvmControl GetContents(IDotvvmRequestContext context, TextOrContentCapability content)
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
								content.ToControls()
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
