namespace Blog.Core
{
    using Repository;
    using System;
    using System.Threading.Tasks;
    using Blog.Domain;

    public interface IUnitOfWork: IDisposable
    {
        IRepository<Article> ArticleRepository { get; }

        IRepository<Category> CategoryRepository { get; }

        IRepository<Tag> TagRepository { get; }

        IRepository<BlogFile> BlogFileRepository { get; }

        IRepository<ArticleTagMap> ArticleTagMapRepository { get; }
        
        void Commit();

        Task CommitAsync();
    }
}
