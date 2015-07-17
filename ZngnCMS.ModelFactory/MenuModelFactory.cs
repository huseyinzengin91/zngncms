namespace ZngnCMS.ModelFactory
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ZngnCMS.Business;
    using ZngnCMS.Entities;
    using ZngnCMS.Model.Common;
    using ZngnCMS.Model.Menu;
    #endregion

    public class MenuModelFactory
    {
        public MenuIndexModel LoadIndex(long? languageID)
        {
            MenuBusiness menuBusiness = new MenuBusiness();
            LanguageBusiness languageBusiness = new LanguageBusiness();

            MenuIndexModel menuIndexModel = new MenuIndexModel();

            long defaultLanguageID = languageBusiness.GetFirstLanguage();

            if (!languageID.HasValue)
            {
                languageID = defaultLanguageID;
            }

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            menuIndexModel.LanguageList = new SelectList(languageList, "ID", "Name", languageID);

            List<Menu> menu = menuBusiness.GetMenuList();

            List<MenuItemModel> menuItemList = new List<MenuItemModel>();

            foreach (Menu item in menu)
            {
                MenuItemModel tmpItem = new MenuItemModel();

                tmpItem.ID = item.ID;
                tmpItem.TopMenu = item.TopMenu;

                List<MenuTranslation> _menuTranslation = item.MenuTranslation.ToList();

                if (_menuTranslation != null && _menuTranslation.Count > 0)
                {
                    MenuTranslation menuTranslation = _menuTranslation.FirstOrDefault(z => z.LanguageID == languageID);

                    if (menuTranslation != null)
                    {
                        tmpItem.LanguageID = menuTranslation.LanguageID;
                        tmpItem.Name = menuTranslation.Name;
                        tmpItem.Sort = menuTranslation.Sort;
                        tmpItem.URL = menuTranslation.URL;
                    }
                    else
                    {
                        MenuTranslation defaultMenuTranslation = _menuTranslation.FirstOrDefault(z => z.LanguageID == defaultLanguageID);

                        tmpItem.LanguageID = defaultMenuTranslation.LanguageID;
                        tmpItem.Name = string.Format("Çeviri eklenmemiş , ({0})", defaultMenuTranslation.Name);
                        tmpItem.Sort = defaultMenuTranslation.Sort;
                        tmpItem.URL = defaultMenuTranslation.URL;
                    }
                }

                menuItemList.Add(tmpItem);
            }

            menuIndexModel.MenuList = menuItemList;

            return menuIndexModel;
        }

        public MenuCreateModel LoadCreate(long? languageID)
        {
            LanguageBusiness languageBusiness = new LanguageBusiness();

            MenuCreateModel menuCreateModel = new MenuCreateModel();
            MenuBusiness menuBusiness = new MenuBusiness();

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            long defaultLanguageID = languageBusiness.GetFirstLanguage();

            if (!languageID.HasValue)
            {
                languageID = defaultLanguageID;
            }

            menuCreateModel.LanguageList = new SelectList(languageList, "ID", "Name");

            List<SelectListItemModel> menuList = new List<SelectListItemModel>();

            menuList.Add(new SelectListItemModel
            {
                Text = "Ana menü",
                Value = null
            });

            menuList.AddRange(menuBusiness.MenuSelectListByLanguageID(languageID.Value));

            menuCreateModel.MenuList = new SelectList(menuList, "Value", "Text");

            return menuCreateModel;
        }

        public MenuCreateModel CreateMenu(MenuCreateModel request)
        {
            LanguageBusiness languageBusiness = new LanguageBusiness();
            MenuBusiness menuBusiness = new MenuBusiness();

            MenuCreateModel menuCreateModel = new MenuCreateModel();
            
            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            menuCreateModel.LanguageList = new SelectList(languageList, "ID", "Name", request.LanguageID);


            if (string.IsNullOrEmpty(request.Name))
            {
                menuCreateModel.Alerts.AlertList.Add("Menü adı boş bırakılamaz.");
                menuCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
            }
            else
            {
                if (string.IsNullOrEmpty(request.URL))
                {
                    menuCreateModel.Alerts.AlertList.Add("Menü URL boş bırakılamaz.");
                    menuCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                }
                else
                {
                    try
                    {
                        MenuTranslation menuTranslation = menuBusiness.CreateMenuTranslation(request.LanguageID, request.Name, request.URL, request.Sort, request.TopMenu);

                        menuCreateModel.Alerts.AlertList.Add("Menü başarıyla eklendi");
                        menuCreateModel.RedirectURL = "/Management/Menu/Index";
                        menuCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
                    }
                    catch (Exception ex)
                    {
                        menuCreateModel.Alerts.AlertList.Add("Menü kaydedilemedi [ " + ex.Message + " ]");
                        menuCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                    }
                }
            }

            return menuCreateModel;
        }

        public MenuDeleteModel DeleteMenu(long menuID)
        {
            MenuBusiness menuBusiness = new MenuBusiness();

            MenuDeleteModel menuDeleteModel = new MenuDeleteModel();

            try
            {
                menuBusiness.DeleteMenu(menuID);

                menuDeleteModel.Alerts.AlertList.Add("Menü başarıyla silindi.");
                menuDeleteModel.RedirectURL = "/Management/Menu/Index";
                menuDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
            }
            catch (Exception ex)
            {
                menuDeleteModel.RedirectURL = "/Management/Menu/Index";
                menuDeleteModel.Alerts.AlertList.Add("Menü silinemedi [ " + ex.Message + " ]");
                menuDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
            }

            return menuDeleteModel;
        }
    }
}