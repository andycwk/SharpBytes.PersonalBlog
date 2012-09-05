namespace SharpBytes.PersonalBlog.Extensions
{
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
            blogPost.PublishDate = post.dateCreated;

            return blogPost;
        }
    }
}