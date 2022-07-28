namespace JGP.Members.Data.EntityFramework;

using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
///     Class MemberMap.
///     Implements the <see cref="Member" />
/// </summary>
/// <seealso cref="Member" />
internal class MemberMap : IEntityTypeConfiguration<Member>
{
    /// <summary>
    ///     Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        // Primary Key.
        builder.HasKey(member => member.Id);

        // Properties.
        builder.Property(member => member.CultureCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(member => member.EmailAddress)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(member => member.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(member => member.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(member => member.PasswordHash)
            .IsRequired()
            .HasMaxLength(128);

        // Default Values.
        builder.Property(member => member.IsEnabled)
            .HasDefaultValue(true);

        builder.Property(member => member.FailedLoginAttemptCount)
            .HasDefaultValue(0);

        builder.Property(member => member.CultureCode)
            .HasDefaultValue("en-GB");

        // Indexes.
        builder.HasIndex(member => member.EmailAddress)
            .HasDatabaseName("IX_Member_EmailAddress")
            .IsUnique();

        // Table & Column Mappings.
        builder.ToTable("Members", "dbo");
        builder.Property(member => member.Id).HasColumnName("MemberId");
        builder.Property(member => member.EmailAddress).HasColumnName("EmailAddress");
        builder.Property(member => member.FirstName).HasColumnName("FirstName");
        builder.Property(member => member.LastName).HasColumnName("LastName");
        builder.Property(member => member.PasswordHash).HasColumnName("PasswordHash");
        builder.Property(member => member.CultureCode).HasColumnName("CultureCode");
        builder.Property(member => member.CreatedOn).HasColumnName("CreatedOn");
        builder.Property(member => member.DateLastLoggedIn).HasColumnName("DateLastLoggedIn");
        builder.Property(member => member.FailedLoginAttemptCount).HasColumnName("FailedLoginAttemptCount");
        builder.Property(member => member.IsEnabled).HasColumnName("IsEnabled");
    }
}