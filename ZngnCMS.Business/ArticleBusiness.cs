namespace ZngnCMS.Business
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    using ZngnCMS.Constants;
    using ZngnCMS.Entities;
    #endregion

    public class ArticleBusiness
    {
        private ModelContext context;

        public ArticleBusiness()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
        }

        public List<Article> ArticleList(int page)
        {
            List<Article> articleList = context.Article.OrderByDescending(z => z.ID).Skip(CommonConstans.ArticleCount * (page - 1)).Take(CommonConstans.ArticleCount).ToList();

            return articleList;
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

        public ArticleTranslation CreateArticleTranslation(long languageID, string name, string seoName, string seoKeyword, string seoDescription, string shortText, string longText, string picture, int articleType)
        {
            DateTime date = DateTime.Now;

            Article article = new Article
            {
                ArticleType = articleType,
                CreatedDate = date,
                UpdatedDate = date
            };

            context.Article.Add(article);

            ArticleTranslation articleTranslation = new ArticleTranslation
            {
                LanguageID = languageID,
                Name = name,
                ArticleID = article.ID,
                Picture = picture,
                SeoDescription = seoDescription,
                SeoKeyword = seoKeyword,
                SeoName = seoName,
                ShortText = shortText,
                LongText = longText,
                CreatedDate = date,
                UpdatedDate = date
            };

            context.ArticleTranslation.Add(articleTranslation);

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

            return articleTranslation;
        }

        public bool ExistPageByArticleID(long articleID)
        {
            bool existArticle = false;

            existArticle = context.Article.Any(z => z.ID == articleID);

            return existArticle;
        }

        public void DeleteArticle(long articleID)
        {
            Article article = this.GetArticle(articleID);
            IEnumerable<ArticleTranslation> articleTranslationList = this.GetArticleTranslationListByArticleID(articleID);

            context.Article.Remove(article);
            context.ArticleTranslation.RemoveRange(articleTranslationList);

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

        public Article GetArticle(long articleID)
        {
            Article article = context.Article.FirstOrDefault(z => z.ID == articleID);

            return article;
        }

        public IEnumerable<ArticleTranslation> GetArticleTranslationListByArticleID(long articleID)
        {
            IEnumerable<ArticleTranslation> articleTranslationList = context.ArticleTranslation.Where(z => z.ArticleID == articleID);
            
            return articleTranslationList;
        }
    }
}