
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
}

//  INSERT INTO
//           vault_keeps(vaultId, keepId, creatorId)
//           VALUES(@VaultId, @KeepId, @CreatorId);

//         SELECT vault_keeps.*, accounts.*, keeps.*
//         FROM
//             vault_keeps
//             JOIN keeps on keeps.id = vault_keeps.keepId
//             JOIN accounts ON accounts.id = keeps.creatorId