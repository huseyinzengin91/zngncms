namespace ZngnCMS.Business
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    using ZngnCMS.Constants;
    using ZngnCMS.Entities;

    #endregion Using

    public class PageBusiness
    {
        private ModelContext context;

        public PageBusiness()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
        }

        public PageTranslation CreatePageTranslation(long languageID, string name, string seoName, string seoKeyword, string seoDescription, string text, string picture)
        {
            DateTime date = DateTime.Now;

            Page page = new Page
            {
                CreatedDate = date,
                UpdatedDate = date
            };

            context.Page.Add(page);

            PageTranslation pageTranslation = new PageTranslation
            {
                LanguageID = languageID,
                Name = name,
                PageID = page.ID,
                Picture = picture,
                SeoDescription = seoDescription,
                SeoKeyword = seoKeyword,
                SeoName = seoName,
                Text = text,
                CreatedDate = date,
                UpdatedDate = date
            };

            context.PageTranslation.Add(pageTranslation);

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

            return pageTranslation;
        }

        public PageTranslation CreatePageTranslation(long languageID, long pageID, string name, string seoName, string seoKeyword, string seoDescription, string text, string picture)
        {
            DateTime date = DateTime.Now;

            PageTranslation pageTranslation = new PageTranslation
            {
                LanguageID = languageID,
                Name = name,
                PageID = pageID,
                Picture = picture,
                SeoDescription = seoDescription,
                SeoKeyword = seoKeyword,
                SeoName = seoName,
                Text = text,
                CreatedDate = date,
                UpdatedDate = date
            };

            context.PageTranslation.Add(pageTranslation);

            Page page = this.GetPage(pageID);

            page.UpdatedDate = date;

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

            return pageTranslation;
        }

        public PageTranslation UpdatePageTranslation(long languageID, long pageID, string name, string seoName, string seoKeyword, string seoDescription, string text, string picture)
        {
            DateTime date = DateTime.Now;

            PageTranslation pageTranslation = this.GetPageTranslation(languageID, pageID);

            pageTranslation.Name = name;
            pageTranslation.Picture = picture;
            pageTranslation.SeoDescription = seoDescription;
            pageTranslation.SeoKeyword = seoKeyword;
            pageTranslation.SeoName = seoName;
            pageTranslation.Text = text;
            pageTranslation.UpdatedDate = date;

            Page page = this.GetPage(pageID);

            page.UpdatedDate = date;

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

            return pageTranslation;
        }

        private PageTranslation GetPageTranslation(long languageID, long pageID)
        {
            PageTranslation pageTranslation = context.PageTranslation.FirstOrDefault(z => z.LanguageID == languageID && z.PageID == pageID);

            return pageTranslation;
        }

        public bool ExistSeoName(string seoName, long? pageID = null)
        {
            bool existSeoName = false;

            if (pageID.HasValue)
            {
                existSeoName = context.PageTranslation.Any(z => z.SeoName.Equals(seoName) && z.PageID != pageID);
            }
            else
            {
                existSeoName = context.PageTranslation.Any(z => z.SeoName.Equals(seoName));
            }

            return existSeoName;
        }

        public bool ExistPageByPageID(long pageID)
        {
            bool existPage = false;

            existPage = context.Page.Any(z => z.ID == pageID);

            return existPage;
        }

        public List<Page> PageList(int page)
        {
            List<Page> pageList = context.Page.OrderByDescending(z => z.ID).Skip(CommonConstans.PageCount * (page - 1)).Take(CommonConstans.PageCount).ToList();

            return pageList;
        }

        public Page GetPage(long pageID)
        {
            Page page = context.Page.FirstOrDefault(z => z.ID == pageID);

            return page;
        }

        public long? ExistPageTranslationByPageIDAndLanguageID(long pageID, long languageID)
        {
            PageTranslation pageTranslation = context.PageTranslation.FirstOrDefault(z => z.PageID == pageID && z.LanguageID == languageID);

            long? pageTranslationID = pageTranslation != null ? pageTranslation.ID : new Nullable<long>();

            return pageTranslationID;
        }

        public IEnumerable<PageTranslation> GetPageTranslationListByPageID(long pageID)
        {
            IEnumerable<PageTranslation> pageTranslationList = context.PageTranslation.Where(z => z.PageID == pageID);

            return pageTranslationList;
        }

        public void DeletePage(long pageID)
        {
            Page page = this.GetPage(pageID);
            IEnumerable<PageTranslation> pageTranslationList = this.GetPageTranslationListByPageID(pageID);

            context.Page.Remove(page);
            context.PageTranslation.RemoveRange(pageTranslationList);

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
        }
    }
}