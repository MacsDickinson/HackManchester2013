using Nancy;
using Nancy.Authentication.Forms;
using Raven.Client;
using SharpDash.Raven;
using SharpDash.Session;

namespace SharpDash
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var store = RavenSessionProvider.DocumentStore;

            container.Register<IDocumentStore>(store);
            container.Register<IUserMapper, UserMapper>();
        }

        protected override void ConfigureRequestContainer(Nancy.TinyIoc.TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var store = container.Resolve<IDocumentStore>();
            var documentSesion = store.OpenSession();

            container.Register(documentSesion);
        }

        protected override void RequestStartup(Nancy.TinyIoc.TinyIoCContainer container,
            Nancy.Bootstrapper.IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
                {
                    var documentSession = container.Resolve<IDocumentSession>();

                    if (ctx.Response.StatusCode != HttpStatusCode.InternalServerError)
                    {
                        documentSession.SaveChanges();
                    }

                    documentSession.Dispose();
                }
            );

            var formsAuthConfiguration = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/Session/Login",
                UserMapper = container.Resolve<IUserMapper>(),
            };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }
    }
}