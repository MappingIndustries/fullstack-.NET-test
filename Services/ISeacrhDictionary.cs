using VocabularyVault.Dtos;
using VocabularyVault.Models;

namespace VocabularyVault.Services;

public interface ISeacrhDictionary
{
    Task<WordDetails> SearchWordInDictionary(string word);
}