using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public string DbPath {get;}

    public BookContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "book.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
    
}

public class Book
{
    [Key] public int Id { get; set; }
    [StringLength(100)] public string? Name { get; set; }
    [StringLength(100)] public string? Phone { get; set; }
}