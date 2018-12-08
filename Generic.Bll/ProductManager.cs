using Generic.Dal;
using Generic.Dal.Abstract;
using Generic.Entities;
using System.Collections.Generic;

namespace Generic.Bll
{
    public class ProductManager : GenericRepository<Products, Context>, IProduct
    {
        //EFPRODUCT - dal katmanındaki spesifik kodu iş katmanında çalıştırmak için.
        //Tüm kontroller tüm işler burada yapılır..        
        IProduct _productDal;
        public ProductManager(IProduct productDal)
        {
            _productDal = productDal;
        }

        public List<Products> GetProductName(string startsWith)
        {
            return _productDal.GetProductName(startsWith);
        }
    }
}
