using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.ConfigurationDataBase.ConfigurationPostgreSQL
{
    public class KeyWordConfiguration
    {
        public KeyWordConfiguration(EntityTypeBuilder<KeyWord> entityBuilder)
        {
            entityBuilder.HasKey(kw => kw.Id);
            entityBuilder.Property(kw => kw.Id).HasColumnName("id");
            entityBuilder.Property(kw => kw.Key).HasColumnName("key").HasMaxLength(15).IsRequired();
            entityBuilder.Property(kw => kw.Id).ValueGeneratedOnAdd();

            entityBuilder.ToTable("key_words");
        }
    }
}
