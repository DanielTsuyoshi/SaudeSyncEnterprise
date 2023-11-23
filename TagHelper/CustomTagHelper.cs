using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SaudeSync.TagHelpers
{
    [HtmlTargetElement("custom-tag")]
    public class CustomTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Content.SetContent("Esta é a custom tag!");
        }
    }
}