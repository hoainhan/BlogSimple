using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.ConfigMap;
using BlogSimple.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogSimple.Model
{
    public class BlogSimpleContext: DbContext
    {
        public BlogSimpleContext(DbContextOptions<BlogSimpleContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AuthorMap.Map(modelBuilder.Entity<Author>());
            BookMap.Map(modelBuilder.Entity<Book>());
        }

        private DbSet<Book> Books { get; set; }
        private DbSet<Author> Authors { get; set; }
    }
}
