

namespace keepr.Services;

public class ProfilesService
{
  public ProfilesService(ProfilesRepository repository)
  {
    _repository = repository;
  }
  private readonly ProfilesRepository _repository;
}
