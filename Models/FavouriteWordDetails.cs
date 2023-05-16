using System.ComponentModel.DataAnnotations;
using VocabularyVault.Dtos;

namespace VocabularyVault.Models;

public class FavouriteWordDetails
{
    [Key]
    public int Id { get; set; }
    public string? UsageType { get; set; }
    public string? Defination { get; set; }
    public string? Synonyms { get; set; }
    public string? Antonyms { get; set; }
    public virtual FavouriteWords? FavouriteWords { get; set; }

    public static FavouriteWordDetails Parse(AddFavouriteWordRequestDto addFavouriteWordRequest)
    {
        return new FavouriteWordDetails
        {
            UsageType = addFavouriteWordRequest.UsageType,
            Defination = addFavouriteWordRequest.Defination,
            Antonyms = addFavouriteWordRequest.Antonyms,
            Synonyms = addFavouriteWordRequest.Synonyms
        };
    }
}