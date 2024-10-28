


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

  internal KeptVaultKeep GetKeptVaultKeepById(int keptVaultKeepId)
  {
    string sql = "SELECT * FROM vault_keeps WHERE id = @keptVaultKeepId;";
    
    KeptVaultKeep keptVaultKeep = _db.Query<KeptVaultKeep>(sql, new { keptVaultKeepId }).FirstOrDefault();
    return keptVaultKeep;
  }

  internal void DeleteKeptVaultKeepById(int keptVaultKeepId)
  {
    string sql = "DELETE FROM vault_keeps WHERE id = @keptVaultKeepId LIMIT 1;";
    
    int rowsAffected = _db.Execute(sql, new { keptVaultKeepId });
    if (rowsAffected == 0) throw new Exception("No kept vault keep deleted.");
    if (rowsAffected > 1) throw new Exception($"{rowsAffected} kept vault keeps were deleted, please check your sql syntax and do better.");
  }
}