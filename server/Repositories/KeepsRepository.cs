using System.Data.Common;

namespace keepr.Repositories;

public class KeepsRepository
{
  public KeepsRepository(DbConnection db)
  {
    _db = db;
  }
  private readonly DbConnection _db;
}

