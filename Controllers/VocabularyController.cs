using Microsoft.AspNetCore.Mvc;
using VocabularyVault.Data;
using VocabularyVault.Dtos;
using VocabularyVault.Models;
using VocabularyVault.Services;
using VocabularyVault.VaultManager;

namespace VocabularyVault;

[Route("api/vault")]
[ApiController]
public class VocabularyController : ControllerBase
{
    private readonly ISeacrhDictionary _searchDictionary;
    private readonly IVaultOperation _vaultOperation;
    private readonly IVaultRepo _repo;

    public VocabularyController(ISeacrhDictionary seacrhDictionary, IVaultOperation vaultOperation, IVaultRepo repo)
    {
        _searchDictionary = seacrhDictionary;
        _vaultOperation = vaultOperation;
        _repo = repo;
    }
    [HttpGet("search/{word}")]
    public async Task<ActionResult<WordDetails>> SearchWordInDictionary(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return BadRequest("Invalid word.");
        }
        var data = await _searchDictionary.SearchWordInDictionary(word);
        if (data == null)
        {
            return NotFound("Word not found in the dictionary.");
        }
        return Ok(data);
    }

    [HttpPost("add")]
    public async Task<ActionResult<string>> AddVocabulryToVault(AddFavouriteWordRequestDto addFavouriteWordRequestDto)
    {
        var data = await _vaultOperation.AddFavouriteInVault(addFavouriteWordRequestDto);
        if (data == null)
        {
            return NotFound("Failed to add the word to the vault.");
        }
        return Ok(data);
    }

    [HttpPost("add-detail")]
    public async Task<ActionResult<string>> AddMoreWordDetails(AddMoreWordDetailsRequestDto addMoreWordDetailsRequestDto)
    {
        var data = await _vaultOperation.AddMoreWordDetailsInVault(addMoreWordDetailsRequestDto);
        if (data == null)
        {
            return NotFound("Failed to add details of word to the vault.");
        }
        return Ok(data);
    }

    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<FavouriteWords>>> GetVaultData()
    {
        var favourites = await _vaultOperation.GetAllFromVault();
        return Ok(favourites);

    }

    [HttpDelete("remove/{word}")]
    public async Task<ActionResult<string>> RemoveDataFromVault(string word)
    {
        var removed = await _vaultOperation.RemoveWordFromVault(word);
        if (removed)
        {
            return Ok($"{word} removed !!!");
        }
        else
        {
            return NotFound("Word not found in the vault.");
        }
    }

}