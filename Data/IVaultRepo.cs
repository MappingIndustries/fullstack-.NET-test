using VocabularyVault.Dtos;
using VocabularyVault.Models;

namespace VocabularyVault.Data;

public interface IVaultRepo
{
    Task SaveChangesAysnc();
    Task<IEnumerable<FavouriteWords>> GetAllFavouritesInVaultAsync();
    Task<bool> RemoveFavouritesInVaultAsync(string word);
    Task AddFavouritesInVaultAsync(AddFavouriteWordRequestDto addFavouriteWord);
    Task AddMoreWordDetailsInVaultAsync(AddMoreWordDetailsRequestDto addMoreWordDetails);
    Task<FavouriteWords?> SearchWordAsync(string word);
}