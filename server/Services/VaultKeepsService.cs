



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

  private KeptVaultKeep GetKeptVaultKeepById(int keptVaultKeepId)
  {
    KeptVaultKeep keptVaultKeep = _repository.GetKeptVaultKeepById(keptVaultKeepId);
    if (keptVaultKeep == null) throw new Exception($"Invalid kept vault keep id: {keptVaultKeepId}");
    return keptVaultKeep;
  }

  internal void DeleteKeptVaultKeep(int keptVaultKeepId, string userId)
  {
    KeptVaultKeep keptVaultKeep = GetKeptVaultKeepById(keptVaultKeepId);
    if (keptVaultKeep.CreatorId != userId) throw new Exception("Not your kept vault keep to delete!");
    _repository.DeleteKeptVaultKeepById(keptVaultKeepId);
  }
}
