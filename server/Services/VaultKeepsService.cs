




namespace keepr.Services;

public class VaultKeepsService
{
  public VaultKeepsService(VaultKeepsRepository repository)
  {
    _repository = repository;
  }
  private readonly VaultKeepsRepository _repository;

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _repository.CreateVaultKeep(vaultKeepData);
    return vaultKeep;
  }

    // internal List<VaultKeep> GetKeepsInPublicVault(int vaultId, string userId)
    // {
    //     VaultKeep vaultKeep = _repository.GetKeepsInPublicVault(vaultId, userId);
    //     return vaultKeep;
    // }
}
