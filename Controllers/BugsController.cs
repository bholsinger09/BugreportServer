using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bugserver.Models;
using bugserver.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bugserver.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BugsController : ControllerBase
  {
    private readonly BugRepository _repo;

    public BugsController(BugRepository repo)
    {
      _repo = repo;
    }
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Bug>> Get()
    {
      try
      {
        return Ok(_repo.GETALL());

      }
      catch (Exception e)
      {
        return BadRequest(e);

      }

    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Bug> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));

      }
      catch (Exception e)
      {

        return BadRequest(e);
      }

    }

    // POST api/values
    [HttpPost]
    public ActionResult<Bug> Post([FromBody] Bug value)
    {
      try
      {
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }



    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Bug> Put(int id, [FromBody] Bug value)
    {
      try
      {
        value.Id = id;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
  }
}
