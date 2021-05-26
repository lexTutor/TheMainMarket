using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class StoreSpecification : BaseSpecification<Store>
    {
        public StoreSpecification()
        {
        }

        public StoreSpecification(string Id): base(x=> x.Id == Id)
        {

        }
    }
}
