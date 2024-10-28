namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfilesController : ControllerBase
{
  public ProfilesController(Auth0Provider auth0Provider, ProfilesService profilesServie)
  {
    _auth0Provider = auth0Provider;
    _profilesServie = profilesServie;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly ProfilesService _profilesServie;

  [HttpGet("{profileId}")]
  public async Task<ActionResult<Profile>> GetProfileById(string profileId){
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Profile profile = _profilesServie.GetProfileById(profileId, userInfo?.Id);
      return Ok(profile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
