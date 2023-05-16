using VocabularyVault.Dtos;

namespace VocabularyVault.VaultManager
{
    public interface IVaultOperation
    {
        Task<string> AddFavouriteInVault(AddFavouriteWordRequestDto addFavouriteWord);
        Task<string> AddMoreWordDetailsInVault(AddMoreWordDetailsRequestDto addMoreWordDetails);
        Task<List<GetAllWordsInVaultResponseDto>> GetAllFromVault();
        Task<bool> RemoveWordFromVault(string word);
    }
}