using Core.Abstracts.IRepositories;
using Core.Abstracts.IServices;
using System;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        void Commit();
    }
}
