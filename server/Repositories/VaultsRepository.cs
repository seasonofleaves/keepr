using System.Data.Common;

namespace keepr.Repositories;

public class VaultsRepository
{
  public VaultsRepository(DbConnection db)
  {
    _db = db;
  }
  private readonly DbConnection _db;
}

