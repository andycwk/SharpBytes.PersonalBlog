namespace SharpBytes.PersonalBlog.Services.RavenDB
{
    using System.Web;
    using Interfaces;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Database.Server;
    using RavenDbIndexes;

    class EmbededRavenDocumentStoreCreator    : IDocumentStoreCreator
    {
        private static EmbeddableDocumentStore documentStore;

        public IDocumentStore CreateDocumentStore(RunEmbededServer runEmmededServer = RunEmbededServer.Yes)
        {
            return documentStore?? BuildDocumentStorel(runEmmededServer);
        }

        private static IDocumentStore BuildDocumentStorel( RunEmbededServer runEmmededServer )
        {
            documentStore = new EmbeddableDocumentStore()
                                {
                                    ConnectionStringName = "RavenDB",
                                    UseEmbeddedHttpServer = false  
                                };

            if( runEmmededServer == RunEmbededServer.Yes )
            {
               // NonAdminHttp.EnsureCanListenToWhenInNonAdminContext( 8080 );
                //documentStore.UseEmbeddedHttpServer = true;
            }

            documentStore.Initialize();
            Raven.Client.Indexes.IndexCreation.CreateIndexes(typeof(BlogPost_Index).Assembly,documentStore);
            return documentStore;
        }
    }
}