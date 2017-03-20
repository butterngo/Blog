namespace Blog.Core.Repository
{
    public sealed class GenericRepository<TEntity, TContext> : Repository<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class
        where TContext : BlogContext
    {
        public GenericRepository(TContext context) : base(context) { }

    }
}
