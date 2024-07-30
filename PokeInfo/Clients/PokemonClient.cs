using System.Text.Json;
using System.Text.Json.Nodes;
using PokeInfo.Models;

namespace PokeInfo.Clients;

public class PokemonClient(HttpClient httpClient)
{
  public async Task<PokemonInfo> GetPokemonByIdAsync(int id)
  {
    var result = await httpClient.GetAsync($"{id}");
    var jsonResponse = result.Content.ReadAsStringAsync().Result;

    var pokemonObject = JsonObject.Parse(jsonResponse);

    PokemonInfo pokemon = new()
    {
      PokemonId = id,
      Name = pokemonObject["name"].ToString(),
      FrontDefault = pokemonObject["sprites"]["front_default"].ToString(),
      Types = pokemonObject["types"].AsArray().Select(pkmn => pkmn["type"]["name"].ToString()).ToList(),
      Abilities = pokemonObject["abilities"].AsArray().Select(ability => ability["ability"]["name"].ToString()).ToList(),
      Forms = pokemonObject["forms"].AsArray().Select(form => form["name"].ToString()).ToList(),
      Moves = pokemonObject["moves"].AsArray().Select(move => move["move"]["name"].ToString()).Take(10).ToList()
    };

    return pokemon;
  }
}
