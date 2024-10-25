


namespace keepr.Services;

public class KeepsService
{
  public KeepsService(KeepsRepository repository)
  {
    _repository = repository;
  }
  private readonly KeepsRepository _repository;

  internal List<Keep> GetAllKeeps()
  {
    List<Keep> keeps = _repository.GetAllKeeps();
    return keeps;
  }

  internal Keep GetKeepById(int keepId)
  {
    Keep keep = _repository.GetKeepById(keepId);
    if (keep == null)
    {
      throw new Exception($"Invalid keep id: {keepId}");
    }
    return keep;
  }

  internal Keep CreateKeep(KeepCreationDTO keepData, Account userInfo)
  {
    Keep keep = _repository.CreateKeep(keepData, userInfo.Id);
    return keep;
  }

}
