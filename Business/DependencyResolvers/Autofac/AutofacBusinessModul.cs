using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Core.Security.Jwt;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Business
            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<AuthorManager>().As<IAuthorService>().SingleInstance();
            builder.RegisterType<GenreManager>().As<IGenreService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            #endregion

            #region DataAccess
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().SingleInstance();
            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();
            builder.RegisterType<EfGenreDal>().As<IGenreDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            #endregion

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
