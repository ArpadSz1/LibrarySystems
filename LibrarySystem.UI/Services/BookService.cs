using System.Net.Http.Json;
using LibrarySystem.UI.Models;


namespace LibrarySystem.UI.Services;


public class BookService
{
    private readonly HttpClient _http;
    public BookService(HttpClient http) => _http = http;


    public Task<List<Book>> GetBooks() => _http.GetFromJsonAsync<List<Book>>("api/Books")!;
    public Task<Book?> GetBook(int id) => _http.GetFromJsonAsync<Book>($"api/Books/{id}");
    public Task Create(Book b) => _http.PostAsJsonAsync("api/Books", b);
    public Task Update(int id, Book b) => _http.PutAsJsonAsync($"api/Books/{id}", b);
    public Task Delete(int id) => _http.DeleteAsync($"api/Books/{id}");
}