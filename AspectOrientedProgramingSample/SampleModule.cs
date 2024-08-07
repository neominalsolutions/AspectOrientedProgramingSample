using AspectOrientedProgramingSample.Aspects;
using AspectOrientedProgramingSample.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace AspectOrientedProgramingSample
{
  public class SampleModule:Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<BenchMarkAspect>();
      // İlgili aspect artık servise bağlandı.
      builder.RegisterType<SampleService>().As<ISampleService>().AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(BenchMarkAspect));

      
    }
  }
}
