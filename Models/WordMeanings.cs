using System.Text.Json.Serialization;

namespace VocabularyVault.Models;

public class WordMeanings
{
    [JsonPropertyName("partOfSpeech")]
    public string? PartsOfSpeech { get; set; }
    [JsonPropertyName("definitions")]
    public List<WordDefinations>? Definitions { get; set; }
    [JsonPropertyName("synonyms")]
    public List<string>? Synonyms { get; set; }
    [JsonPropertyName("antonyms")]
    public List<string>? Antonyms { get; set; }
}
