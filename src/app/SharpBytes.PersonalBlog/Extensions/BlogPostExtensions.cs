namespace SharpBytes.PersonalBlog.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Technophobia.TechnicalBlogs.MetaWeblogApi;
    using XmlRpc;

    public static class BlogPostExtensions
    {
        public static Post AsStructure( this BlogPost blogPost )
        {
            return new Post
                       {
                           title = blogPost.Title,
                           dateCreated = blogPost.PublishDate,
                           postid = blogPost.Id,
                           description = blogPost.Body
                       };
        }

        public static BlogPost UpdateDetailsFrom(this BlogPost blogPost, Post post)
        {
            blogPost.Title = post.title;
            blogPost.Body = post.description;
            blogPost.PublishDate = post.dateCreated.ToUniversalTime();
            blogPost.Categories = post.categories.ToList();

            return blogPost;
        }
    }
}