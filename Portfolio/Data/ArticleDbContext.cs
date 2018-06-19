using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class ArticleDbContext : DbContext
    {


        public ArticleDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
            }
        }

        public DbSet<Portfolio.Models.Article> Article { get; set; }

        public DbSet<Portfolio.Models.Section> Section { get; set; }

        public async Task<Article> ArticleWithSections(int id)
        {
            var article =  await Article.FindAsync(id);
            await Entry(article).Collection(x => x.Sections).LoadAsync();
            article.Sections.OrderBy(x => x.Index);
            return article;
        }
    }
}
