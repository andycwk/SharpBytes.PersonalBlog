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
                           dateCreated = blogPost.DateAdded,
                           postid = blogPost.Id,
                           description = blogPost.Body
                       };
        }
    }
}