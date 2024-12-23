


namespace keepr.Services;

public class KeepsService
{
    public KeepsService(KeepsRepository repository, ProfilesService profilesService)
    {
        _repository = repository;
        _profilesService = profilesService;
    }
    private readonly KeepsRepository _repository;
  private readonly ProfilesService _profilesService;

  internal Keep CreateKeep(KeepCreationDTO keepData, Account userInfo)
  {
    Keep keep = _repository.CreateKeep(keepData, userInfo.Id);
    return keep;
  }

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

  internal Keep UpdateKeep(int keepId, string userId, KeepCreationDTO keepUpdateData)
  {
    Keep keep = GetKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("Not your keep to update!");
    }

    keep.Name = keepUpdateData.Name ?? keep.Name;
    keep.Description = keepUpdateData.Description ?? keep.Description;

    _repository.UpdateKeep(keepId, keepUpdateData);
    return keep;
  }

  internal string DeleteKeep(int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("Not your keep to delete!");
    }
    _repository.DeleteKeep(keepId);
    return $"{keep.Name} was deleted!";
  }

    internal List<Keep> GetKeepsByProfileId(string profileId, string userId)
    {
        Profile profile = _profilesService.GetProfileById(profileId, userId);
        List<Keep> keeps = _repository.GetKeepsByProfileId(profileId, userId);
        return keeps;
    }
}
