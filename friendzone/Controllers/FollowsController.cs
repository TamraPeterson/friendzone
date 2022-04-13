using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using friendzone.Models;
using friendzone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace friendzone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class FollowsController : ControllerBase
  {
    private readonly FollowsService _fs;

    public FollowsController(FollowsService fs)
    {
      _fs = fs;
    }

    [HttpPost]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow data)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        data.FollowerId = user.Id;
        Follow created = _fs.Create(data);
        return Ok(data);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}