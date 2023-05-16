using Microsoft.EntityFrameworkCore;
using VocabularyVault.Models;

namespace VocabularyVault.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<FavouriteWords> FavouriteWords => Set<FavouriteWords>();
    public DbSet<FavouriteWordDetails> FavouriteWordsDetails => Set<FavouriteWordDetails>();
}