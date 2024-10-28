
namespace keepr.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  internal Account GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Account Edit(Account update)
  {
    string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }

  internal Profile UpdateMyProfile(string userId, Profile profileUpdateData)
  {
    string sql = @"
        UPDATE
          accounts
        SET
          name = @Name,
          picture = @Picture,
          coverImg = @CoverImg
        WHERE
          id = @userId
        LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new
    {
      userId,
      profileUpdateData.Name,
      profileUpdateData.Picture,
      profileUpdateData.CoverImg
    });

    if (rowsAffected == 0) throw new Exception("No profiles were updated!");
    if (rowsAffected > 1) throw new Exception($"{rowsAffected} profiles were updated!");
    return profileUpdateData;
  }
}

