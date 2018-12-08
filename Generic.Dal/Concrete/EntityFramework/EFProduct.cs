using Generic.Dal.Abstract;
using Generic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Generic.Dal.Concrete.EntityFramework
{
    public class EFProduct : GenericRepository<Products, Context>, IProduct
    {
        //IPRODUCT -abstract soyutlaması burada implement edilir ve içerisi doldurulur.
        //Veritabanı işlemleri burada tamamlanır.
        Context ctx = new Context();
        public List<Products> GetProductName(string startsWith)
        {
            Expression<Func<Products, bool>> predicate = x => x.ProductName.StartsWith(startsWith);
            List<Products> productList = ctx.Products.Where(predicate).ToList();
            return productList;
        }
    }
}
