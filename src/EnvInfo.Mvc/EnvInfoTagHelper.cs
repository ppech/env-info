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

		public override int Order => 2;

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (options.Visible)
			{
				output.TagName = "div";
				output.AddClass("env-info", HtmlEncoder.Default);
				if (output.Content.IsEmptyOrWhiteSpace)
				{
					output.Content.AppendHtml("<div class=\"env-info\">");
					output.Content.AppendHtml("<div class=\"env-info-name\">" + options.Name + "</div>");
					output.Content.AppendHtml("</div>");
				}

				using var stream = typeof(EnvInfoOptions).GetTypeInfo().Assembly.GetManifestResourceStream("EnvInfo.Core.Styles.env-info-default.css");
				if (stream != null)
				{
					using var reader = new StreamReader(stream);

					output.PostContent.AppendHtml("<style>");
					output.PostContent.AppendHtml(await reader.ReadToEndAsync());
					output.PostContent.AppendHtml("</style>");
				}
			}
			else
			{
				output.SuppressOutput();
			}
		}
	}
}
