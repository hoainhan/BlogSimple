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
            ConfigMaps.MapBlogPost(modelBuilder.Entity<BlogPost>());
            ConfigMaps.MapCategory(modelBuilder.Entity<Category>());
            ConfigMaps.MapComment(modelBuilder.Entity<Comment>());
        }
        private DbSet<BlogPost> BlogPosts { get; set; }
        private DbSet<Comment> Comments { get; set; }
        private DbSet<Category> Categories { get; set; }
        
    }
}
