using EnvInfo.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace EnvInfo.Mvc
{
	[HtmlTargetElement("bs-breakpoints", TagStructure = TagStructure.WithoutEndTag)]
	public class BootstrapBreakpointsTagHelper : BaseBreakpointsTagHelper
	{
		public BootstrapBreakpointsTagHelper(EnvInfoOptions options) : base(options)
		{
		}

		public string Breakpoints { get; set; }

		protected override string GetBreakpoints() => Breakpoints;
	}

	[HtmlTargetElement("bs4-breakpoints", TagStructure = TagStructure.WithoutEndTag)]
	public class Bootstrap4BreakpointsTagHelper : BaseBreakpointsTagHelper
	{
		private const string breakpoints = "xs sm md lg xl";

		public Bootstrap4BreakpointsTagHelper(EnvInfoOptions options) : base(options)
		{
		}

		protected override string GetBreakpoints() => breakpoints;
	}

	[HtmlTargetElement("bs5-breakpoints", TagStructure = TagStructure.WithoutEndTag)]
	public class Bootstrap5BreakpointsTagHelper : BaseBreakpointsTagHelper
	{
		private const string breakpoints = "xs sm md lg xl xxl";

		public Bootstrap5BreakpointsTagHelper(EnvInfoOptions options) : base(options)
		{
		}

		protected override string GetBreakpoints() => breakpoints;
	}

	public abstract class BaseBreakpointsTagHelper : TagHelper
	{
		private static readonly char[] separators = [' ', ',', ';'];
		protected readonly EnvInfoOptions options;

		public BaseBreakpointsTagHelper(EnvInfoOptions options)
		{
			this.options = options;
		}

		protected abstract string GetBreakpoints();

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (options.Visible)
			{
				output.TagName = "div";
				output.TagMode = TagMode.StartTagAndEndTag;
				output.Attributes.SetAttribute("class", "env-info-bs-breakpoints");

				var bs = GetBreakpoints().Split(separators, StringSplitOptions.RemoveEmptyEntries);

				output.Content.AppendHtml($"<div class=\"d-{bs[1]}-none\">{bs[0]}</div>");
				for (int i = 1; i < bs.Length - 1; i++)
				{
					output.Content.AppendHtml($"<div class=\"d-none d-{bs[i]}-block d-{bs[i + 1]}-none\">{bs[i]}</div>");
				}
				output.Content.AppendHtml($"<div class=\"d-none d-{bs[^1]}-block\">{bs[^1]}</div>");
			}
			else
			{
				output.SuppressOutput();
			}
		}
	}
}