namespace WhoWorks.Core
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}