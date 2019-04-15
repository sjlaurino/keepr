using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class KeepController : ControllerBase
  {
    private readonly KeepRepository _kr;
    public KeepController(KeepRepository kr)
    {
      _kr = kr;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetAll();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep found = _kr.FindById(id);
      if (found == null)
      {
        return BadRequest("No keep at that ID");
      }
      return Ok(found);
    }

    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keepData)
    {
      keepData.UserId = HttpContext.User.Identity.Name;
      Keep newKeep = _kr.CreateKeep(keepData);
      if (newKeep == null)
      {
        return BadRequest("Cannot Create");
      }
      return Ok(newKeep);
    }

    // [HttpPut]

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.Delete(id);
      if (!successful)
      {
        return BadRequest("Cannot Delete");
      }
      return Ok("successfully deleted");
    }


  }
}
