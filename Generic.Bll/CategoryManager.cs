using Generic.Dal;
using Generic.Dal.Abstract;
using Generic.Entities;

namespace Generic.Bll
{
    public class CategoryManager : GenericRepository<Categories, Context>
    {
        ICategory _categoryDal;
        public CategoryManager(ICategory categoryDal)
        {
            _categoryDal = categoryDal;
        }
    }
}
