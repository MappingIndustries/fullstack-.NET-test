using System.Text.Json.Serialization;

namespace VocabularyVault.Models;

public class WordDefinations
{
    [JsonPropertyName("definition")]
    public string? Definations { get; set; }
}