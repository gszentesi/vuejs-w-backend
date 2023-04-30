using System.Reflection;

namespace RWA.Web
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection RegisterAllTypesAsInterface(this IServiceCollection sc, Assembly from, Type toRegister)
        {
            var tps = from
            .GetTypes()
            .Where(a => a.GetInterfaces().Select(i => i.Name).Contains(toRegister.Name) && !a.IsInterface && !a.IsAbstract)
            .ToList();

            tps.ForEach(t => sc.AddScoped(t.GetInterfaces().First(i => i.Name == toRegister.Name), t));

            return sc;
        }
    }
}
