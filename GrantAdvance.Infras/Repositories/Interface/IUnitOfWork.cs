namespace GrantAdvance.Infras.Repositories.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
