namespace SurveyBasket.Api.Mapping;

public class MappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<Poll, PollResponse>().Map(dest=>dest.Notes,Src=>Src.Description);
    }
}
