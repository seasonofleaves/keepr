using System.ComponentModel.DataAnnotations;
using keepr.interfaces;

namespace keepr.Models;

public class Profile : IRepoItem<string>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
  [MaxLength(1000)]
  public string CoverImg { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
