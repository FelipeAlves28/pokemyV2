using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PokemyV2.Models;

namespace PokemyV2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private static HttpClient _client = new();
        public List<Pokemon> Pokemons = null!;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int take = 0, int skip = 25)
        {
            HttpResponseMessage response = _client.GetAsync($"https://pokeapi.deno.dev/pokemon?offset={take}&limit={skip}").GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                Pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult()) ?? new();
            }
            else
            {
                Pokemons = new();
            }
        }
    }
}
