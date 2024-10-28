namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfilesController : ControllerBase
{
    public ProfilesController(Auth0Provider auth0Provider, ProfilesService profilesServie, KeepsService keepsService, VaultsService vaultsService)
    {
        _auth0Provider = auth0Provider;
        _profilesService = profilesServie;
        _keepsService = keepsService;
        _vaultsService = vaultsService;
    }
    private readonly Auth0Provider _auth0Provider;
  private readonly ProfilesService _profilesService;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;

  [HttpGet("{profileId}")]
  public async Task<ActionResult<Profile>> GetProfileById(string profileId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Profile profile = _profilesService.GetProfileById(profileId, userInfo?.Id);
      return Ok(profile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]
  public async Task<ActionResult<List<Keep>>> GetKeepsByProfileId(string profileId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Keep> keeps = _keepsService.GetKeepsByProfileId(profileId, userInfo?.Id);
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string profileId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetVaultsByProfileId(profileId, userInfo?.Id);
      return Ok(vaults);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
