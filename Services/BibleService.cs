using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

public class BibleService
{
    private readonly HttpClient _httpClient;

    public BibleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<string>> GetBibleVersesAsync()
    {
        var verses = new List<string>();
        var response = await _httpClient.GetStringAsync("Bible.txt");
        var bibleText = JsonSerializer.Deserialize<BibleText>(response);

        foreach (var verse in bibleText.verses)
        {
            verses.Add(verse);
        }

        return verses;
    }

    private class BibleText
    {
        public string[] verses { get; set; }
    }
}