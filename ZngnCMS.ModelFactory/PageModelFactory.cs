using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ZngnCMS.Business;
using ZngnCMS.Entities;
using ZngnCMS.Model.Page;
using System.Linq;

namespace ZngnCMS.ModelFactory
{
    public class PageModelFactory
    {
        public PageCreateModel LoadCreate()
        {
            PageCreateModel pageCreateModel = new PageCreateModel();
            LanguageBusiness languageBusiness = new LanguageBusiness();

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            pageCreateModel.LanguageList = new SelectList(languageList, "ID", "Name");

            return pageCreateModel;
        }

        public PageCreateModel PageCreate(PageCreateModel request)
        {
            PageCreateModel pageCreateModel = new PageCreateModel();

            LanguageBusiness languageBusiness = new LanguageBusiness();
            PageBusiness pageBusiness = new PageBusiness();

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            pageCreateModel.LanguageList = new SelectList(languageList, "ID", "Name", request.LanguageID);


            bool existLanguage = languageBusiness.ExistLanguage(request.LanguageID);
            
            if (!existLanguage)
            {
                pageCreateModel.Alerts.AlertList.Add("Dil bulunamadı!");
                pageCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;

                return pageCreateModel;
            }
            else
            {
                bool existSeoName = pageBusiness.ExistSeoName(request.SeoName);

                if (existSeoName)
                {
                    pageCreateModel.Alerts.AlertList.Add("Seo adı daha önce kullanılmış!");
                    pageCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;

                    return pageCreateModel;
                }
                else
                {
                    try
                    {
                        PageTranslation pageTranslation = pageBusiness.CreatePageTranslation(request.LanguageID, request.Name, request.SeoName, request.SeoKeyword, request.SeoDescription, request.Text, request.Picture);

                        pageCreateModel.Alerts.AlertList.Add("Sayfa başarıyla eklendi");
                        pageCreateModel.RedirectURL = "/Management/Page/Index";
                        pageCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
                    }
                    catch (Exception ex)
                    {
                        pageCreateModel.Alerts.AlertList.Add("Sayfa kaydedilemedi [ " + ex.Message + " ]");
                        pageCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                    }
                }
            }

            return pageCreateModel;
        }

        public PageIndexModel LoadIndex(int page)
        {
            PageIndexModel pageIndexModel = new PageIndexModel();

            PageBusiness pageBusiness = new PageBusiness();
            
            List<Page> pageList = pageBusiness.PageList(page);

            pageIndexModel.PageList = (from z in pageList
                                               select new PageItemModel
                                               {
                                                   ID = z.ID,
                                                   Name = z.PageTranslation.FirstOrDefault().Name
                                               }).ToList();


            return pageIndexModel;
        }

        public PageEditModel LoadEdit(long pageID, long? languageID)
        {
            PageBusiness pageBusiness = new PageBusiness();
            LanguageBusiness languageBusiness = new LanguageBusiness();

            PageEditModel pageEditModel = new PageEditModel();

            Page page = pageBusiness.GetPage(pageID);
            PageTranslation pageTranslation = null;

            if (languageID.HasValue)
            {
                pageTranslation = page.PageTranslation.FirstOrDefault(z => z.LanguageID == languageID);
            }
            else
            {
                pageTranslation = page.PageTranslation.FirstOrDefault();
            }

            if (pageTranslation == null)
                pageTranslation = new PageTranslation();

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            pageEditModel.LanguageList = new SelectList(languageList, "ID", "Name", languageID);
            pageEditModel.LanguageID = pageTranslation.LanguageID;
            pageEditModel.Name = pageTranslation.Name;
            pageEditModel.PageID = page.ID;
            pageEditModel.Picture = pageTranslation.Picture;
            pageEditModel.SeoDescription = pageTranslation.SeoDescription;
            pageEditModel.SeoKeyword = pageTranslation.SeoKeyword;
            pageEditModel.SeoName = pageTranslation.SeoName;
            pageEditModel.Text = pageTranslation.Text;

            return pageEditModel;

        }

        public PageEditModel EditPage(PageEditModel request)
        {
            PageEditModel pageEditModel = new PageEditModel();

            LanguageBusiness languageBusiness = new LanguageBusiness();
            PageBusiness pageBusiness = new PageBusiness();

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            pageEditModel.LanguageList = new SelectList(languageList, "ID", "Name", request.LanguageID);
            pageEditModel.PageID = request.PageID;

            bool existLanguage = languageBusiness.ExistLanguage(request.LanguageID);
            long? existPageTranslation = pageBusiness.ExistPageTranslationByPageIDAndLanguageID(request.PageID, request.LanguageID);

            if (!existLanguage)
            {
                pageEditModel.Alerts.AlertList.Add("Dil bulunamadı!");
                pageEditModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;

                return request;
            }
            else
            {
                bool existSeoName = pageBusiness.ExistSeoName(request.SeoName,request.PageID);

                if (existSeoName)
                {
                    pageEditModel.Alerts.AlertList.Add("Seo adı daha önce kullanılmış!");
                    pageEditModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;

                    return pageEditModel;
                }
                else
                {
                    try
                    {
                        if (!existPageTranslation.HasValue)
                        {
                            PageTranslation pageTranslation = pageBusiness.CreatePageTranslation(request.LanguageID, request.PageID, request.Name, request.SeoName, request.SeoKeyword, request.SeoDescription, request.Text, request.Picture);


                            pageEditModel.Alerts.AlertList.Add("Sayfa başarıyla eklendi");
                            pageEditModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
                        }
                        else
                        {
                            PageTranslation pageTranslation = pageBusiness.UpdatePageTranslation(request.LanguageID, request.PageID, request.Name, request.SeoName, request.SeoKeyword, request.SeoDescription, request.Text, request.Picture);

                            pageEditModel.Alerts.AlertList.Add("Sayfa başarıyla güncellendi.");
                            pageEditModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
                        }

                    }
                    catch (Exception ex)
                    {
                        request.Alerts.AlertList.Add("Sayfa kaydedilemedi [ " + ex.Message + " ]");
                        request.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                    }
                }
            }


            
            return pageEditModel;
        }

        public PageDeleteModel DeletePage(long pageID)
        {
            PageBusiness pageBusiness = new PageBusiness();

            PageDeleteModel pageDeleteModel = new PageDeleteModel();

            bool existPage = pageBusiness.ExistPageByPageID(pageID);

            if (!existPage)
            {
                pageDeleteModel.Alerts.AlertList.Add("Sayfa bulunamadı.");
                pageDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
            }
            else
            {
                try
                {

                    pageBusiness.DeletePage(pageID);

                    pageDeleteModel.Alerts.AlertList.Add("Sayfa başarıyla silindi.");
                    pageDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;


                }
                catch (Exception ex)
                {
                    pageDeleteModel.Alerts.AlertList.Add("Sayfa silinemedi [ " + ex.Message + " ]");
                    pageDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                }
            }

            pageDeleteModel.RedirectURL = "/Management/Page/Index";

            return pageDeleteModel;
        }
    }
}