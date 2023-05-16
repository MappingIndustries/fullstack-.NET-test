using FluentValidation;
using VocabularyVault.Data;
using VocabularyVault.Dtos;
using VocabularyVault.Validations;

namespace VocabularyVault.VaultManager;

public class VaultOperation : IVaultOperation
{
    private readonly IVaultRepo _repo;
    private IValidator<AddFavouriteWordRequestDto> _addFavouriteWordValidation;

    public VaultOperation(IVaultRepo repo, IValidator<AddFavouriteWordRequestDto> addFavouriteWordValidation)
    {
        _repo = repo;
        _addFavouriteWordValidation = addFavouriteWordValidation;
    }

    public async Task<string> AddFavouriteInVault(AddFavouriteWordRequestDto addFavouriteWord)
    {
        var requestCheck = _addFavouriteWordValidation.Validate(addFavouriteWord);
        if (!requestCheck.IsValid)
        {
            throw new ValidationException(requestCheck.Errors.FirstOrDefault()?.ErrorMessage.ToString());
        }

        var favouriteWord = await _repo.SearchWordAsync(addFavouriteWord.Word!);

        if (favouriteWord == null)
        {
            await _repo.AddFavouritesInVaultAsync(addFavouriteWord);
            return "Record Added Successfully";
        }
        else
        {
            return "Word Already Exist in Vault. Maybe Add more details ?";
        }
    }

    public async Task<string> AddMoreWordDetailsInVault(AddMoreWordDetailsRequestDto addMoreWordDetails)
    {
        await _repo.AddMoreWordDetailsInVaultAsync(addMoreWordDetails);
        return "Record Update Successfully";
    }

    public async Task<List<GetAllWordsInVaultResponseDto>> GetAllFromVault()
    {
        var data = await _repo.GetAllFavouritesInVaultAsync();
        return GetAllWordsInVaultResponseDto.Parse(data);
    }

    public async Task<bool> RemoveWordFromVault(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return false;
        }

        return await _repo.RemoveFavouritesInVaultAsync(word);
    }
}