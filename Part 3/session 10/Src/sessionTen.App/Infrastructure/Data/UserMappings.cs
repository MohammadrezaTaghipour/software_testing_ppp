using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sessionTen.App.Domain;

namespace sessionTen.App.Infrastructure.Data;

public class UserMappings : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasIndex(p => p.Id).IsUnique();
        builder.Property(b => b.Id).ValueGeneratedNever();
        
        builder.Property(b => b.Email).IsRequired();
        builder.Property(b => b.Type).IsRequired();
        builder.Property(b => b.CompanyId).IsRequired();
    }
}