using SurveyBasket.Api.Models;
using System.Collections.Generic;

namespace SurveyBasket.Api.Services;

public interface IPollService
{
    Poll? Get(int Id);
    IEnumerable<Poll> GetAll();

    Poll? Add(Poll poll );

    bool Update(int id, Poll poll);
    bool Delete(int id);


}
