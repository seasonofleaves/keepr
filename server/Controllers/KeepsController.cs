namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  public KeepsController(Auth0Provider auth0Provider, KeepsService keepsService)
  {
    _auth0Provider = auth0Provider;
    _keepsService = keepsService;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly KeepsService _keepsService;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] KeepCreationDTO keepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.CreateKeep(keepData, userInfo);
      return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
