using CollegeApp.Domain.BookModels.AuthorModels;
using CollegeApp.Domain.BookModels;
using Microsoft.EntityFrameworkCore;
using CollegeApp.Domain.BookModels.PublisherModels;

namespace CollegeApp.Domain.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Book
        modelBuilder.Entity<BookCommonModel>(entity =>
        {
            entity.ToTable("Books");

            entity.HasKey(b => b.Id);

            entity.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(b => b.Description)
                .HasMaxLength(1000);

            entity.Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            entity.Property(b => b.Rating);

            entity.Property(b => b.StockCount);

            entity.Property(b => b.Language)
                .HasConversion<int>(); // Store enum as int

            entity.Property(b => b.Format)
                .HasConversion<int>();

            entity.Property(b => b.Edition)
                .HasConversion<int>();

            entity.HasMany(b => b.BookAuthors)
                .WithOne(ba => ba.Book)
                .HasForeignKey(ba => ba.BookId);

            entity.HasMany(b => b.BookPublishers)
                .WithOne(bp => bp.Book)
                .HasForeignKey(bp => bp.BookId);
        });

        // Author
        modelBuilder.Entity<AuthorCommonModel>(entity =>
        {
            entity.ToTable("Authors");

            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasMany(a => a.BookAuthors)
                .WithOne(ba => ba.Author)
                .HasForeignKey(ba => ba.AuthorId);
        });

        // Publisher
        modelBuilder.Entity<PublisherCommonModel>(entity =>
        {
            entity.ToTable("Publishers");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        // BookAuthor (Join Table)
        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.ToTable("BookAuthors");

            entity.HasKey(ba => new { ba.BookId, ba.AuthorId });

            entity.HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            entity.HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        });

        // BookPublisher (Join Table)
        modelBuilder.Entity<BookPublisher>(entity =>
        {
            entity.ToTable("BookPublishers");

            entity.HasKey(bp => new { bp.BookId, bp.PublisherId });

            entity.HasOne(bp => bp.Book)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.BookId);

            entity.HasOne(bp => bp.Publisher)
                .WithMany() // Publisher does not explicitly list BookPublishers
                .HasForeignKey(bp => bp.PublisherId);
        });
    }
}