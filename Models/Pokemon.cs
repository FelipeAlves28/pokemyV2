using Newtonsoft.Json;
using PokemyV2.Enum;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
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
        public string FormatTypes
        {
            get
            {
                return $"{String.Join(",", this.Types)}"; ;
            }
        }

        public List<PokemonEnum.PokemonType> TypesId { 
            get
            {
                return GetPokemonTypes(this.Types);
            }  
        }
        private List<PokemonEnum.PokemonType> GetPokemonTypes(List<string> Types)
        {
            List<PokemonEnum.PokemonType> _TypesId = null!;

            foreach (var type in Types)
            {
                if (_TypesId == null)
                {
                    _TypesId = new();
                }

                PokemonEnum.PokemonType _PokemonType = GetPokemonTypeByName(type).GetValueOrDefault();
                _TypesId.Add(_PokemonType);
            }
            return _TypesId;
        }

        private PokemonEnum.PokemonType? GetPokemonTypeByName(string TypeName)
        {
            if (nameof(PokemonEnum.PokemonType.Normal) == TypeName)
            {
                return PokemonEnum.PokemonType.Normal;
            }
            if (nameof(PokemonEnum.PokemonType.Fire) == TypeName)
            {
                return PokemonEnum.PokemonType.Fire;
            }
            if (nameof(PokemonEnum.PokemonType.Water) == TypeName)
            {
                return PokemonEnum.PokemonType.Water;
            }
            if (nameof(PokemonEnum.PokemonType.Electric) == TypeName)
            {
                return PokemonEnum.PokemonType.Electric;
            }
            if (nameof(PokemonEnum.PokemonType.Grass) == TypeName)
            {
                return PokemonEnum.PokemonType.Grass;
            }
            if (nameof(PokemonEnum.PokemonType.Ice) == TypeName)
            {
                return PokemonEnum.PokemonType.Ice;
            }
            if (nameof(PokemonEnum.PokemonType.Fighting) == TypeName)
            {
                return PokemonEnum.PokemonType.Fighting;
            }
            if (nameof(PokemonEnum.PokemonType.Poison) == TypeName)
            {
                return PokemonEnum.PokemonType.Poison;
            }
            if (nameof(PokemonEnum.PokemonType.Ground) == TypeName)
            {
                return PokemonEnum.PokemonType.Ground;
            }
            if (nameof(PokemonEnum.PokemonType.Flying) == TypeName)
            {
                return PokemonEnum.PokemonType.Flying;
            }
            if (nameof(PokemonEnum.PokemonType.Psychic) == TypeName)
            {
                return PokemonEnum.PokemonType.Psychic;
            }
            if (nameof(PokemonEnum.PokemonType.Bug) == TypeName)
            {
                return PokemonEnum.PokemonType.Bug;
            }
            if (nameof(PokemonEnum.PokemonType.Rock) == TypeName)
            {
                return PokemonEnum.PokemonType.Rock;
            }
            if (nameof(PokemonEnum.PokemonType.Ghost) == TypeName)
            {
                return PokemonEnum.PokemonType.Ghost;
            }
            if (nameof(PokemonEnum.PokemonType.Dark) == TypeName)
            {
                return PokemonEnum.PokemonType.Dark;
            }
            if (nameof(PokemonEnum.PokemonType.Dragon) == TypeName)
            {
                return PokemonEnum.PokemonType.Dragon;
            }
            if (nameof(PokemonEnum.PokemonType.Steel) == TypeName)
            {
                return PokemonEnum.PokemonType.Steel;
            }
            if (nameof(PokemonEnum.PokemonType.Fairy) == TypeName)
            {
                return PokemonEnum.PokemonType.Fairy;
            }
            if (nameof(PokemonEnum.PokemonType.Dragon) == TypeName)
            {
                return PokemonEnum.PokemonType.Dragon;
            }

            return null;
        }
        public string HtmlTypePokemon
        {
            get
            {
                StringBuilder HtmlTypes = new();

                foreach(string typeName in this.Types)
                {
                    PokemonEnum.PokemonType _TypeId = GetPokemonTypeByName(typeName).GetValueOrDefault();
                    string TypeColor = string.Empty;
                    if (!PokemonEnum.TypeColors.TryGetValue(_TypeId, out TypeColor))
                    {
                        continue;
                    }

                    HtmlTypes.Append($"<p class='card-subtitle' style='color:{TypeColor};'>{typeName}</p>");
                }

                return HtmlTypes.ToString();
            }
        }

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
