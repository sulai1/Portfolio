﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio.Areas.Articles.Models;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Section> Section { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Section>()
            .HasOne(p => p.Article)
            .WithMany(b => b.Sections)
            .OnDelete(DeleteBehavior.Cascade);
        }
        public async Task<Article> ArticleWithSections(int id)
        {
            var article = await Articles.FindAsync(id);
            await Entry(article).Collection(x => x.Sections).LoadAsync();
            article.Sections.OrderBy(x => x.Index);
            return article;
        }
    }
}
