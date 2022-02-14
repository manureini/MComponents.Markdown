using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace MComponents.Markdown
{
    public class MarkdownText : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }

        protected MarkupString mHtml;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "m-markdown-container");
            builder.AddContent(2, mHtml);
            builder.CloseElement();
        }

        protected override void OnParametersSet()
        {
            if (Text == null)
                return;

            mHtml = MarkdownHelper.RenderMarkdown(Text);
        }
    }
}
