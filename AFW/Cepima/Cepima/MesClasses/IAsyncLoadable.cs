using System.Threading.Tasks;

namespace Cepima.MesClasses
{
    public interface IAsyncLoadable
    {
        Task ChargerAsync();
    }
}