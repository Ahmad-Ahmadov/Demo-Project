using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.DependencyResolvers;
using Core.Interceptors;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 15)
        {
            _duration = duration;
            _cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(',', arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get<object>(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
