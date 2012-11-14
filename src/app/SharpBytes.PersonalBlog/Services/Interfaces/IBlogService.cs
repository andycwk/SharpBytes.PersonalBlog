namespace SharpBytes.PersonalBlog.Services.Interfaces
{
    using System.Collections.Generic;
    using Nancy;
    using XmlRpc;

    public interface IBlogService
    {
        IList< string > GetCategories();
        void BuildCategories();
        IList< BlogPost > List();
    }
}