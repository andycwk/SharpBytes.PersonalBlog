namespace SharpBytes.PersonalBlog.RavenDbIndexes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Raven.Abstractions.Indexing;
    using Raven.Client.Indexes;
    using XmlRpc;

    public class BlogPost_Index: AbstractIndexCreationTask<BlogPost>
    {
        public BlogPost_Index()
        {
            Map = posts => from post in posts
                           select new
                                      {
                                          Title = post.Title,
                                          Body = post.Body,
                                          DateAdded = post.DateAdded,
                                          PublishDate = post.PublishDate,
                                          Slug = post.PublishDate
                                      };

            Sort(x=>x.Title, SortOptions.None  );
        }
    }
}