using Castle.DynamicProxy;
using System;

namespace Core.Interceptors
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class,AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {            
        }
    }
}
