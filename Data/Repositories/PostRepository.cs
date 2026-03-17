using Core.Abstracts.IRepositories;
using Core.Concrete.Entities;
using Data.Contexts;
using System.Data.Entity;
using Utils.Wrappers;

namespace Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
