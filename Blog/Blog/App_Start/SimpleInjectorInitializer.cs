[assembly: WebActivator.PostApplicationStartMethod(typeof(Blog.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Blog.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using Contract;
    using Negocio;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<ICategoria, ConsultasCategorias>();
            container.Register<IPost, ConsultasPosts>();
            container.Register<ITag, ConsultasTags>();
            container.Register<IEstado, ConsultasEstados>();
            container.Register<IMotivo, ConsultasMotivos>();
            container.Register<IDenuncia, ConsultasDenuncias>();
            container.Register<IComentario, ConsultasComentarios>();
            container.Register<IRolesUsuario, ConsultasRolesUsuario>();
            container.Register<IUsuario, ConsultasUsuarios>();
        }
    }
}