namespace SharpBytes.PersonalBlog.Services.RavenDB.Interfaces
{
    using Raven.Client;

    public interface IDocumentStoreCreator
    {
        IDocumentStore CreateDocumentStore(RunEmbededServer runEmbededServer = RunEmbededServer.Yes);
    }

    public enum RunEmbededServer
    {
        Yes,
        No
    }
}