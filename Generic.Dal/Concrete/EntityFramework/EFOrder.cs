using Generic.Dal.Abstract;
using Generic.Entities;

namespace Generic.Dal.Concrete.EntityFramework
{
    public class EFOrder : GenericRepository<Orders, Context>, IOrder
    {
    }
}
