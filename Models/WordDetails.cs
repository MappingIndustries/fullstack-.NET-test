using System.Text.Json.Serialization;

namespace VocabularyVault.Models;

public class WordDetails
{
    [JsonPropertyName("word")] 
    public string? Word { get; set; }
    [JsonPropertyName("phonetic")]
    public string? Phonetic { get; set; }
    [JsonPropertyName("meanings")]
    public List<WordMeanings>? Meanings { get; set; }
}