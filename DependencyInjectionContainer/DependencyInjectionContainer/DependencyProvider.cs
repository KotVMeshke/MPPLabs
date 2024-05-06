using DependencyInjectionContainer;
using DependencyInjectionCore.Models;

namespace DependencyInjectionCore;

public class DependencyProvider
{
    internal Dictionary<Type, Dependency> services = new();
    DependenciesConfiguration config;

    public DependencyProvider(DependenciesConfiguration config)
    {
        this.config = config;
        services = config.services;
    }

    public T Resolve<T>()
    {
        bool isEnumerable = EnumerableType.IsEnumerable(typeof(T));
        Type serviceType = isEnumerable ? EnumerableType.GetTypeOfEnumerable(typeof(T)) : typeof(T);

        IEnumerable<object> implementations;
        if (!services.ContainsKey(serviceType))
        {
            if (serviceType.IsGenericType)
                implementations = GetImplementationsForGeneric(serviceType);
            else
                throw new Exception( $"Unable to find such type implementation in dependencies: {serviceType.ToString()}");
        }
        else
            implementations = services[serviceType].GetImplementations(this);

        return isEnumerable ? (T)EnumerableType.ConvertToTypedEnumerable(implementations.ToList(), serviceType) : (T)implementations.Last();
    }

    private IEnumerable<object> GetImplementationsForGeneric(Type type)
    {
        return services[type.GetGenericTypeDefinition()].GetImplementations(this, type);
    }
}
