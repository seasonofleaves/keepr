


namespace keepr.Services;

public class ProfilesService
{
  public ProfilesService(ProfilesRepository repository)
  {
    _repository = repository;
  }
  private readonly ProfilesRepository _repository;

  internal Profile GetProfileById(string profileId, string userId)
  {
    Profile profile = _repository.GetProfileById(profileId);
    if (profile == null) throw new Exception($"No profile with id: {profileId}");
    return profile;
  }
}
