using Microsoft.EntityFrameworkCore;
using VocabularyVault.Dtos;
using VocabularyVault.Models;

namespace VocabularyVault.Data;

public class VaultRepo : IVaultRepo
{
    private readonly AppDbContext _context;

    public VaultRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddFavouritesInVaultAsync(AddFavouriteWordRequestDto addFavouriteWord)
    {
        var favouriteWordToAdd = FavouriteWords.Parse(addFavouriteWord);
        await _context.FavouriteWords.AddAsync(favouriteWordToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task AddMoreWordDetailsInVaultAsync(AddMoreWordDetailsRequestDto addMoreWordDetails)
    {
        var wordToUpdate = await _context.FavouriteWords.SingleOrDefaultAsync(x => x.Word == addMoreWordDetails.Word);

        if (wordToUpdate == null)
        {
            throw new Exception("The word does not exist in the vault.");
        }

        var newDetails = new FavouriteWordDetails
        {
            Defination = addMoreWordDetails.Defination,
            UsageType = addMoreWordDetails.UsageType,
            Synonyms = addMoreWordDetails.Synonyms,
            Antonyms = addMoreWordDetails.Antonyms
        };

        wordToUpdate.Details.Add(newDetails);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FavouriteWords>> GetAllFavouritesInVaultAsync()
    {
        return await _context.FavouriteWords.Include(x => x.Details).ToListAsync();
    }

    public async Task<bool> RemoveFavouritesInVaultAsync(string word)
    {
        var wordToRemove = await _context.FavouriteWords.FirstOrDefaultAsync(x => x.Word == word);
        if (wordToRemove != null)
        {
            _context.FavouriteWords.Remove(wordToRemove);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task SaveChangesAysnc()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<FavouriteWords?> SearchWordAsync(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return null;
        }
        return await _context.FavouriteWords.FirstOrDefaultAsync(x => x.Word == word);
    }
}