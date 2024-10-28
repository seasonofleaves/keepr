

namespace keepr.Repositories;

public class VaultKeepsRepository
{
  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
        INSERT INTO
          vault_keeps(vaultId, keepId, creatorId)
          VALUES(@VaultId, @KeepId, @CreatorId);

        SELECT * FROM vault_keeps WHERE vault_keeps.id = LAST_INSERT_ID();";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
    return vaultKeep;
  }

  internal List<KeptVaultKeep> GetKeepsInVault(int vaultId, string userId)
  {
    string sql = @"
        SELECT
          vault_keeps.*,
          keeps.*,
          accounts.*
        FROM
          vault_keeps
        JOIN
          accounts on accounts.id = vault_keeps.creatorId
        JOIN
          keeps on keeps.id = vault_keeps.keepId 
        WHERE
          vault_keeps.vaultId = @vaultId;";

    List<KeptVaultKeep> keptVaultKeeps = _db.Query<VaultKeep, KeptVaultKeep, Profile, KeptVaultKeep>(sql, (vaultKeep, keep, profile) =>
    {
      keep.VaultKeepId = vaultKeep.Id;
      keep.AccountId = vaultKeep.CreatorId;
      keep.Creator = profile;
      return keep;
    }, new
    {
      userId,
      vaultId
    }).ToList();
    return keptVaultKeeps;
  }
}