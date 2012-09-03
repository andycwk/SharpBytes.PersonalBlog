namespace SharpBytes.PersonalBlog.XmlRpc
{
    using System;
    using CookComputing.XmlRpc;
    using Technophobia.TechnicalBlogs.MetaWeblogApi;

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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    UserInfo IMetaWeblog.GetUserInfo (string key, string username, string password)
    {
throw new NotImplementedException();    }

  }
}

