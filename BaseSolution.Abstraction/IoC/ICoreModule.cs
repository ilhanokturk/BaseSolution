using Microsoft.Extensions.DependencyInjection;

namespace BaseSolution.Abstraction.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
