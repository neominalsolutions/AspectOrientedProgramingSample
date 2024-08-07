using Castle.Core.Internal;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace AspectOrientedProgramingSample.Aspects
{
  [AttributeUsage(AttributeTargets.Method)]
  public class BenchMarkAttribute:Attribute
  {

  }
  public class BenchMarkAspect : IInterceptor
  {
    private readonly ILogger<BenchMarkAspect> _logger;

    public BenchMarkAspect(ILogger<BenchMarkAspect> logger)
    {
      _logger = logger;
    }
    public void Intercept(IInvocation invocation)
    {

      var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;

     var hasAttribute =  methodInfo.GetCustomAttributes(typeof(BenchMarkAttribute),true).Any();

      if(hasAttribute)
      {
        // Method Start
        var sp = Stopwatch.StartNew();
        _logger.LogInformation($"Method Before" + sp.ElapsedMilliseconds);

        invocation.Proceed(); // await next();

        sp.Stop();
        _logger.LogInformation($"Method After" + sp.ElapsedMilliseconds);

        // Method End
      }
      else
      {
        invocation.Proceed();
      }

    }
  }
}
