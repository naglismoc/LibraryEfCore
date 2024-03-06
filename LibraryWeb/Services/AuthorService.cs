using LibraryWeb.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace LibraryWeb.Services;

public class AuthorService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://localhost:7206/api/Author";

    public AuthorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<Author>> getAuthorsAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        return await response.Content.ReadFromJsonAsync<List<Author>>();
    }
    public async Task<Author> GetAuthorByIdAsync(long id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Author>();
        }
        else
        {
            throw new Exception($"Failed to fetch author with ID {id}: {response.StatusCode}");
        }
    }
    public async Task CreateAuthorAsync(Author author)
    {
        var content = JsonContent.Create(author, MediaTypeHeaderValue.Parse("application/json"));
        var response = await _httpClient.PostAsync(_baseUrl, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Failed to create author: {response.StatusCode}");
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        author.Books = null;
        var json = System.Text.Json.JsonSerializer.Serialize(author);
        // throw new Exception($"{json}");
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{author.Id}/json", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"----------{response.StatusCode}-----------");
            throw new Exception($"Failed to update author with ID {content}");
            throw new Exception($"Failed to update author with ID {author.Id} {author.Name} {author.Surname}:  {_baseUrl}/{author.Id}/edit {response.StatusCode}");
        }
    }
    public async Task DeleteAuthorAsync(long id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to delete author with ID {id}: {response.StatusCode}");
        }
    }
}