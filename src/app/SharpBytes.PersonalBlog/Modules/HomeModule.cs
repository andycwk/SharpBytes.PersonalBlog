namespace SharpBytes.PersonalBlog.Modules
{
    using Nancy;
    using Raven.Client;
    using Services;
    using Services.Interfaces;

    public class HomeModule : NancyModule
    {
        public HomeModule( IBlogService blog, IDocumentSession docSession )
        {
            Get[ "/" ] =
                parameters => View["list", blog.List()];

            Get[ "/list" ] = parameters => View[ "list", blog.List() ];

            Get[ "/gen" ] = parameters =>
                                {
//                docSession.Store(new Category{Title= "cool"});
//                docSession.SaveChanges();
                                    blog.BuildCategories();

                                    return "Categories built";
                                };

            Get["/wlwmanifest.xml"] = parameters => Response.AsFile("wlwmanifest.xml", "text/xml");
        }
    }
}