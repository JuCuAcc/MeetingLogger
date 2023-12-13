#nullable disable
using MeetingLogger.Models;
using Microsoft.EntityFrameworkCore;namespace MeetingLogger.Data;public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    #region Identity
    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
    #endregion

    public virtual DbSet<CorporateCustomerTbl> CorporateCustomerTbls { get; set; }
    public virtual DbSet<IndividualCustomerTbl> IndividualCustomerTbls { get; set; }
    public virtual DbSet<MeetingMinutesDetailsTbl> MeetingMinutesDetailsTbls { get; set; }
    public virtual DbSet<MeetingMinutesMasterTbl> MeetingMinutesMasterTbls { get; set; }
    public virtual DbSet<ProductsServiceTbl> ProductsServiceTbls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.AspNetRoleConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.AspNetRoleClaimConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.AspNetUserConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.AspNetUserClaimConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.AspNetUserLoginConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.AspNetUserTokenConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.CorporateCustomerTblConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.IndividualCustomerTblConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.MeetingMinutesDetailsTblConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.MeetingMinutesMasterTblConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ProductsServiceTblConfiguration());
        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
