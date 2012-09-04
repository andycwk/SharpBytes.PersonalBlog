namespace SharpBytes.PersonalBlog.Services.Interfaces
{
    using System.Collections.Generic;
    using Nancy;

    public interface IBlogService
    {
        IList<string> GetCategories();
        void BuildCategories();
    }
}