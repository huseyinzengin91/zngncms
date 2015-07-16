namespace ZngnCMS.Business
{
    #region Using

    using System;
    using System.Linq;
    using System.Transactions;
    using ZngnCMS.Entities;

    #endregion Using

    public class SiteSettingBusiness
    {
        private ModelContext context;

        public SiteSettingBusiness()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
        }

        public SiteSetting GetSiteSetting()
        {
            SiteSetting siteSetting = context.SiteSetting.FirstOrDefault();

            return siteSetting;
        }

        public SiteSettingTranslation GetSiteSettingTranslation(long siteSettingID, long languageID)
        {
            SiteSettingTranslation siteSettingTranslation = context.SiteSettingTranslation.FirstOrDefault(z => z.SiteSettingID == siteSettingID && z.LanguageID == languageID);

            return siteSettingTranslation;
        }

        public long? ExistSiteSettingTranslation(long siteSettingID, long languageID)
        {
            SiteSettingTranslation siteSettingTranslation = context.SiteSettingTranslation.FirstOrDefault(z => z.LanguageID == languageID && z.SiteSettingID == siteSettingID);

            long? siteSettingTranslationID = siteSettingTranslation != null ? siteSettingTranslation.ID : new Nullable<long>();

            return siteSettingTranslationID;
        }

        public SiteSettingTranslation CreateSiteSettingTranslation(long languageID, long siteSettingID, string title, string description, string keyword, string footerText)
        {
            DateTime date = DateTime.Now;

            SiteSettingTranslation siteSettingTranslation = new SiteSettingTranslation
            {
                Description = description,
                FooterText = footerText,
                Keyword = keyword,
                LanguageID = languageID,
                SiteSettingID = siteSettingID,
                Title = title,
                CreatedDate = date,
                UpdatedDate = date
            };

            context.SiteSettingTranslation.Add(siteSettingTranslation);

            SiteSetting siteSetting = this.GetSiteSetting();

            siteSetting.UpdatedDate = date;

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    context.SaveChanges();
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return siteSettingTranslation;
        }

        public SiteSettingTranslation UpdateSiteSettingTranslation(long languageID, long siteSettingID, string title, string description, string keyword, string footerText, string email, string emailPassword, string emailPort)
        {
            DateTime date = DateTime.Now;

            SiteSettingTranslation siteSettingTranslation = this.GetSiteSettingTranslation(siteSettingID, languageID);

            siteSettingTranslation.Description = description;
            siteSettingTranslation.FooterText = footerText;
            siteSettingTranslation.Keyword = keyword;
            siteSettingTranslation.LanguageID = languageID;
            siteSettingTranslation.SiteSettingID = siteSettingID;
            siteSettingTranslation.Title = title;
            siteSettingTranslation.UpdatedDate = date;

            SiteSetting siteSetting = this.GetSiteSetting();

            siteSetting.UpdatedDate = date;
            siteSetting.Email = email;
            siteSetting.EmailPassword = emailPassword;
            siteSetting.EmailPort = emailPort;

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    context.SaveChanges();
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return siteSettingTranslation;
        }
    }
}