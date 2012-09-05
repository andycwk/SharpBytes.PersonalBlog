namespace SharpBytes.PersonalBlog.XmlRpc
{
    using System;
    using CookComputing.XmlRpc;
    using Extensions;
    using Services;
    using Services.Interfaces;
    using Services.RavenDB;
    using Services.RavenDB.Interfaces;
    using Technophobia.TechnicalBlogs.MetaWeblogApi;
    using TinyIoC;
    using System.Linq;

    public class MetaWeblog: XmlRpcService, IMetaWeblog
  {
    string IMetaWeblog.AddPost (string blogid, string username, string password,
                                Post post, bool publish)
    {
        if (Authenticated(username, password) == false)
            throw new XmlRpcException( "User credentials are not valid" );

        var blogPost = new BlogPost(post.title)
                           {
                               Body = post.description,
                               DateAdded = DateTime.Now,
                               PulbishDate = post.dateCreated.ToUniversalTime()
                           };

        var docuemntStore = new EmbededRavenDocumentStoreCreator().CreateDocumentStore(RunEmbededServer.No);

        using( var documentSession = docuemntStore.OpenSession() )
        {
            documentSession.Store(blogPost);
            documentSession.SaveChanges();
        }

        return blogPost.Id;
    }

        private bool Authenticated( string username, string password )
        {
            return true;
        }

        bool IMetaWeblog.UpdatePost (string postid, string username, string password,
                                 Post post, bool publish)
    {
        throw new NotImplementedException();
    }

    Post IMetaWeblog.GetPost (string postid, string username, string password)
    {
        return new Post();
    }

    CategoryInfo[] IMetaWeblog.GetCategories (string blogid, string username, string password)
    {
        return new CategoryInfo[0];
    }

    Post[] IMetaWeblog.GetRecentPosts (string blogid, string username, string password,
                                       int numberOfPosts)
    {
        throw new NotImplementedException();
    }

    MediaObjectInfo IMetaWeblog.NewMediaObject (string blogid, string username, string password,
                                                MediaObject mediaObject)
    {
      throw new NotImplementedException ();
    }

    bool IMetaWeblog.DeletePost (string key, string postid, string username, string password, bool publish)
    {

        throw new NotImplementedException();
    }

    BlogInfo[] IMetaWeblog.GetUsersBlogs (string key, string username, string password)
    {
        return new BlogInfo[]
                   {
                       new BlogInfo
                           {
                               blogid = "1",
                               blogName = "Andrew Macdoanld",
                               url = "http://localhost:51313/"
                           }
                   };
    }

    UserInfo IMetaWeblog.GetUserInfo (string key, string username, string password)
    {
throw new NotImplementedException();    }

  }

    public class BlogPost
    {
        public BlogPost( string title )
        {
            Title = title;
            Slug = title.Slug();
        }

        public string Slug { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime PulbishDate { get; set; }
        public string Id { get; set; }
    }
}

