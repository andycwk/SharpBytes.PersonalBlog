namespace SharpBytes.PersonalBlog
{
    using Nancy;
    using Nancy.Hosting.Aspnet;
    using Raven.Client;
    using Services;
    using Services.Interfaces;
    using Services.RavenDB.Interfaces;

    public class NancyBootStrapper: DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoC.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
        }

        protected override Nancy.Bootstrapper.NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return base.InternalConfiguration;
                
            }
        }
        protected override void ConfigureRequestContainer(TinyIoC.TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Register< BlogService>();
            var ravenSession = container.Resolve< IRavenSessionProvider >().GetSession();
            container.Register( ravenSession );

            container.Register< IBlogService, BlogService >();
        }
    }
}