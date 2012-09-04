namespace SharpBytes.PersonalBlog
{
    using Nancy;
    using Raven.Client;
    using Services.RavenDB.Interfaces;

    public class NancyBootStrapper: DefaultNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(TinyIoC.TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var ravenSession = container.Resolve< IRavenSessionProvider >().GetSession();
            container.Register( ravenSession );
        }
    }
}