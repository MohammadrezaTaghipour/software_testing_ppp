using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sessionTen.App.Domain;

namespace sessionTen.App.Infrastructure.Data;

public class CompanyMappings : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasIndex(b => b.Id).IsUnique();
        builder.Property(b => b.Id).ValueGeneratedNever();
        
        builder.Property(b => b.Subdomain).IsRequired();
        builder.Property(b => b.NumberOfEmployees).IsRequired();
    }
}