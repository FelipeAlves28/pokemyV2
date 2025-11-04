using Newtonsoft.Json;
using static PokemyV2.Pages.IndexModel;

namespace PokemyV2.Models
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("genus")]
        public string Genus { get; set; } = string.Empty;
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
        [JsonProperty("imageUrl")]
        public string image { get; set; } = string.Empty;
        [JsonProperty("types")]
        public List<string> Types { get; set; } = null!;
        [JsonProperty("abilities")]
        public List<Abilities> Abilities { get; set; } = null!;
        [JsonProperty("stats")]
        public Stats Stats { get; set; } = null!;
        [JsonProperty("locations")]
        public List<string> Locations { get; set; } = null!;
        [JsonProperty("color")]
        public string Color { get; set; } = null!;
    }
    public record Abilities
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("effect")]
        public string Effect { get; set; } = string.Empty;
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

    }
    public record Stats
    {
        [JsonProperty("HP")]
        public int Hp { get; set; }
        [JsonProperty("Attack")]
        public int Attack { get; set; }
        [JsonProperty("Defense")]
        public int Defense { get; set; }
        [JsonProperty("Special Attack")]
        public int SpecialAttack { get; set; }
        [JsonProperty("Special Defense")]
        public int SpecialDefense { get; set; }
        [JsonProperty("Speed")]
        public int Speed { get; set; }
    }
}
