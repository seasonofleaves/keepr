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
}
