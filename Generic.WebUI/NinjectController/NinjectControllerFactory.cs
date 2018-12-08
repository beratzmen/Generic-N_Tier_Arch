using Generic.Bll;
using Generic.Dal.Concrete;
using Generic.Dal.Concrete.EntityFramework;
using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Generic.WebUI.NinjectController
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBllBindings();
        }
        private void AddBllBindings()
        {
            //IProduct'ı,ProductManager ile bağlama - EFProduct'tan türetilen nesne const.olarak Manager'a gönderilir. 
            //Controllerdan instance almak yerine proje başlarken bu nesneler oluşturuluyor.
            //Kısaca ProductManager'a istek yapıldığında EFProduct classı ile productDal'ı argüman olarak bll'e const.taşır.
            //Mesela NHibernate git dersek veritabanı işlemleri otomatik değişmiş olur.
            _ninjectKernel.Bind<ProductManager>().To<ProductManager>().
                WithConstructorArgument("productDal", new EFProduct());

            _ninjectKernel.Bind<CategoryManager>().To<CategoryManager>().
               WithConstructorArgument("categoryDal", new EFCategory());

            _ninjectKernel.Bind<CustomerManager>().To<CustomerManager>().
               WithConstructorArgument("customerDal", new EFCustomer());

            _ninjectKernel.Bind<OrderManager>().To<OrderManager>().
               WithConstructorArgument("orderDal", new EFOrder());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}