using System.Net.Http.Json;
using LibrarySystem.UI.Models;


namespace LibrarySystem.UI.Services;


public class ReaderService
{
    private readonly HttpClient _http;
    public ReaderService(HttpClient http) => _http = http;


    public Task<List<Reader>> GetReaders() => _http.GetFromJsonAsync<List<Reader>>("api/Readers")!;
    public Task<Reader?> GetReader(int id) => _http.GetFromJsonAsync<Reader>($"api/Readers/{id}");
    public Task Create(Reader r) => _http.PostAsJsonAsync("api/Readers", r);
    public Task Update(int id, Reader r) => _http.PutAsJsonAsync($"api/Readers/{id}", r);
    public Task Delete(int id) => _http.DeleteAsync($"api/Readers/{id}");
}