using VocabularyVault.Models;

namespace VocabularyVault.Dtos;

public class GetAllWordsInVaultResponseDto
{
    public string? word { get; set; }
    public string? Phonetic { get; set; }
    public List<CustomWordDetails>? RealExamples { get; set; }

    public static List<GetAllWordsInVaultResponseDto> Parse(IEnumerable<FavouriteWords> favourites)
    {
        var dataToReturn = new List<GetAllWordsInVaultResponseDto>();

        foreach (var favourite in favourites)
        {
            var temp = new GetAllWordsInVaultResponseDto
            {
                word = favourite.Word,
                Phonetic = favourite.Phonetic,
                RealExamples = new List<CustomWordDetails>()
            };
            temp.RealExamples = CustomWordDetails.Parse(favourite.Details);
            dataToReturn.Add(temp);
        }
        return dataToReturn;
    }
}