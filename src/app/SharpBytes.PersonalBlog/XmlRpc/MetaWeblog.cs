namespace SharpBytes.PersonalBlog.XmlRpc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CookComputing.XmlRpc;
    using Extensions;
    using Raven.Client;
    using Raven.Client.Linq;
    using RavenDbIndexes;
    using Services.RavenDB;
    using Services.RavenDB.Interfaces;
    using Technophobia.TechnicalBlogs.MetaWeblogApi;

    public class MetaWeblog : XmlRpcService, IMetaWeblog
    {
        string IMetaWeblog.AddPost( string blogid, string username, string password,
                                    Post post, bool publish )
        {
            ThrowExceptionIfAuthenticationFailsFor( username, password );

            var blogPost = new BlogPost( post.title )
                               {
                                   DateAdded = DateTime.Now,
                               }.UpdateDetailsFrom(post);

            using( var documentSession = DocuemntStore.OpenSession() )
            {
                documentSession.Store( blogPost );
                documentSession.SaveChanges();
            }

            return blogPost.Id;
        }

        private void ThrowExceptionIfAuthenticationFailsFor( string username, string password )
        {
            if( Authenticated( username, password ) == false )
                throw new XmlRpcException( "User credentials are not valid" );
        }

        private static IDocumentStore DocuemntStore
        {
            get
            {
                var docuemntStore = new EmbededRavenDocumentStoreCreator().CreateDocumentStore( RunEmbededServer.No );
                return docuemntStore;
            }
        }

        private bool Authenticated( string username, string password )
        {
            return true;
        }

        bool IMetaWeblog.UpdatePost( string postid, string username, string password,
                                     Post post, bool publish )
        {
            ThrowExceptionIfAuthenticationFailsFor(username, password);

            using (var documentSetssion = DocuemntStore.OpenSession())
            {
                var blogPost = documentSetssion.Load< BlogPost >( postid );

                blogPost.UpdateDetailsFrom( post );
                documentSetssion.SaveChanges();
            }

            return true;
        }

        Post IMetaWeblog.GetPost( string postid, string username, string password )
        {
            ThrowExceptionIfAuthenticationFailsFor( username, password );

            using( var documentSession = DocuemntStore.OpenSession() )
            {
                var post = documentSession.Load< BlogPost >( postid );
                return post.AsStructure();
            }
        }

        CategoryInfo[] IMetaWeblog.GetCategories( string blogid, string username, string password )
        {
            using( var session = DocuemntStore.OpenSession() )
            {
                var query =
                    from categoryInfo in session.Query< BlogPost_Categories.CategoryInfo, BlogPost_Categories >()
                    select categoryInfo;

                var d = query.ToList();

                return (from categoryInfo in query select new CategoryInfo{title = categoryInfo.CategoryName}).ToArray();
            }
        }

        Post[] IMetaWeblog.GetRecentPosts( string blogid, string username, string password,
                                           int numberOfPosts )
        {
            ThrowExceptionIfAuthenticationFailsFor( username, password );

            using( var documentSession = DocuemntStore.OpenSession() )
            {
                var posts = (from post in documentSession.Query< BlogPost >()
                             orderby post.DateAdded
                             select post).Take(numberOfPosts).ToList();


                return (from post in posts select post.AsStructure()).ToArray();
            }
        }

        MediaObjectInfo IMetaWeblog.NewMediaObject( string blogid, string username, string password,
                                                    MediaObject mediaObject )
        {
            throw new NotImplementedException();
        }

        bool IMetaWeblog.DeletePost( string key, string postid, string username, string password, bool publish )
        {
            ThrowExceptionIfAuthenticationFailsFor(username, password);

            using (var documentSession = DocuemntStore.OpenSession())
            {
                documentSession.Delete(documentSession.Load<BlogPost>(postid));

                documentSession.SaveChanges();
            }

            return true;
        }

        BlogInfo[] IMetaWeblog.GetUsersBlogs( string key, string username, string password )
        {
            return new[]
                       {
                           new BlogInfo
                               {
                                   blogid = "1",
                                   blogName = "Andrew Macdoanld",
                                   url = "http://localhost:51313/"
                               }
                       };
        }

        UserInfo IMetaWeblog.GetUserInfo( string key, string username, string password )
        {
            throw new NotImplementedException();
        }
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
        public DateTime PublishDate { get; set; }
        public string Id { get; set; }
        public IList< string > Categories { get; set; }
    }
}