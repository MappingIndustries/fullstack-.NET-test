using System.ComponentModel.DataAnnotations;
using VocabularyVault.Dtos;

namespace VocabularyVault.Models;

public class FavouriteWords
{
    public FavouriteWords()
    {
        Details = new HashSet<FavouriteWordDetails>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Word { get; set; }
    public string? Phonetic { get; set; }
    public virtual ICollection<FavouriteWordDetails> Details { get; set; }

    public static FavouriteWords Parse(AddFavouriteWordRequestDto addFavouriteWord)
    {
        var favouriteWordParsed = new FavouriteWords
        {
            Word = addFavouriteWord.Word,
            Phonetic = addFavouriteWord.Phonetic,
            Details = new List<FavouriteWordDetails>()
        };
        
        favouriteWordParsed.Details.Add(FavouriteWordDetails.Parse(addFavouriteWord));
        return favouriteWordParsed;

    }
}