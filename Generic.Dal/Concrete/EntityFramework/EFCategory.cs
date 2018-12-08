using Generic.Dal.Abstract;
using Generic.Entities;

namespace Generic.Dal.Concrete
{
    public class EFCategory : GenericRepository<Categories, Context>, ICategory
    {
    }
}
