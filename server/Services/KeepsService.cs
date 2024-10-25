
namespace keepr.Services;

public class KeepsService
{
  public KeepsService(KeepsRepository repository)
  {
    _repository = repository;
  }
  private readonly KeepsRepository _repository;

  internal Keep CreateKeep(KeepCreationDTO keepData, Account userInfo)
  {
    Keep keep = _repository.CreateKeep(keepData, userInfo.Id);
    return keep;
  }
}
