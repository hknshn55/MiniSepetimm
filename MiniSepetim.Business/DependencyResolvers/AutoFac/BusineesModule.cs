using Autofac;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Business.Conrete;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.DependencyResolvers.AutoFac
{
    public class BusineesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
            builder.RegisterType<PictureManager>().As<IPictureService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<SellerManager>().As<ISellerService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CustomerDal>().As<ICustomerDal>();
            builder.RegisterType<OrderDal>().As<IOrderDal>();
            builder.RegisterType<OrderDetailDal>().As<IOrderDetailDal>();
            builder.RegisterType<PictureDal>().As<IPictureDal>();
            builder.RegisterType<ProductDal>().As<IProductDal>();
            builder.RegisterType<SellerDal>().As<ISellerDal>();
           

           


            base.Load(builder);
        }

    }
}
