namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  public VaultsController(Auth0Provider auth0Provider, VaultsService vaultsService)
  {
    _auth0Provider = auth0Provider;
    _vaultsService = vaultsService;
  }

  private readonly Auth0Provider _auth0Provider;
  private readonly VaultsService _vaultsService;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] VaultCreationDTO vaultData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.CreateVault(vaultData, userInfo);
      return Ok(vault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}