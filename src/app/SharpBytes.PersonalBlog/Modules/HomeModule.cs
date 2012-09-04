namespace SharpBytes.PersonalBlog.Modules
{
    using Nancy;
    using Raven.Client;
    using Services;
    using Services.Interfaces;

    public class HomeModule: NancyModule
    {

        public HomeModule(IBlogService blog, IDocumentSession docSession)
        {
            Get[ "/" ] = parameters => string.Format( "Hello Nancy World v2 {0}", string.Join(", ", blog.GetCategories()) );

            Get["/gen"] = parameters => { 
//                docSession.Store(new Category{Title= "cool"});
//                docSession.SaveChanges();
                blog.BuildCategories();
                                            
                return "Categories built";
            };
        }
    }
}