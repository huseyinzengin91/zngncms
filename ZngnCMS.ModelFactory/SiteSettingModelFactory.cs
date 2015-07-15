using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZngnCMS.Business;
using ZngnCMS.Entities;
using ZngnCMS.Model.SiteSetting;

namespace ZngnCMS.ModelFactory
{
    public class SiteSettingModelFactory
    {
        public SiteSettingIndexModel LoadIndex(long? languageID)
        {
            SiteSettingBusiness siteSettingBusiness = new SiteSettingBusiness();
            LanguageBusiness languageBusiness = new LanguageBusiness();

            SiteSettingIndexModel siteSettingIndexModel = new SiteSettingIndexModel();

            SiteSetting siteSetting = siteSettingBusiness.GetSiteSetting();
            SiteSettingTranslation siteSettingTranslation = null;

            if (languageID.HasValue)
            {
                siteSettingTranslation = siteSetting.SiteSettingTranslation.FirstOrDefault(z => z.LanguageID == languageID);
            }
            else
            {
                siteSettingTranslation = siteSetting.SiteSettingTranslation.FirstOrDefault();
            }

            if (siteSettingTranslation == null)
                siteSettingTranslation = new SiteSettingTranslation();
            
            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            siteSettingIndexModel.LanguageList = new SelectList(languageList, "ID", "Name", languageID);
            siteSettingIndexModel.LanguageID = siteSettingTranslation.LanguageID;
            siteSettingIndexModel.Title = siteSettingTranslation.Title;
            siteSettingIndexModel.Description = siteSettingTranslation.Description;
            siteSettingIndexModel.Keyword = siteSettingTranslation.Keyword;
            siteSettingIndexModel.FooterText = siteSettingTranslation.FooterText;
            siteSettingIndexModel.Email = siteSetting.Email;
            siteSettingIndexModel.EmailPassword = siteSetting.EmailPassword;
            siteSettingIndexModel.EmailPort = siteSetting.EmailPort;
            siteSettingIndexModel.SiteSettingID = siteSetting.ID;

            return siteSettingIndexModel;
        }

        public SiteSettingIndexModel CreateOrUpdate(SiteSettingIndexModel request)
        {
            LanguageBusiness languageBusiness = new LanguageBusiness();
            SiteSettingBusiness siteSettingBusiness = new SiteSettingBusiness();

            bool existLanguage = languageBusiness.ExistLanguage(request.LanguageID);
            long? existSiteSettingTranslation = siteSettingBusiness.ExistSiteSettingTranslation(request.SiteSettingID, request.LanguageID);

            if (!existLanguage)
            {
                request.Alerts.AlertList.Add("Dil bulunamadı!");
                request.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;

                return request;
            }
            else
            {
                try
                {
                    if (!existSiteSettingTranslation.HasValue)
                    {
                        SiteSettingTranslation siteSettingTranslation = siteSettingBusiness.CreateSiteSettingTranslation(request.LanguageID, request.SiteSettingID, request.Title, request.Description, request.Keyword, request.FooterText);


                        request.Alerts.AlertList.Add("Site ayarları başarıyla eklendi");
                        request.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
                    }
                    else
                    {
                        SiteSettingTranslation siteSettingTranslation = siteSettingBusiness.UpdateSiteSettingTranslation(request.LanguageID, request.SiteSettingID, request.Title, request.Description, request.Keyword, request.FooterText,request.Email, request.EmailPassword,request.EmailPort);


                        request.Alerts.AlertList.Add("Site ayarları başarıyla güncellendi.");
                        request.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
                    }

                }
                catch (Exception ex)
                {
                    request.Alerts.AlertList.Add("Site ayarları kaydedilemedi [ " + ex.Message + " ]");
                    request.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                }
            }


            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            request.LanguageList = new SelectList(languageList, "ID", "Name", request.LanguageID);

            return request;
        }
    }
}
