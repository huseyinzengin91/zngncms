using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ZngnCMS.Entities
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ZngnEntitiesConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Article>()
                .HasMany(z => z.Category)
                .WithMany(z => z.Article)
                .Map(h =>
                {
                    h.MapLeftKey("ArticleID");
                    h.MapRightKey("CategoryID");
                    h.ToTable("ArticleCategory");
                });


        }

        public virtual DbSet<Language> Language { get; set; }

        public virtual DbSet<SiteSetting> SiteSetting { get; set; }

        public virtual DbSet<SiteSettingTranslation> SiteSettingTranslation { get; set; }

        public virtual DbSet<Page> Page { get; set; }

        public virtual DbSet<PageTranslation> PageTranslation { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<PagePermission> PagePermission { get; set; }

        public virtual DbSet<Menu> Menu { get; set; }

        public virtual DbSet<MenuTranslation> MenuTranslation { get; set; }

        public virtual DbSet<Article> Article { get; set; }

        public virtual DbSet<ArticleTranslation> ArticleTranslation { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<CategoryTranslation> CategoryTranslation { get; set; }
    }
}