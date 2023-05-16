

# Product Thought Process-
# It is vault where use can save word and it's real life usage examples to learn english
# It main source of data is https://api.dictionaryapi.dev/api/v2/entries/en/hello
# User may search for words
# User would like to save word with some of it defination in vault to Reharse
# User would like to add more definations against word in vault to improve English
# User can look at all of the vault data
# User can delete particular word.

## Dotnet version 6.0.402
## EntityFrameworkCore.InMemoryDatabase used for simplicity
## Standard dotnet build to get essential pacakge before running code


-------------------- API Endpoints -----------------------
# Careful when testing as IT IS CASE SENSITIVE

### Search Words in Dictionary

Endpoint: GET api/vault/search/{-word-}

Request Payload: none


### Add Favourite Word to Vault

Endpoint: POST /api/vault/add

Request Payload:

{
    "word": "Hello",
    "phonetic": "",
    "usageType": "nouns",
    "defination": "\"Hello!\" or an equivalent greeting.",
    "synonyms": "greeting",
    "antonyms": ""
}


### Add More Detail against existing Favourite Word in Vault

Endpoint: POST api/vault/add-detail

Request Payload:

{
    "word": "Hello",
    "usageType": "interjection",
    "defination": "Used sarcastically to imply that the person addressed or referred to has done something the speaker or writer considers to be foolish.",
    "synonyms": "",
    "antonyms": "bye"
}

### Get All Words in Vault

Endpoint: GET api/vault/get
Request Payload: none


### Remove a Word in Vault

Endpoint: DELETE api/vault/remove/{-word-}
Request Payload: none

