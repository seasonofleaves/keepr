


namespace keepr.Services;

public class VaultKeepsService
{
  public VaultKeepsService(VaultKeepsRepository repository, VaultsService vaultsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
  }
  private readonly VaultKeepsRepository _repository;
  private readonly VaultsService _vaultsService;

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _repository.CreateVaultKeep(vaultKeepData);
    return vaultKeep;
  }

  internal List<KeptVaultKeep> GetKeepsInVault(int vaultId, string userId)
  {
    Vault vault = _vaultsService.GetVaultById(vaultId, userId);
    List<KeptVaultKeep> keptVaultKeeps = _repository.GetKeepsInVault(vaultId, userId);
    return keptVaultKeeps;
  }
}
