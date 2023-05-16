namespace VocabularyVault.Models
{
    public class CustomWordDetails
    {
        public string? UsageType { get; set; }
        public string? Defination { get; set; }
        public string? Synonyms { get; set; }
        public string? Antonyms { get; set; }

        public static List<CustomWordDetails> Parse(ICollection<FavouriteWordDetails> favouriteWordDetails)
        {
            var dataToReturn = new List<CustomWordDetails>();

            foreach (var detail in favouriteWordDetails)
            {
                var temp = new CustomWordDetails
                {
                    UsageType = detail.UsageType,
                    Defination = detail.Defination,
                    Synonyms = detail.Synonyms,
                    Antonyms = detail.Antonyms
                };
                dataToReturn.Add(temp);
            }
            return dataToReturn;
        }
    }
}