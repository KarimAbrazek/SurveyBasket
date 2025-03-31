using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Api.Models;
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_pollService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var poll = _pollService.Get(id);
        return poll is null ? NotFound() : Ok(poll);    

    }

    [HttpPost("")]
    public IActionResult Add(Poll request)
    {
      var newpoll=_pollService.Add(request);
        Uri uri= null;
        return newpoll is null ? NotFound() : CreatedAtAction(nameof(Get),new { id=newpoll.Id}, newpoll);

    }

    [HttpPut("{id}")]
    public IActionResult Update(int id,Poll poll)
    {
        var isUpdated = _pollService.Update(id, poll);
        return isUpdated ?  NoContent() : NotFound();

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _pollService.Delete(id);
        return isDeleted ? NoContent() : NotFound();

    }

}
