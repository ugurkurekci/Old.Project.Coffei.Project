using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBussinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<CustomerService>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<CompanyService>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<Order_DocumentationService>().As<IOrder_DocumentationService>().SingleInstance();
            builder.RegisterType<EfOrder_DocumentationDal>().As<IOrder_DocumentationDal>().SingleInstance();

            builder.RegisterType<PaymentService>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().SingleInstance();

            builder.RegisterType<TableService>().As<ITableService>().SingleInstance();
            builder.RegisterType<EfTableDal>().As<ITableDal>().SingleInstance();

            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<Order_PortionService>().As<IOrder_PortionService>().SingleInstance();
            builder.RegisterType<EfOrder_PortionDal>().As<IOrder_PortionDal>().SingleInstance();

            builder.RegisterType<Order_TypeService>().As<IOrder_TypeService>().SingleInstance();
            builder.RegisterType<EfOrder_TypeDal>().As<IOrder_TypeDal>().SingleInstance();

            builder.RegisterType<EmailService>().As<IEmailService>().SingleInstance();
            builder.RegisterType<EfEmailDal>().As<IEmailDal>().SingleInstance();

            builder.RegisterType<ContactService>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();
            builder.RegisterType<Email_ActivationService>().As<IEmail_ActivationService>().SingleInstance();
            builder.RegisterType<EfEmail_ActivationDal>().As<IEmail_ActivationDal>().SingleInstance();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();






            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
