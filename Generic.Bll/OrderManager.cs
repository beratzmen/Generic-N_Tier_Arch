using Generic.Dal;
using Generic.Dal.Abstract;
using Generic.Entities;

namespace Generic.Bll
{
    public class OrderManager : GenericRepository<Orders, Context>, IOrder
    {
        IOrder _orderDal;
        public OrderManager(IOrder orderDal)
        {
            _orderDal = orderDal;
        }
    }
}
