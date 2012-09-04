namespace SharpBytes.PersonalBlog.Services.RavenDB.Interfaces
{
    using Raven.Client;

    public interface IDocumentStoreCreator
    {
        IDocumentStore CreateDocumentStore();
    }
}