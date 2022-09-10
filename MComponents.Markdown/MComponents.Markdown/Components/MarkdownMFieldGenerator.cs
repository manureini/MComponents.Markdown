using Markdig;
using MComponents.MForm;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComponents.Markdown
{
    public class MarkdownMFieldGenerator : MFieldGenerator
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Label { get; set; }

        protected MarkupString mHtml;

        protected string mOldText;

        public MarkdownMFieldGenerator()
        {
            mHtml = MarkdownHelper.RenderMarkdown(Text);

            Template = (context) => (builder) =>
            {
                if (Label != null)
                {
                    builder.OpenElement(30, "label");
                    builder.AddAttribute(31, "class", "col-sm-12 col-form-label");
                    builder.AddContent(32, Label);
                    builder.CloseElement();
                }

                builder.OpenElement(50, "div");
                builder.AddAttribute(51, "class", "m-markdown-container");
                builder.AddContent(52, mHtml);
                builder.CloseElement();
            };
        }

        protected override void OnParametersSet()
        {
            if (mOldText != Text)
            {
                mOldText = Text;
                //not working in accre forms
                mHtml = MarkdownHelper.RenderMarkdown(Text);
                Form.InvokeStateHasChanged();
            }
        }
    }
}
