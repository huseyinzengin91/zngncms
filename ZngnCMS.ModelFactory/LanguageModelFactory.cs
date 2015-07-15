using System;
using System.Collections.Generic;
using ZngnCMS.Business;
using ZngnCMS.Entities;
using ZngnCMS.Model.Language;
using System.Linq;

namespace ZngnCMS.ModelFactory
{
    public class LanguageModelFactory
    {
        
        public LanguageIndexModel LoadIndex(int page)
        {
            LanguageIndexModel languageIndexModel = new LanguageIndexModel();

            LanguageBusiness languageBusiness = new LanguageBusiness();

            List<Language> languageList = languageBusiness.LanguageList(page);

            languageIndexModel.LanguageList = (from z in languageList
                                               select new LanguageItemModel
                                               {
                                                   ID = z.ID,
                                                   Name = z.Name,
                                                   Code = z.Code,
                                                   Publish = z.Publish
                                               }).ToList();
                                                   

            return languageIndexModel;
        }

        public LanguageCreateModel LoadCreate()
        {
            LanguageCreateModel languageCreateModel = new LanguageCreateModel();

            return languageCreateModel;
        }

        public LanguageCreateModel Create(LanguageCreateModel request)
        {
            LanguageBusiness languageBusiness = new LanguageBusiness();

            try
            {
                Language language = languageBusiness.CreateLanguage(request.Name, request.Publish, request.Keyword, request.Code);


                request.Alerts.AlertList.Add("Dil başarıyla eklendi");
                request.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
            }
            catch (Exception ex)
            {
                request.Alerts.AlertList.Add("Dil eklenemedi [ " + ex.Message + " ]");
                request.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
            }

            return request;
        }
    }
}