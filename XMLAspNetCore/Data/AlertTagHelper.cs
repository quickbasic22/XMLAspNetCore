﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Identity.Client;

namespace XMLAspNetCore.Data
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper : TagHelper
    {
        #region Properties
        // Possible Bootstrap classes: primary, secondary, 
        // success, danger, warning, info, light, dark.
        public string AlertType { get; set; } = "success";
        #endregion
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }
            // Fetch existing content between the start and end tags
            var content = output.GetChildContentAsync()
                            .Result
                            .GetContent();
            // Don't render the <alert> Tag Helper
            if (content.Trim().Equals(string.Empty)) return;

            // Create the close button inside the alert
            var close = $"<button type='button' class='close' " +
                $"data-dismiss='alert' aria-label='Close'>" +
                $"<span aria-hidden='true'>$times;</span></button>";
            var html = $"{content}{close}";
            // Create the <div> and add necessary attributes and HTML
            output.TagName = "div";
            output.Attributes.Add("class", $"alert alert-{AlertType} alert-dismissible fade show");
            output.Attributes.Add("role", "alert");
            output.Attributes.Add("style", "border-radius: 0;margin-bottom: 0;");
            output.Content.SetHtmlContent(html);
            output.Content.AppendHtml("</div>");

            // Create the alert <div> element
            base.Process(context, output);
        }
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            base.ProcessAsync(context, output);
            return Task.CompletedTask;
        }
    }
}
