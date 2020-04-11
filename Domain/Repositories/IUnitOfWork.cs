using System.Threading.Tasks;

namespace EDzController.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}