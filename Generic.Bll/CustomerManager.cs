using Generic.Dal;
using Generic.Dal.Abstract;
using Generic.Entities;

namespace Generic.Bll
{
    public class CustomerManager : GenericRepository<Customers, Context>
    {
        ICustomer _customerDal;
        public CustomerManager(ICustomer customerDal)
        {
            _customerDal = customerDal;
        }
    }
}
