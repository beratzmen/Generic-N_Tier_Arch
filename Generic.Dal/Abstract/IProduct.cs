using Generic.Entities;
using System.Collections.Generic;

namespace Generic.Dal.Abstract
{
    public interface IProduct : IRepository<Products>
    {
        //herhangi  spesifik bir kod ..
        //EFPRODUCT - concrete içerisine kalıtım verir ve somutlama yapılır.
        List<Products> GetProductName(string startsWith);
    }
}
