namespace VocabularyVault.Dtos;

public class AddMoreWordDetailsRequestDto
{
    public string? Word { get; set; }
    public string? UsageType { get; set; }
    public string? Defination { get; set; }
    public string? Synonyms { get; set; }
    public string? Antonyms { get; set; }
}