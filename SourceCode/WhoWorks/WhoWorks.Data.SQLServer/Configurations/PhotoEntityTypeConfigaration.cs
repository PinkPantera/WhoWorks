using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Domain.Models;

namespace WhoWorks.Data.SQLServer.Configurations
{
    public class PhotoEntityTypeConfigaration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");
            builder.HasKey(p => p.Id);


            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder.HasOne(p => p.Person)
                .WithOne(person => person.Photo);

            builder.Property(p => p.ImageData)
                .IsRequired();

            builder
                .Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
