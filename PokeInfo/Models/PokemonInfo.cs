using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PokeInfo.Models;

public class PokemonInfo
{
  [Range(0, 1025)]
  public int PokemonId { get; set; }

  public required string Name { get; set; }

  public required string FrontDefault { get; set; }

  public required List<string> Types { get; set; }

  public required List<string> Abilities { get; set; }

  public required List<string> Forms { get; set; }

  public required List<string> Moves { get; set; }
}
