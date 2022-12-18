using EnvInfo.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvInfo.Mvc
{
	[HtmlTargetElement("env-name", TagStructure = TagStructure.WithoutEndTag)]
	public class EnvNameTagHelper : TagHelper
	{
		private readonly EnvInfoOptions options;

		public EnvNameTagHelper(EnvInfoOptions options)
		{
			this.options = options;
		}

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (options.Visible)
			{
				output.TagName = "div";
				output.TagMode = TagMode.StartTagAndEndTag;
				output.Attributes.SetAttribute("class", "env-info-name");
				output.Content.Append(options.Name);
			}
			else
			{
				output.SuppressOutput();
			}
		}
	}
}
