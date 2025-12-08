using LibrarySystem.UI.Pages;
using LibrarySystem.UI.Models;
using System.Net.Http.Json;


namespace LibrarySystem.UI.Services;


public class LoanService
{
    private readonly HttpClient _http;
    public LoanService(HttpClient http) => _http = http;


    public Task<List<Loan>> GetLoans() => _http.GetFromJsonAsync<List<Loan>>("api/Loans")!;
    public Task Create(Loan l) => _http.PostAsJsonAsync("api/Loans", l);
    public Task Delete(int id) => _http.DeleteAsync($"api/Loans/{id}");
}