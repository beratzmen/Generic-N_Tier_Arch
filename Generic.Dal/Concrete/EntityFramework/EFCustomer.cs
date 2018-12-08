using Generic.Dal.Abstract;
using Generic.Entities;

namespace Generic.Dal.Concrete.EntityFramework
{
    public class EFCustomer : GenericRepository<Customers, Context>, ICustomer
    {
    }
}
