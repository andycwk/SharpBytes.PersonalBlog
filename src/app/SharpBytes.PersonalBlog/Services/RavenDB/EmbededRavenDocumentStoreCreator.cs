namespace SharpBytes.PersonalBlog.Services.RavenDB
{
    using Interfaces;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Database.Server;

    class EmbededRavenDocumentStoreCreator    : IDocumentStoreCreator
    {
        public IDocumentStore CreateDocumentStore()
        {
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
            var documentStore = new EmbeddableDocumentStore()
                                              {
                                                  ConnectionStringName = "RavenDB",
                                                  UseEmbeddedHttpServer = true
                                              };

            documentStore.Initialize();
            
            return documentStore;
        }
    }
}