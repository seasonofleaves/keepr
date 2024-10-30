using keepr.interfaces;

namespace keepr.Models;

public class VaultKeep : IRepoItem<int>
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  // RELATIONSHIP PROPERTIES
  public string CreatorId { get; set; }
  public int KeepId { get; set; }
  public int VaultId { get; set; }
}

public class KeptVaultKeep : Keep
{
  public int VaultKeepId { get; set; }
  public int VaultId { get; set; }
  public string AccountId { get; set; }
}