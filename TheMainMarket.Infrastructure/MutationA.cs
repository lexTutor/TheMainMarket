using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.UsersDtos;

namespace TheMainMarket.Infrastructure
{
    public class MutationA
    {
        public UserPayload CheckMutation(DeleteInput input)
        {
            return new UserPayload { Email = "dummyemail.com"};
        }
    }
}
