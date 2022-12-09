using EnvInfo.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel;
using System.Reflection;

namespace EnvInfo.Mvc.TagHelpers
{
	//public class EnvInfoTagHelper : TagHelper
	//{
	//	public override void Process(TagHelperContext context, TagHelperOutput output)
	//	{
	//		output.TagName = "div";
	//		output.TagMode = TagMode.StartTagAndEndTag;
	//		output.Attributes.Add("class", "env-info");
	//	}
	//}

	[HtmlTargetElement("body")]
	//[EditorBrowsable(EditorBrowsableState.Never)]
	public class EnvInfoTagHelperComponent : TagHelperComponent
	{
		private readonly EnvInfoOptions options;

		public EnvInfoTagHelperComponent(EnvInfoOptions options)
		{
			this.options = options;
		}

		public override int Order => 2;

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (string.Equals(context.TagName, "body", StringComparison.OrdinalIgnoreCase))
			{
				if (options.Visible)
				{
					output.PostContent.AppendHtml("<div class=\"env-info\">");
					output.PostContent.AppendHtml("<div class=\"env-info-name\">" + options.Name + "</div>");
					output.PostContent.AppendHtml("</div>");

					using var stream = typeof(EnvInfoOptions).GetTypeInfo().Assembly.GetManifestResourceStream("EnvInfo.Core.Styles.env-info-default.css");
					if (stream != null)
					{
						using var reader = new StreamReader(stream);

						output.PostContent.AppendHtml("<style>");
						output.PostContent.AppendHtml(await reader.ReadToEndAsync());
						output.PostContent.AppendHtml("</style>");
					}
				}
				//else
				//{
				//	output.su
				//}
			}
		}
	}
}
