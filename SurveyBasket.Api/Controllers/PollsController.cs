using System.Collections;

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
        var polls = _pollService.GetAll().Adapt<IEnumerable<PollResponse>>();
        return Ok(polls);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute]int id)
    {
        var  poll = _pollService.Get(id).Adapt<PollResponse>();
        return poll is null ? NotFound() : Ok(poll);    

    }

    [HttpPost("")]
    public IActionResult Add([FromBody] CreatePollRequest request)
    {
      PollResponse newpoll=_pollService.Add(request.Adapt<Poll>()).Adapt<PollResponse>();
        return newpoll is null ? NotFound() : CreatedAtAction(nameof(Get),new { id=newpoll.Id}, newpoll);

    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] CreatePollRequest poll)
    {
        var isUpdated = _pollService.Update(id, poll.Adapt<Poll>());
        return isUpdated ?  NoContent() : NotFound();

    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _pollService.Delete(id);
        return isDeleted ? NoContent() : NotFound();

    }

}
