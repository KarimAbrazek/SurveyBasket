using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Services;

public class PollService : IPollService
{
    private static readonly List<Poll> _polls = new List<Poll>()
    {
        new Poll(){ Id=1,Title="dd",Description="fff"},
        new Poll(){ Id=2,Title="gg",Description="ooo"},
        new Poll(){ Id=3,Title="tt",Description="qqq"},
    };
    public Poll? Get(int id)
    {
        return _polls.SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Poll> GetAll()
    {
      return _polls;
    }

    public Poll Add(Poll poll )
    {
        poll.Id = _polls.Count;
        _polls.Add( poll );
        return poll;
    }

    public bool Update(int id,Poll poll) 
    {
        var exitingPoll = Get(id);
        if (exitingPoll == null || poll == null) return false;

        exitingPoll.Title = poll.Title;
        exitingPoll.Description = poll.Description;
        return true;
    }


    public bool Delete(int id)
    {
        var exitingPoll = Get(id);
        if (exitingPoll == null ) return false;

        _polls.Remove(exitingPoll);
        return true;
    }
}
