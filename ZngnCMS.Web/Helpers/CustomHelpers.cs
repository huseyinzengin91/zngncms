using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ZngnCMS.Model.Base;
using ZngnCMS.Model.Menu;

namespace System.Web.Mvc
{
    public static class CustomHelpers
    {
        public static MvcHtmlString Alert(this HtmlHelper helper, Alerts alerts)
        {
            StringBuilder alertText = new StringBuilder();

            if (alerts != null && alerts.AlertList.Any())
            {
                alertText.Append("<div class=\"panel-body\">");

                string alertType = string.Empty;

                switch (alerts.AlertType)
                {
                    case Alerts.AlertTypes.Success:
                        alertType = "success";
                        break;
                    case Alerts.AlertTypes.Error:
                        alertType = "danger";
                        break;
                    case Alerts.AlertTypes.Info:
                        alertType = "info";
                        break;
                    default:
                        break;
                }

                foreach (string alert in alerts.AlertList)
                {
                    alertText.Append("<div class=\"alert alert-" + alertType + " alert-dismissable\">" +
                        "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>" +
                        "" + alert + "</div>");
                }

                alertText.Append("</div>");
            }

            return new MvcHtmlString(alertText.ToString());
        }

        public static MvcHtmlString TreeMenu(this HtmlHelper helper, List<MenuItemModel> menuList)
        {
            StringBuilder menuTemplate = new StringBuilder();

            List<MenuItemModel> mainMenu = menuList.Where(z => z.TopMenu == null).OrderBy(z => z.Sort).ToList();

            menuTemplate.Append("<ul>");

            foreach (MenuItemModel mainMenuItem in mainMenu)
            {
                string subMenuTemplate = AppendSubMenu(menuList, mainMenuItem.ID);
                menuTemplate.Append(string.Format("<li style=\"padding:5px\"><a href=\"{0}\" class=\"btn btn-info btn-sm\">{1}</a> <button class=\"btn btn-warning btn-xs\">{0}</button> <a href=\"{3}\" class=\"btn btn-primary btn-xs\" >Düzenle</a> <button onclick=\"setCurrentDataID({3});\" class=\"btn btn-danger btn-xs\" data-toggle=\"modal\" data-target=\"#myModal\" >Sil</button> {2}</li>", mainMenuItem.URL, mainMenuItem.Name, subMenuTemplate, mainMenuItem.ID));

            }

            menuTemplate.Append("</ul>");

            return new MvcHtmlString(menuTemplate.ToString());
        }

        private static string AppendSubMenu(List<MenuItemModel> menuList, long queueID)
        {
            List<MenuItemModel> subMenuList = menuList.Where(z => z.TopMenu == queueID).OrderBy(z => z.Sort).ToList();

            StringBuilder subMenuTemplate = new StringBuilder();

            if (subMenuList != null && subMenuList.Any())
            {
                subMenuTemplate.Append("<ul>");

                foreach (MenuItemModel subMenuItem in subMenuList)
                {
                    string _subMenuTemplate = AppendSubMenu(menuList, subMenuItem.ID);
                    subMenuTemplate.Append(string.Format("<li style=\"padding:5px\"><a href=\"{0}\" class=\"btn btn-info btn-sm\" >{1}</a> <button class=\"btn btn-warning btn-xs\">{0}</button> <a href=\"{3}\" class=\"btn btn-primary btn-xs\" >Düzenle</a> <button onclick=\"setCurrentDataID({3});\" class=\"btn btn-danger btn-xs\" data-toggle=\"modal\" data-target=\"#myModal\" >Sil</button> {2}</li>", subMenuItem.URL, subMenuItem.Name, _subMenuTemplate, subMenuItem.ID));

                }

                subMenuTemplate.Append("</ul>");
            }

            return subMenuTemplate.ToString();
        }
    }
}