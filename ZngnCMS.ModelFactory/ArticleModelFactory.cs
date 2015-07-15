using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZngnCMS.Business;
using ZngnCMS.Entities;
using ZngnCMS.Model.Article;

namespace ZngnCMS.ModelFactory
{
    public class ArticleModelFactory
    {
        public ArticleIndexModel LoadIndex(int page)
        {
            ArticleIndexModel articleIndexModel = new ArticleIndexModel();

            ArticleBusiness articleBusiness = new ArticleBusiness();

            List<Article> articleList = articleBusiness.ArticleList(page);

            articleIndexModel.ArticleList = (from z in articleList
                                             select new ArticleItemModel
                                             {
                                                 ID = z.ID,
                                                 Name = z.ArticleTranslation.FirstOrDefault().Name
                                             }).ToList();

            return articleIndexModel;
        }

        public ArticleCreateModel LoadCreate()
        {
            ArticleCreateModel articleCreateModel = new ArticleCreateModel();
            LanguageBusiness languageBusiness = new LanguageBusiness();

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            articleCreateModel.LanguageList = new SelectList(languageList, "ID", "Name");

            return articleCreateModel;
        }

        public ArticleCreateModel ArticleCreate(ArticleCreateModel request)
        {
            ArticleCreateModel articleCreateModel = new ArticleCreateModel();

            LanguageBusiness languageBusiness = new LanguageBusiness();
            ArticleBusiness articleBusiness = new ArticleBusiness();

            IEnumerable<Language> languageList = languageBusiness.LanguageList();

            articleCreateModel.LanguageList = new SelectList(languageList, "ID", "Name", request.LanguageID);


            bool existLanguage = languageBusiness.ExistLanguage(request.LanguageID);

            if (!existLanguage)
            {
                articleCreateModel.Alerts.AlertList.Add("Dil bulunamadı!");
                articleCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;

                return articleCreateModel;
            }
            else
            {
                bool existSeoName = articleBusiness.ExistSeoName(request.SeoName);

                if (existSeoName)
                {
                    articleCreateModel.Alerts.AlertList.Add("Seo adı daha önce kullanılmış!");
                    articleCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;

                    return articleCreateModel;
                }
                else
                {
                    try
                    {
                        ArticleTranslation articleTranslation = articleBusiness.CreateArticleTranslation(request.LanguageID, request.Name, request.SeoName, request.SeoKeyword, request.SeoDescription, request.ShortText,request.LongText, request.Picture,request.ArticleType);

                        articleCreateModel.Alerts.AlertList.Add("İçerik başarıyla eklendi");
                        articleCreateModel.RedirectURL = "/Management/Article/Index";
                        articleCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;
                    }
                    catch (Exception ex)
                    {
                        articleCreateModel.Alerts.AlertList.Add("İçerik kaydedilemedi [ " + ex.Message + " ]");
                        articleCreateModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                    }
                }
            }

            return articleCreateModel;
        }

        public ArticleDeleteModel DeleteArticle(long pageID)
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();

            ArticleDeleteModel articleDeleteModel = new ArticleDeleteModel();

            bool existPage = articleBusiness.ExistPageByArticleID(pageID);

            if (!existPage)
            {
                articleDeleteModel.Alerts.AlertList.Add("İçerik bulunamadı.");
                articleDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
            }
            else
            {
                try
                {

                    articleBusiness.DeleteArticle(pageID);

                    articleDeleteModel.Alerts.AlertList.Add("İçerik başarıyla silindi.");
                    articleDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Success;


                }
                catch (Exception ex)
                {
                    articleDeleteModel.Alerts.AlertList.Add("İçerik silinemedi [ " + ex.Message + " ]");
                    articleDeleteModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
                }
            }

            articleDeleteModel.RedirectURL = "/Management/Article/Index";

            return articleDeleteModel;
        }

    }
}