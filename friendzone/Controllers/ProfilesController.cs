using System;
using System.Collections.Generic;
using friendzone.Models;
using friendzone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace friendzone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class ProfilesController : ControllerBase
  {

    private readonly FollowsService _fs;

    public ProfilesController(FollowsService fs)
    {
      _fs = fs;
    }

    [HttpGet("{id}/follows")]
    public ActionResult<List<Follow>> GetProfileFollows(string id)
    {
      try
      {
        List<Follow> profileFollows = _fs.GetProfileFollows(id);
        return Ok(profileFollows);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);

      }
    }
  }
}