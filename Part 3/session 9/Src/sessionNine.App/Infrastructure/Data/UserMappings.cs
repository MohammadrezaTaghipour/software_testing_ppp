using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sessionNine.App.Domain;

namespace sessionNine.App.Infrastructure.Data;

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