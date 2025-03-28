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
          vaults(name, description, img, isPrivate, creatorId)
          VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);

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
      vaultData.IsPrivate,
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

  internal void DeleteVault(int vaultId)
  {
    string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { vaultId });

    if (rowsAffected == 0)
    {
      throw new Exception("No vaults were deleted!");
    }
    if (rowsAffected > 1)
    {
      throw new Exception($"{rowsAffected} vaults were delted!");
    }
  }

  internal List<Vault> GetVaultsByProfileId(string profileId, string userId)
  {
    string sql = @"
        SELECT
          accounts.*,
          vaults.*
        FROM
          vaults
        JOIN
          accounts on accounts.id = vaults.creatorId
        WHERE
          accounts.id = @profileId;";

    List<Vault> vaults = _db.Query<Profile, Vault, Vault>(sql, (profile, vault) =>
    {
      vault.CreatorId = profile.Id;
      vault.Creator = profile;
      return vault;
    }, new
    {
      userId,
      profileId
    }).ToList();
    return vaults;
  }

  internal List<Vault> GetMyVaults(string userId)
  {
    string sql = @"
        SELECT
          vaults.*,
          accounts.*
        FROM
          vaults
        JOIN accounts on accounts.id = vaults.creatorId
        WHERE
          accounts.id = @userId
        GROUP BY
          vaults.id;";

    List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    {
      vault.CreatorId = profile.Id;
      vault.Creator = profile;
      return vault;
    }, new { userId }).ToList();
    return vaults;
  }
}

