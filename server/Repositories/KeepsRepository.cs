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
}

