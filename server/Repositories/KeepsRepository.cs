using System.Data.Common;

namespace keepr.Repositories;

public class KeepsRepository
{
  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Keep CreateKeep(KeepCreationDTO keepData, string creatorId)
  {
    string sql = @"
        INSERT INTO
        keeps(name, description, img, creatorId)
        VALUES(@Name, @Description, @Img, @CreatorId);

        SELECT
          keeps.*,
          accounts.*
        FROM
          keeps
          JOIN accounts ON accounts.id = keeps.creatorId
        WHERE
          keeps.id = LAST_INSERT_ID();";

    Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new
    {
      keepData.Name,
      keepData.Description,
      keepData.Img,
      creatorId
    }).FirstOrDefault();
    return keep;
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
        SELECT
          keeps.*,
          COUNT(keeps.id) AS kept,
          accounts.*
        FROM keeps
          JOIN accounts on accounts.id = keeps.creatorId
        GROUP BY
          keeps.id;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }).ToList();
    return keeps;
  }

  internal Keep GetKeepById(int keepId)
  {
    string sql = @"
        UPDATE keeps SET views = views + 1 WHERE keeps.id = @keepId;

        SELECT
          keeps.*,
          COUNT(vault_keeps.id) AS kept,
          accounts.*
        FROM
          keeps
          JOIN accounts ON accounts.id = keeps.creatorId
          LEFT OUTER JOIN vault_keeps ON vault_keeps.keepId = keeps.id
        WHERE
          keeps.id = @keepId
        GROUP BY
          keeps.id;";

    Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { keepId }).FirstOrDefault();
    return keep;
  }

  internal void UpdateKeep(int keepId, KeepCreationDTO keepUpdateData)
  {
    string sql = @"
        UPDATE
          keeps
        SET
          name = @Name,
          description = @Description
        WHERE
          id = @keepId
        LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new
    {
      keepId,
      keepUpdateData.Name,
      keepUpdateData.Description
    });

    if (rowsAffected == 0) throw new Exception("No vaults were updated!");

    if (rowsAffected > 1) throw new Exception($"{rowsAffected} vaults were updated!");

  }

  internal void DeleteKeep(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { keepId });

    if (rowsAffected == 0) throw new Exception("No keeps were deleted!");

    if (rowsAffected > 1) throw new Exception($"{rowsAffected} keeps were delted!");
  }

  internal List<Keep> GetKeepsByProfileId(string profileId, string userId)
  {
    string sql = @"
        SELECT
          accounts.*,
          keeps.*
        FROM
          keeps
        JOIN
          accounts on accounts.id = keeps.creatorId
        WHERE
          accounts.id = @profileId;";

    List<Keep> keeps = _db.Query<Profile, Keep, Keep>(sql, (profile, keep) =>
    {
      keep.CreatorId = profile.Id;
      keep.Creator = profile;
      return keep;
    }, new
    {
      userId,
      profileId
    }).ToList();
    return keeps;
  }
}

