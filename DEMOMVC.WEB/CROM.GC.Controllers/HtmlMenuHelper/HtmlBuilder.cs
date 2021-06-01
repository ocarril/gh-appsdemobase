
using CROM.GC.Controllers.HtmlMenuHelper.Base;

using System;
using System.Demo.Tools.settings;
using System.Web.Mvc;

namespace CROM.GC.Controllers.HtmlMenuHelper
{
    public class HtmlBuilder : BaseHtmlTagEngine<MvcMenuItem>
    {
        public HtmlBuilder (HtmlHelper htmlHelper): base(htmlHelper)
        {
        }

        protected override void BuildTagContainer(MvcMenuItem itm, TagContainer parent)
        {
            TagContainer tc = FillTag(itm, parent);

            foreach (MvcMenuItem mii in itm.GetChildren())
            {
                BuildTagContainer(mii, tc);
            }
        }

        TagContainer FillTag(MvcMenuItem itm, TagContainer tc_parent)
        {
            TagContainer Li_Tc = new TagContainer(ref _CntNumber, tc_parent);
            Li_Tc.Name = itm.Text;
            Li_Tc.Tb = AddItem(itm);// li tag

            if (HasChildren(itm))
            {
                TagContainer Ul_container = new TagContainer(ref _CntNumber, Li_Tc);
                Ul_container.Name = "**";//
                Ul_container.Tb = Add_Ul_Tag();
                return Ul_container;
            }

            return Li_Tc;
        }

        TagBuilder Add_Ul_Tag()
        {
            TagBuilder Ul_Tag = new TagBuilder("ul");
            Ul_Tag.MergeAttribute("id", "menu1");
            Ul_Tag.AddCssClass("dropdown-menu");
            Ul_Tag.AddCssClass("MenuProps");
            return Ul_Tag;
        }

        string GenerateUrlForMenuItem(MvcMenuItem menuItem, string contentUrl)
        {
            var url = contentUrl + menuItem.Controller;
            if (!String.IsNullOrEmpty(menuItem.Action)) url += "/" + menuItem.Action;
            return url;
        }

        string GenerateContentUrlFromHttpContext(HtmlHelper htmlHelper)
        {
            string RetStr = UrlHelper.GenerateContentUrl("~/", htmlHelper.ViewContext.HttpContext);
            return RetStr;
        }

        TagBuilder AddItem(MvcMenuItem mi)
        {
            var Li_tag = new TagBuilder("li");
            var a_tag = new TagBuilder("a");
            var b_tag = new TagBuilder("b");
            var image_tag = new TagBuilder("img");

            if (mi.IconImage != null)
            {
                string pth = GlobalSettings.GetDEFAULT_URL_WEBAPP_Comercial() + "Content/Images/" + mi.IconImage;
                image_tag.MergeAttribute("src", pth);
                image_tag.AddCssClass("CoolImgMenu");
            }

            b_tag.AddCssClass("caret");

            var contentUrl = GenerateContentUrlFromHttpContext(_htmlHelper);

            string A_refStr = GenerateUrlForMenuItem(mi, contentUrl);

            a_tag.Attributes.Add("href", A_refStr);

            if (mi.MnuTyp == MenuType.Top)
            {
                Li_tag.AddCssClass("dropdown");
                a_tag.MergeAttribute("data-toggle", "dropdown");
                a_tag.AddCssClass("dropdown-toggle");
            }
            else
            {
                Li_tag.AddCssClass("dropdown-submenu");
                Li_tag.AddCssClass("CoolMenuLi");
            }

            a_tag.InnerHtml += image_tag.ToString();
            a_tag.InnerHtml += mi.Text;

            if (HasChildren(mi)) 
            {
                a_tag.InnerHtml += b_tag.ToString();
            }

            Li_tag.InnerHtml = a_tag.ToString();

            return Li_tag;
        }
    }
}
