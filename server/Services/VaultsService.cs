


namespace keepr.Services;

public class VaultsService
{
  public VaultsService(VaultsRepository repository, ProfilesService profilesService)
  {
    _repository = repository;
    _profilesService = profilesService;
  }
  private readonly VaultsRepository _repository;
  private readonly ProfilesService _profilesService;

  internal Vault CreateVault(VaultCreationDTO vaultData, Account userInfo)
  {
    Vault vault = _repository.Createvault(vaultData, userInfo.Id);
    return vault;
  }

  private Vault GetVaultById(int vaultId)
  {
    Vault vault = _repository.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception($"Invalid vault id: {vaultId}");
    }
    return vault;
  }

  internal Vault GetVaultById(int vaultId, string userId)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userId && vault.IsPrivate == true)
    {
      throw new Exception("Not your vault!");
    }
    return vault;
  }

  internal Vault UpdateVault(int vaultId, string userId, VaultCreationDTO vaultUpdateData)
  {
    Vault vault = GetVaultById(vaultId, userId);
    if (vault.CreatorId != userId)
    {
      throw new Exception("Not your vault to update!");
    }

    vault.Name = vaultUpdateData.Name ?? vault.Name;
    vault.IsPrivate = vaultUpdateData.IsPrivate;

    _repository.UpdateVault(vaultId, vaultUpdateData);
    return vault;

  }

  internal string DeleteVault(int vaultId, string userId)
  {
    Vault vault = GetVaultById(vaultId, userId);
    if (vault.CreatorId != userId)
    {
      throw new Exception("Not your vault to delete!");
    }
    _repository.DeleteVault(vaultId);
    return $"{vault.Name} was deleted!";
  }

  internal List<Vault> GetVaultsByProfileId(string profileId, string userId)
  {
    Profile profile = _profilesService.GetProfileById(profileId, userId);
    List<Vault> vaults = _repository.GetVaultsByProfileId(profileId, userId);
    return vaults.FindAll(vault => !vault.IsPrivate || vault.CreatorId == userId);
  }

  internal List<Vault> GetMyVaults(string userId)
  {
    List<Vault> vaults = _repository.GetMyVaults(userId);
    return vaults;
  }
}
