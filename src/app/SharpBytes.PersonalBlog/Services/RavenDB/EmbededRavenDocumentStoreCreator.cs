namespace SharpBytes.PersonalBlog.Services.RavenDB
{
    using System.Web;
    using Interfaces;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Database.Server;

    class EmbededRavenDocumentStoreCreator    : IDocumentStoreCreator
    {
        private static EmbeddableDocumentStore documentStore;

        public IDocumentStore CreateDocumentStore(RunEmbededServer runEmmededServer = RunEmbededServer.Yes)
        {
            return documentStore?? BuildDocumentStore(runEmmededServer);
        }

        private static IDocumentStore BuildDocumentStore( RunEmbededServer runEmmededServer )
        {
            documentStore = new EmbeddableDocumentStore()
                                {
                                    ConnectionStringName = "RavenDB"
                                };

            if( runEmmededServer == RunEmbededServer.Yes )
            {
                NonAdminHttp.EnsureCanListenToWhenInNonAdminContext( 8080 );
                documentStore.UseEmbeddedHttpServer = true;
            }

            documentStore.Initialize();
            
            return documentStore;
        }
    }
}