namespace Blog.Core
{
    using System.Threading.Tasks;
    using Repository;
    using Domain;

    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext _context;

        public IRepository<Article> ArticleRepository { get; private set; }

        public IRepository<Category> CategoryRepository { get; private set; }

        public IRepository<Tag> TagRepository { get; private set; }

        public IRepository<BlogFile> BlogFileRepository { get; private set; }

        public IRepository<ArticleTagMap> ArticleTagMapRepository { get; private set; }

        public UnitOfWork(BlogContext context)
        {
            _context = context;
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            ArticleRepository = new GenericRepository<Article, BlogContext>(_context);

            CategoryRepository = new GenericRepository<Category, BlogContext>(_context);

            TagRepository = new GenericRepository<Tag, BlogContext>(_context);

            BlogFileRepository = new GenericRepository<BlogFile, BlogContext>(_context);

            ArticleTagMapRepository = new GenericRepository<ArticleTagMap, BlogContext>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            //TODO:
        }
    }
}
