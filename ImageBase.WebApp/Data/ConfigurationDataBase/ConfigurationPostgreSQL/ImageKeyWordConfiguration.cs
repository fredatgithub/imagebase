using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.ConfigurationDataBase.ConfigurationPostgreSQL
{
    public class ImageKeyWordConfiguration
    {
        public ImageKeyWordConfiguration(EntityTypeBuilder<ImageKeyWord> entityBuilder)
        {
            entityBuilder.HasKey(ikw => ikw.Id);
            entityBuilder.Property(ikw => ikw.ImageId).HasColumnName("image_id");
            entityBuilder.Property(ikw => ikw.KeyWordId).HasColumnName("key_word_id");
            entityBuilder.Property(ikw => ikw.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entityBuilder.HasOne(i => i.Image)
                .WithMany(ikw => ikw.ImageKeyWords)
                .HasForeignKey(ikw => ikw.ImageId);

            entityBuilder.HasOne(kw => kw.KeyWord)
                .WithMany(ikw => ikw.ImageKeyWords)
                .HasForeignKey(ikw => ikw.KeyWordId);

            entityBuilder.ToTable("images_key_words");
        }
    }
}
