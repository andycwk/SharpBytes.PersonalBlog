namespace SharpBytes.PersonalBlog.Modules
{
    using Nancy;

    public class HomeModule: NancyModule
    {
        public HomeModule()
        {
            Get[ "/" ] = parameters => "Hello Nancy World v2";
        }
    }
}