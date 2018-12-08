using Generic.WebUI.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace Generic.WebUI.HtmlHelpers
{
    //ders 6-7 PagingHelpers.
    public static class PagingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo)
        {
            //<a href="">1</a>
            int totalPage = (int)Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);
            var stringBuilder = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {
                var tagBuilder = new TagBuilder("a");   //a'Tag'ini oluşturur.
                tagBuilder.MergeAttribute("href", String.Format("/Order/Index/?Page={0}",i));
                tagBuilder.InnerHtml = i.ToString();
                if (pagingInfo.CurrentPage==i)
                {
                    tagBuilder.AddCssClass("selected");
                }
                stringBuilder.Append(tagBuilder);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}