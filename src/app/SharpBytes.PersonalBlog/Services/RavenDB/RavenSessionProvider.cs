namespace SharpBytes.PersonalBlog.Services.RavenDB
{
    using Interfaces;
    using Raven.Client;

    public class RavenSessionProvider: IRavenSessionProvider
    {
        public RavenSessionProvider(IDocumentStoreCreator documentStoreStoreCreator)
        {
            DocumentStoreStoreCreator = documentStoreStoreCreator;
        }

        private IDocumentStore documentStore;

        public IDocumentSession GetSession()
        {
            return DocumentStore.OpenSession();
        }

        private IDocumentStore DocumentStore { get { return documentStore ?? ( documentStore = DocumentStoreStoreCreator.CreateDocumentStore() ); } }

        private IDocumentStoreCreator DocumentStoreStoreCreator { get; set; }
    }
}