using System.ComponentModel.DataAnnotations;
using keepr.interfaces;

namespace keepr.Models;

public class Profile : IRepoItem<string>
{
  public string Id { get; set; }
  [MinLength(5), MaxLength(30)]
  public string Name { get; set; }
  [MinLength(60), MaxLength(1000)]
  public string Picture { get; set; }
  [MinLength(60), MaxLength(1000)]
  public string CoverImg { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
