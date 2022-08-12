namespace DemoApplication.WebAPI.Services
{
    public interface IBaseDataRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
