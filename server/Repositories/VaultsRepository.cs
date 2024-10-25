using System.Data.Common;

namespace keepr.Repositories;

public class VaultsRepository
{
  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Vault Createvault(VaultCreationDTO vaultData, string creatorId)
  {
    string sql = @"
        INSERT INTO
          vaults(name, description, img, creatorId)
          VALUES(@Name, @Description, @Img, @CreatorId);

        SELECT
          vaults.*,
          accounts.*
        FROM
          vaults
          JOIN accounts ON accounts.id = vaults.creatorId
        WHERE
          vaults.id = LAST_INSERT_ID();";

    Vault vault = _db.Query(sql, (Vault vault, Profile profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new
    {
      vaultData.Name,
      vaultData.Description,
      vaultData.Img,
      creatorId
    }).FirstOrDefault();
    return vault;
  }

  internal Vault GetVaultById(int vaultId)
  {
    string sql = @"
        SELECT
          vaults.*,
          accounts.*
        FROM
          vaults
          JOIN accounts on accounts.id = vaults.creatorId
        WHERE vaults.id = @vaultId;";

    Vault vaults = _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { vaultId }).FirstOrDefault();
    return vaults;
  }

  internal void UpdateVault(int vaultId, VaultCreationDTO vaultUpdateData)
  {
    string sql = @"
        UPDATE
          vaults
        SET
          name = @Name,
          isPrivate = @IsPrivate
        WHERE
          id = @vaultId
          LIMIT 1;";

    _db.Execute(sql, new
    {
      vaultId,
      vaultUpdateData.Name,
      vaultUpdateData.IsPrivate
    });
  }
}

