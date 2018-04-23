using System;
using System.Collections.Generic;
using System.Text;
using BlogSimple.Model.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSimple.Model.ConfigMap
{
    public class BookMap
    {
        public static void Map(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
        }
    }
}
