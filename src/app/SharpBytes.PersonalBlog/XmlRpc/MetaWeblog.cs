namespace SharpBytes.PersonalBlog.XmlRpc
{
    using System;
    using CookComputing.XmlRpc;
    using Services;
    using Technophobia.TechnicalBlogs.MetaWeblogApi;
    using TinyIoC;
    using System.Linq;

    public class MetaWeblog: XmlRpcService, IMetaWeblog
  {
    string IMetaWeblog.AddPost (string blogid, string username, string password,
                                Post post, bool publish)
    {
        throw new NotImplementedException();
    }

    bool IMetaWeblog.UpdatePost (string postid, string username, string password,
                                 Post post, bool publish)
    {
        throw new NotImplementedException();
    }

    Post IMetaWeblog.GetPost (string postid, string username, string password)
    {
        throw new NotImplementedException();
    }

    CategoryInfo[] IMetaWeblog.GetCategories (string blogid, string username, string password)
    {
        var blog  = TinyIoCContainer.Current.Resolve<BlogService>();

        return ( from category in blog.GetCategories() select new CategoryInfo {title = category} ).ToArray();
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
}

