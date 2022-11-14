using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhoWorks.Domain.Models;

namespace WhoWorks.Data.SQLServer.Configurations
{
    public class AddressEntityTypeConfigaration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ShortAddress)
                .IsRequired();
            builder.Property(p => p.Town)
                .IsRequired();
            builder.Property(p => p.Region)
                .IsRequired();
            builder.Property(p => p.Country)
                .IsRequired();
            builder.Property(p => p.CityCode)
                .IsRequired();
            builder
                .HasOne(address => address.Person)
                .WithOne(person => person.Address);

        }
    }
}
