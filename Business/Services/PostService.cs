using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concrete.DTOs;
using Data;
using Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext context = ApplicationDbContext.Create();
        private readonly IUnitOfWork unitOfWork;
        public PostService()
        {
            unitOfWork = new UnitOfWork(context);
        }

        public PostDetailDto GetPostDetail(int id)
        {
            var post = unitOfWork.PostRepository.ReadById(id);
            if (post != null)
            {
                return new PostDetailDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    AuthorId = post.AuthorId,
                    AuthorName = $"{post.Author.FirstName} {post.Author.LastName}",
                    CoverImageUrl = post.CoverImageUrl,
                    PublishDate = post.PublishDate,
                    Tags = post.Tags.Select(x => x.Name).ToArray()
                };
            }
            return null;
        }

        public IEnumerable<PostListItemDto> GetPostList()
        {
            var posts = unitOfWork.PostRepository.ReadMany(null, "Tags", "Author");
            return from post in posts
                   select new PostListItemDto
                   {
                       Id = post.Id,
                       Title = post.Title,
                       ShortContent = post.Content,
                       AuthorId = post.AuthorId,
                       AuthorName = $"{post.Author.FirstName} {post.Author.LastName}",
                       CoverImageUrl = post.CoverImageUrl,
                       PublishDate = post.PublishDate,
                       Tags = post.Tags.Select(x => x.Name).ToArray()
                   };
        }
    }
}
