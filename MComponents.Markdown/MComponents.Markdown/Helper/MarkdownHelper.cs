using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComponents.Markdown
{
    public class MarkdownHelper
    {
        public static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
              .UseEmojiAndSmiley()
              .UseAdvancedExtensions()
              .UsePipeTables()
              .Build();

        public static MarkupString RenderMarkdown(string pMarkdownStr)
        {
            if (string.IsNullOrWhiteSpace(pMarkdownStr))
                return new MarkupString(string.Empty);

            return new MarkupString(Markdig.Markdown.ToHtml(pMarkdownStr, Pipeline));
        }
    }
}
