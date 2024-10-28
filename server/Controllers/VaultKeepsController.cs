namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VaultKeepsController : ControllerBase
{
  public VaultKeepsController(Auth0Provider auth0Provider, VaultKeepsService vaultKeepsService)
  {
    _auth0Provider = auth0Provider;
    _vaultKeepsService = vaultKeepsService;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultKeepsService _vaultKeepsService;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      vaultKeepData.CreatorId = userInfo.Id;
      VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepData, userInfo.Id);
      return Ok(vaultKeep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{keptVaultKeepId}")]
  public async Task<ActionResult<string>> DeleteKeptVaultKeep(int keptVaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      _vaultKeepsService.DeleteKeptVaultKeep(keptVaultKeepId, userInfo.Id);
      return Ok("Not longer saving that vault keep.");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
