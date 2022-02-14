using MComponents.Tabs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MComponents.Markdown
{
    public class MarkdownEditor : ComponentBase
    {
        private EditContext mEditContext = new EditContext(string.Empty);

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public Expression<Func<string>> ValueExpression { get; set; }

        [Inject]
        public IStringLocalizer L { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            RenderFragment content = (builder3) =>
            {
                builder3.OpenComponent<MTab>(71);
                builder3.AddAttribute(72, nameof(MTab.Title), L["Code"]);

                RenderFragment cc1 = (bb) =>
                {
                    RenderFragment child = (__builder32) =>
                    {
                        __builder32.AddMarkupContent(8, "\r\n\t\t\t");
                        __builder32.OpenComponent<InputTextArea>(9);
                        __builder32.AddAttribute(10, "style", "width: 100%; height: 30vh;");
                        __builder32.AddAttribute(11, "Value", Value);
                        __builder32.AddAttribute(12, "ValueChanged", ValueChanged);
                        __builder32.AddAttribute(13, "ValueExpression", ValueExpression);
                        __builder32.CloseComponent();
                    };

                    bb.OpenComponent<CascadingValue<EditContext>>(77);
                    bb.AddAttribute(78, nameof(CascadingValue<EditContext>.Value), mEditContext);
                    bb.AddAttribute(78, nameof(CascadingValue<EditContext>.ChildContent), child);
                    bb.CloseComponent(); //cascading value
                };

                builder3.AddAttribute(72, nameof(MTab.ChildContent), cc1);
                builder3.CloseComponent(); //mtab


                builder3.OpenComponent<MTab>(100);
                builder3.AddAttribute(72, nameof(MTab.Title), L["Preview"]);

                RenderFragment cc2 = (bb) =>
                {
                    bb.OpenComponent<MarkdownText>(20);
                    bb.AddAttribute(21, "Text", Value);
                    bb.CloseComponent();  //Markdown
                };

                builder3.AddAttribute(72, nameof(MTab.ChildContent), cc2);
                builder3.CloseComponent(); //mtab
            };

            builder.OpenComponent<MTabs>(70);
            builder.AddAttribute(114, nameof(MTabs.ChildContent), content);
            builder.CloseComponent(); //mtabs

            /*
            builder.OpenElement(25, "button");
            builder.AddAttribute(26, "class", "m-btn m-btn-primary");
            builder.AddAttribute(27, "type", "button");
            builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, OnSaveClick));
            builder.AddContent(29, L["Save"]);
            builder.CloseElement();
            */
        }
    }
}
