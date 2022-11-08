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
    public class PersonEntityTypeConfigaration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
               .Property(p => p.SecondName)
               .IsRequired()
               .HasMaxLength(50);

            builder
                .Property(p => p.DateOfBirth)
                .IsRequired();

            builder
                .Property(p => p.IdentityCard)
                .IsRequired(true);

            builder
              .Property(p => p.Email)
              .IsRequired()
              .HasMaxLength(50);

            builder
                .Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasOne(person => person.Photo)
                .WithOne(photo=>photo.Person);

            builder
               .Property(p => p.CreatedDate)
               .HasDefaultValueSql("GETDATE()");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

        }
    }
}