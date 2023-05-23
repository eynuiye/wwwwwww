using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GilmetdinovGaneev.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<ReaderCard> ReaderCards { get; set; }

    public virtual DbSet<ReadersSubscription> ReadersSubscriptions { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;User=root;Database=mydb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("applications");

            entity.HasIndex(e => e.WorkersId, "FKapplications_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(45)
                .HasColumnName("date");
            entity.Property(e => e.Quantity)
                .HasMaxLength(45)
                .HasColumnName("quantity");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");
            entity.Property(e => e.WorkersId).HasColumnName("workers_id");

            entity.HasOne(d => d.Workers).WithMany(p => p.Applications)
                .HasForeignKey(d => d.WorkersId)
                .HasConstraintName("FKapplications");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.ProvidersId, "FKbooks_idx");

            entity.HasIndex(e => e.PublishersId, "FKbooks_idx1");

            entity.HasIndex(e => e.Id, "idBook_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Autor)
                .HasMaxLength(45)
                .HasColumnName("autor");
            entity.Property(e => e.Cost)
                .HasMaxLength(45)
                .HasColumnName("cost");
            entity.Property(e => e.Genre)
                .HasMaxLength(45)
                .HasColumnName("genre");
            entity.Property(e => e.ProvidersId).HasColumnName("providers_id");
            entity.Property(e => e.PublicationDate)
                .HasMaxLength(45)
                .HasColumnName("publication_date");
            entity.Property(e => e.PublishersId).HasColumnName("publishers_id");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");

            entity.HasOne(d => d.Providers).WithMany(p => p.Books)
                .HasForeignKey(d => d.ProvidersId)
                .HasConstraintName("FKbooks1");

            entity.HasOne(d => d.Publishers).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublishersId)
                .HasConstraintName("FKbooks");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("providers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fcs)
                .HasMaxLength(45)
                .HasColumnName("fcs");
            entity.Property(e => e.Telephone)
                .HasMaxLength(45)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("publishers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("readers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Fcs)
                .HasMaxLength(45)
                .HasColumnName("fcs");
        });

        modelBuilder.Entity<ReaderCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reader_cards");

            entity.HasIndex(e => e.BooksId, "FKreaders_card_idx");

            entity.HasIndex(e => e.WorkersId, "FKreaders_card_idx1");

            entity.HasIndex(e => e.ReadersId, "FKreaders_card_idx2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BooksId).HasColumnName("books_id");
            entity.Property(e => e.Date)
                .HasMaxLength(45)
                .HasColumnName("date");
            entity.Property(e => e.ReadersId).HasColumnName("readers_id");
            entity.Property(e => e.WorkersId).HasColumnName("workers_id");

            entity.HasOne(d => d.Books).WithMany(p => p.ReaderCards)
                .HasForeignKey(d => d.BooksId)
                .HasConstraintName("FKreaders_card");

            entity.HasOne(d => d.Readers).WithMany(p => p.ReaderCards)
                .HasForeignKey(d => d.ReadersId)
                .HasConstraintName("FKreaders_card2");

            entity.HasOne(d => d.Workers).WithMany(p => p.ReaderCards)
                .HasForeignKey(d => d.WorkersId)
                .HasConstraintName("FKreaders_card1");
        });

        modelBuilder.Entity<ReadersSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("readers_subscriptions");

            entity.HasIndex(e => e.ReadersId, "FKreaders_subscriptions_idx");

            entity.HasIndex(e => e.WorkersId, "FKreaders_subscriptions_idx1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasMaxLength(45)
                .HasColumnName("cost");
            entity.Property(e => e.ReadersId).HasColumnName("readers_id");
            entity.Property(e => e.ValidityPeriod)
                .HasMaxLength(45)
                .HasColumnName("validity_period");
            entity.Property(e => e.WorkersId).HasColumnName("workers_id");

            entity.HasOne(d => d.Readers).WithMany(p => p.ReadersSubscriptions)
                .HasForeignKey(d => d.ReadersId)
                .HasConstraintName("FKreaders_subscriptions");

            entity.HasOne(d => d.Workers).WithMany(p => p.ReadersSubscriptions)
                .HasForeignKey(d => d.WorkersId)
                .HasConstraintName("FKreaders_subscriptions1");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fcs)
                .HasMaxLength(45)
                .HasColumnName("fcs");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Post)
                .HasMaxLength(45)
                .HasColumnName("post");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
