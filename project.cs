using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Artist> Artist { get; set; }
    public DbSet<Song> Songs { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "music.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Artist
{
    public int ArtistId { get; set; }
    public string ArtistName { get; set; }
    public List<Song> Songs { get; } = new();
    public List<Album> Albums { get; } = new();
}

public class Album
{
    public int AlbumId { get; set; }
    public string AlbumTitle { get; set; }
    public List<Song> AlbumSongs { get; } = new();
}

public class Song
{
    public int SongId { get; set; }
    public string Title { get; set; }
    public string URL { get; set; }
    public Artist Artist { get; set; }
    public long number_of_auditions { get; set; }
}

[Route("api/[controller]")]

public class ProductsController : Controller
{
    [HttpGet("song/{id}")]
    public IActionResult GetProduct(int id)
    {
        var song = db.Song
    .OrderBy(b => b.SongId)
    .First();
        string fileName = (Path.GetExtension(song.URL)) == ".mp3"
    return fileName;
    }
}