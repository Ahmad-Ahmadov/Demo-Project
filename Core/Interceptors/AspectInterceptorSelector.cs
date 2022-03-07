using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;
using Core.Aspects.Autofac.Exception;

namespace Core.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            classAttributes.AddRange(methodAttributes);
            return classAttributes.ToArray();
        }
    }
}
