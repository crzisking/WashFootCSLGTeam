using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace XJDD.Service;

public static class ServiceRegister
{
    
    /// <summary>
    /// 批量注入服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="interfaceAssembly"></param>
    /// <param name="implementAssembly"></param>
    /// <returns></returns>
    public static IServiceCollection AddBatchScoped(this IServiceCollection services, Assembly interfaceAssembly,
        Assembly implementAssembly)
    {
        var interfaces = interfaceAssembly.GetTypes().Where(t => t.IsInterface);
        var implements = implementAssembly.GetTypes();
        foreach (var item in interfaces)
        {
            var type = implements.FirstOrDefault(x => item.IsAssignableFrom(x));
            if (type != null)
            {
                services.AddScoped(item, type);
            }
        }

        return services;
    }


    /// <summary>
    /// 批量注入服务，单例
    /// </summary>
    /// <param name="services"></param>
    /// <param name="interfaceAssembly"></param>
    /// <param name="implementAssembly"></param>
    /// <returns></returns>
    public static IServiceCollection AddBatchSingleton(this IServiceCollection services, Assembly interfaceAssembly,
        Assembly implementAssembly)
    {
        var interfaces = interfaceAssembly.GetTypes().Where(t => t.IsInterface);
        var implements = implementAssembly.GetTypes();
        foreach (var item in interfaces)
        {
            var type = implements.FirstOrDefault(x => item.IsAssignableFrom(x));
            if (type != null)
            {
                services.AddSingleton(item, type);
            }
        }

        return services;
    }


    /// <summary>
    /// 批量注入服务，瞬时
    /// </summary>
    /// <param name="services"></param>
    /// <param name="interfaceAssembly"></param>
    /// <param name="implementAssembly"></param>
    /// <returns></returns>
    public static IServiceCollection AddBatchtransient(this IServiceCollection services, Assembly interfaceAssembly,
        Assembly implementAssembly)
    {
        var interfaces = interfaceAssembly.GetTypes().Where(t => t.IsInterface);
        var implements = implementAssembly.GetTypes();
        foreach (var item in interfaces)
        {
            var type = implements.FirstOrDefault(x => item.IsAssignableFrom(x));
            if (type != null)
            {
                services.AddTransient(item, type);
            }
        }
        return services;
    }
}