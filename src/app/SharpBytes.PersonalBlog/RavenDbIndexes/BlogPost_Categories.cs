namespace SharpBytes.PersonalBlog.RavenDbIndexes
{
    using System.Linq;
    using Raven.Client.Indexes;
    using SharpBytes.PersonalBlog.XmlRpc;

    public class BlogPost_Categories: AbstractIndexCreationTask<BlogPost, BlogPost_Categories.CategoryInfo>
    {
        public class CategoryInfo
        {
            public string CategoryName { get; set; }
            public int Count { get; set; }
        }

        public BlogPost_Categories()
        {
            Map = blogPosts => from blogPost in blogPosts
                               from category in blogPost.Categories
                               select new {CategoryName = category, Count = 1};

            Reduce = results => from result in results
                                group result by result.CategoryName
                                into categoryGroup
                                select new {CategoryName = categoryGroup.Key, Count = categoryGroup.Sum( x => x.Count )};
        }
    }
}