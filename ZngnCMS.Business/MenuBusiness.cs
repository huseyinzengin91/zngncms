namespace ZngnCMS.Business
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using ZngnCMS.Entities;

    #endregion

    public class MenuBusiness
    {
        ModelContext context;

        public MenuBusiness()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
        }


        public List<Menu> GetMenuList()
        {
            List<Menu> menu = context.Menu.ToList();

            return menu;
        }

        public Menu GetMenuByID(long menuID)
        {
            Menu menu = context.Menu.FirstOrDefault(z => z.ID == menuID);

            return menu;
        }

        public List<Menu> GetSubMenu(long menuID)
        {
            List<Menu> menuList = context.Menu.Where(z => z.TopMenu == menuID).ToList();

            return menuList;
        }

        public MenuTranslation CreateMenuTranslation(long languageID, string name, string url, int sort, long? topMenu)
        {
            DateTime date = DateTime.Now;

            Menu menu = new Menu
            {
                CreatedDate = date,
                UpdatedDate = date,
                TopMenu = topMenu
            };

            context.Menu.Add(menu);

            MenuTranslation menuTranslation = new MenuTranslation
            {
                CreatedDate = date,
                UpdatedDate = date,
                LanguageID = languageID,
                MenuID = menu.ID,
                Name = name,
                Sort = sort,
                URL = url
            };

            context.MenuTranslation.Add(menuTranslation);

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

            return menuTranslation;
        }

        public void DeleteMenu(long menuID)
        {
            Menu menu = this.GetMenuByID(menuID);

            List<Menu> allMenuList = this.GetMenuList();

            List<Menu> subMenuList = this.GetSubMenuByTopMenuID(allMenuList, menuID);

            for (int i = 0; i < subMenuList.Count; i++)
            {
                List<Menu> tmpSubMenuList = this.GetSubMenuByTopMenuID(allMenuList, subMenuList[i].ID);

                if (tmpSubMenuList != null && tmpSubMenuList.Any())
                {
                    subMenuList.AddRange(tmpSubMenuList);
                }
            }

            subMenuList.Add(menu);

            List<MenuTranslation> menuTranslationList = new List<MenuTranslation>();

            foreach (Menu menuItem in subMenuList)
            {
                menuTranslationList.AddRange(menuItem.MenuTranslation);
            }

            context.Menu.RemoveRange(subMenuList);
            context.MenuTranslation.RemoveRange(menuTranslationList);

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

        private List<Menu> GetSubMenuByTopMenuID(List<Menu> subMenuList, long topMenuID)
        {
            List<Menu> tmpSubMenuList = subMenuList.Where(z => z.TopMenu == topMenuID).ToList();

            return tmpSubMenuList;
        }

    }
}
