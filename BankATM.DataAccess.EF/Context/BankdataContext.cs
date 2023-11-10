using System;
using System.Collections.Generic;
using BankATM.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace BankATM.DataAccess.EF.Context;

public partial class BankdataContext : DbContext
{
    public BankdataContext()
    {
    }

    public BankdataContext(DbContextOptions<BankdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomersInfo>? CustomersInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-76SS7Q5\\SQLEXPRESS07;Database=BANKDATA;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomersInfo>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8F489E874");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
