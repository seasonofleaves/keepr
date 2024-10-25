using System.ComponentModel.DataAnnotations;
using keepr.interfaces;

namespace keepr.Models;

// INPUT MODEL
public class VaultCreationDTO
{
  public string Name { get; set; }
  [MaxLength(1000)]
  public string Description { get; set; }
  [MaxLength(1000)]
  public string ImgUrl { get; set; }
}

// RETURN OBJECT
public class Vault : IRepoItem<int>
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string ImgUrl { get; set; }
  public bool IsPrivate { get; set; }

  // RELATIONSHIP PROPERTIES
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}
