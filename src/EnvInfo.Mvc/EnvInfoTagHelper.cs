using EnvInfo.Core;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel;
using System.Reflection;
using System.Text.Encodings.Web;

namespace EnvInfo.Mvc.TagHelpers
{
	public class EnvInfoTagHelper : TagHelper
	{
		private readonly EnvInfoOptions options;

		public EnvInfoTagHelper(EnvInfoOptions options)
		{
			this.options = options;
		}

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (options.Visible)
			{
				output.TagName = "div";
				output.Attributes.SetAttribute("class", "env-info");
				output.PreContent.AppendHtml("<div class=\"content\">");

				output.PostContent.AppendHtml("</div>");

				using var stream = typeof(EnvInfoOptions).GetTypeInfo().Assembly.GetManifestResourceStream("EnvInfo.Core.Styles.env-info-default.css");
				if (stream != null)
				{
					using var reader = new StreamReader(stream);

					output.PostElement.AppendHtml("<style>");
					output.PostElement.AppendHtml(await reader.ReadToEndAsync());
					output.PostElement.AppendHtml("</style>");
				}
			}
			else
			{
				output.SuppressOutput();
			}
		}
	}
}
