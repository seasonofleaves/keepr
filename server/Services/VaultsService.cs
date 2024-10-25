

namespace keepr.Services;

public class VaultsService
{
  public VaultsService(VaultsRepository repository)
  {
    _repository = repository;
  }
  private readonly VaultsRepository _repository;

  internal Vault CreateVault(VaultCreationDTO vaultData, Account userInfo)
  {
    Vault vault = _repository.Createvault(vaultData, userInfo.Id);
    return vault;
  }

  public Vault GetVaultById(int vaultId)
  {
    Vault vault = _repository.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception($"Invalid vault id: {vaultId}");
    }
    return vault;
  }

}
