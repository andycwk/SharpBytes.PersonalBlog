namespace SharpBytes.PersonalBlog.Services
{
    using System.Collections.Generic;
    using CookComputing.XmlRpc;
    using Interfaces;
    using Nancy;
    using Raven.Client;
    using TinyIoC;

    public class BlogService: IBlogService
    {
        private readonly TinyIoCContainer container;
        private  IDocumentSession documentSession;

        public BlogService( IDocumentSession documentSession)
        {
            this.documentSession = documentSession;
        }

        public IList<string> GetCategories()
        {
            return new List< string >
                       {
                           "asp.net",
                           "c#",
                           "ravenDb"
                       };
        }

        public void BuildCategories()
        {
            documentSession.Store(new Category{Title = "test"});
            documentSession.Store(new Category{Title = ".net"});

            documentSession.SaveChanges();
        }
    }

    public class Category    
    {
        public string Title { get; set; }
    }
}