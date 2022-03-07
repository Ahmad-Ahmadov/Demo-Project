using Castle.DynamicProxy;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.Aspects.Autofac.Authorization
{
    public class AuthorizationAspect : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceHelper.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role)) return;
            }

            throw new Exception("Access denied!");
        }
    }
}