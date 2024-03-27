using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagement.MyHelpers;

public static class MyHelpers
{
    public static IHtmlContent MyTextBox<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TValue>> expression, string labelText)
    {
        var label = $"<div><label>{ labelText }</label></div><div>";
        var input = htmlHelper.TextBoxFor(expression);

        var tbContainer = new TagBuilder("div");
        tbContainer.MergeAttribute("style", "margin-top: 20px");
        tbContainer.InnerHtml.AppendHtml(label);
        tbContainer.InnerHtml.AppendHtml(input);
        tbContainer.InnerHtml.AppendHtml("</div>");
        return tbContainer;
    }
    
    public static IHtmlContent MyTableLi(this IHtmlHelper htmlHelper, string text, object value)
    {
        var textTag = $"<b>{ text }: </b>";
        var valueTag = value?.ToString();

        var liContainer = new TagBuilder("li");
        liContainer.InnerHtml.AppendHtml(textTag);
        liContainer.InnerHtml.AppendHtml(valueTag ?? "");
        return liContainer;
    }

    public static IHtmlContent MyTableH3(this IHtmlHelper htmlHelper, object value)
    {
        var valueTag = value?.ToString();

        var liContainer = new TagBuilder("h3");
        liContainer.AddCssClass("text-light");
        liContainer.InnerHtml.AppendHtml(valueTag ?? "");
        return liContainer;
    }
}