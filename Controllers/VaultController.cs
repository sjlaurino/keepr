using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vaultr.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class VaultController : ControllerBase
  {
    private readonly VaultRepository _vr;
    public VaultController(VaultRepository vr)
    {
      _vr = vr;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      IEnumerable<Vault> results = _vr.GetAll();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault found = _vr.FindById(id);
      if (found == null)
      {
        return BadRequest("No vault at that ID");
      }
      return Ok(found);
    }

    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault vaultData)
    {
      vaultData.UserId = HttpContext.User.Identity.Name;
      Vault newVault = _vr.CreateVault(vaultData);
      if (newVault == null)
      {
        return BadRequest("Cannot Create");
      }
      return Ok(newVault);
    }

    // [HttpPut]

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vr.Delete(id);
      if (!successful)
      {
        return BadRequest("Cannot Delete");
      }
      return Ok("successfully deleted");
    }

    //create vaultkeeps
    [HttpPost("{vaultId}")]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeepData)
    {
      VaultKeep newVaultKeep = _vr.CreateVaultKeep(vaultKeepData);
      if (newVaultKeep == null)
      {
        return BadRequest("Can't add Keep");
      }
      return Ok(newVaultKeep);
    }
  }
}
