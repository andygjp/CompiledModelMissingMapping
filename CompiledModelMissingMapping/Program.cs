using Microsoft.EntityFrameworkCore;

var context = new MyContext();
context.Database.Migrate();
var count = context.Blogs.Count();
Console.WriteLine($"There are {count} blogs.");

internal class MyContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=blogs.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property(b => b.Url)
            .IsRequired();
        
        modelBuilder.Entity<Blog>()
            .Property(e => e.Length)
            .HasConversion<string>();
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public BlogLength Length { get; set; }
}

public enum BlogLength
{
    Short,
    Long
}