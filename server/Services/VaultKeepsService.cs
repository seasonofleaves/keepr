



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
}
