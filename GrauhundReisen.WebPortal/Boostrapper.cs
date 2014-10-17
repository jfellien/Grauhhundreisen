using Nancy;
using Nancy.TinyIoc;

namespace GrauhundReisen.WebPortal
{
  public class Boostrapper : DefaultNancyBootstrapper
  {
    protected override void ApplicationStartup(TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
    {
      StaticConfiguration.DisableErrorTraces = false;

      base.ApplicationStartup(container, pipelines);
    }
  }
}
