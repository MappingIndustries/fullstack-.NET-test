using System.Text.Json;
using FluentValidation;
using VocabularyVault.Dtos;
using VocabularyVault.Models;

namespace VocabularyVault.Services;

public class SearchDictionary : ISeacrhDictionary
{
    private readonly HttpClient _httpClient;

    public SearchDictionary(HttpClient httpClient)
    {
        _httpClient = httpClient;

    }
    public async Task<WordDetails> SearchWordInDictionary(string word)
    {
        var response = await _httpClient.GetAsync(word);
        if (response.IsSuccessStatusCode)
        {
            var wordDetails = await JsonSerializer.DeserializeAsync<List<WordDetails>>(await response.Content.ReadAsStreamAsync());
            return wordDetails!.First()!;
        }
        else
        {
            System.Console.WriteLine("-------- Search Words in Dictionary API Down -----------");
            return null!;
        }
    }
}