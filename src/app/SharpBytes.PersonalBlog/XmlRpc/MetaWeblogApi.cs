namespace SharpBytes.PersonalBlog.XmlRpc
{
    using System;
    using CookComputing.XmlRpc;
    using MetaWebBlog_spike.XmlRpc.Models;
    using Models;

    public class MetaWeblogApi : XmlRpcService
    {
        [XmlRpcMethod("metaWeblog.newPost")]
        public string NewPost(string blogid, string username, string password, PostInfo post, bool publish)
        {
            throw new NotImplementedException();
        }

        [XmlRpcMethod("metaWeblog.editPost")]
        public bool EditPost(string postid, string username, string password, PostInfo post, bool publish)
        {
            throw new NotImplementedException();
        }

        [XmlRpcMethod("metaWeblog.getPost")]
        public PostInfo GetPost(string postid, string username, string password)
        {
            throw new NotImplementedException();
        }

        [XmlRpcMethod("metaWeblog.getCategories")]
        public CategoryInfo[] GetCategories(string blogid, string username, string password)
        {
            throw new NotImplementedException();
        }

        [XmlRpcMethod("metaWeblog.getRecentPosts")]
        public PostInfo[] GetRecentPosts(string blogid, string username, string password, int numberOfPosts)
        {
            throw new NotImplementedException();
        }

        [XmlRpcMethod("metaWeblog.newMediaObject")]
        public MediaObjectInfo NewMediaObject(string blogid, string username, string password, MediaObject mediaObject)
        {
            throw new NotImplementedException();
        }

        [XmlRpcMethod("blogger.deletePost")]
        public bool DeletePost(string key, string postid, string username, string password, bool publish)
        {
            throw new NotImplementedException();
        }

        [XmlRpcMethod("blogger.getUsersBlogs")]
        public BlogInfo[] GetUsersBlogs(string key, string username, string password)
        {
            return new BlogInfo[]
                       {
                           new BlogInfo()
                               {
                                   Blogid = "1",
                                   BlogName="Andrew Macdonald",
                                   Url="http://localhost:51313/"
                               }
                       };
        }

        [XmlRpcMethod("blogger.getUserInfo")]
        public UserInfo GetUserInfo(string key, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}