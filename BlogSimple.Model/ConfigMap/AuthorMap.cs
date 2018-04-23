using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSimple.Model.ConfigMap
{
    public class AuthorMap
    {
        public static void Map(EntityTypeBuilder<Author> entityBuilder)
        {
           
            entityBuilder.HasKey(x => x.Id);
           
            entityBuilder.Property(x => x.FirstName).IsRequired();
            entityBuilder.Property(x => x.LastName).IsRequired();
            entityBuilder.HasMany(x => x.Books).WithOne(x => x.Author).IsRequired();
        }
    }
}
