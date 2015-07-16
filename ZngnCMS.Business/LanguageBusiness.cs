namespace ZngnCMS.Business
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ZngnCMS.Constants;
    using ZngnCMS.Entities;

    #endregion Using

    public class LanguageBusiness
    {
        private ModelContext context;

        public LanguageBusiness()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
        }

        public Language CreateLanguage(string name, bool publish, string keyword, string code)
        {
            Language language = new Language
            {
                Name = name,
                Publish = publish,
                Keyword = keyword,
                Code = code,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            context.Language.Add(language);
            context.SaveChanges();

            return language;
        }

        public List<Language> LanguageList(int page)
        {
            List<Language> languageList = context.Language.OrderByDescending(z => z.ID).Skip(CommonConstans.PageCount * (page - 1)).Take(CommonConstans.PageCount).ToList();

            return languageList;
        }

        public IEnumerable<Language> LanguageList()
        {
            IEnumerable<Language> languageList = context.Language;

            return languageList;
        }

        public bool ExistLanguage(long languageID)
        {
            bool existLanguage = context.Language.Any(z => z.ID == languageID);

            return existLanguage;
        }
    }
}