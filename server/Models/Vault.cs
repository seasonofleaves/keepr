using System.ComponentModel.DataAnnotations;
using keepr.interfaces;

namespace keepr.Models;

// INPUT MODEL
public class VaultCreationDTO
{
  [MinLength(5), MaxLength(20)]
  public string Name { get; set; }
  [MinLength(5), MaxLength(1000)]
  public string Description { get; set; }
  [MinLength(60), MaxLength(1000)]
  public string Img { get; set; }
  public bool IsPrivate { get; set; }
}

// RETURN OBJECT
public class Vault : IRepoItem<int>
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public bool IsPrivate { get; set; }

  // RELATIONSHIP PROPERTIES
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}
