using JEWAtypen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JEWAtypen.Helpers;

public class WikiInterface
{
    private readonly HttpClient _httpClient;
    private readonly string _uri = "https://nl.wikipedia.org/";

    public WikiInterface()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_uri)
        };
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "JEWA");
    }

    public async Task<WillekeurigAntwoord> OphalenWillekeurigArtikel()
    {
        WillekeurigAntwoord resultaat = null;
        HttpResponseMessage antwoord = await _httpClient.GetAsync("api/rest_v1/page/random/title");
        if (antwoord.IsSuccessStatusCode)
        {
            resultaat = await antwoord.Content.ReadAsAsync<WillekeurigAntwoord>();
        }
        return resultaat;
    }

    public async Task<ArtikelAntwoord> OphalenArtikelViaTitel(string titel)
    {
        ArtikelAntwoord resultaat = null;
        HttpResponseMessage antwoord = await _httpClient.GetAsync($"w/api.php?action=parse&prop=wikitext&format=json&formatversion=2&page={titel}");
        if (antwoord.IsSuccessStatusCode)
        {
            resultaat = await antwoord.Content.ReadAsAsync<ArtikelAntwoord>();
        }
        return resultaat;
    }
}
