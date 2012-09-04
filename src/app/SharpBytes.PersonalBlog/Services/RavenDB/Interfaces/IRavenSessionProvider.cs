namespace SharpBytes.PersonalBlog.Services.RavenDB.Interfaces
{
    using Raven.Client;

    public interface IRavenSessionProvider
    {
        IDocumentSession GetSession();
    }
}