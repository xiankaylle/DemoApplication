namespace DemoApplication.WebAPI.Services
{
    public interface IBaseDataRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity transportEntity);
        void Update(TEntity transportEntity);
    }
}
