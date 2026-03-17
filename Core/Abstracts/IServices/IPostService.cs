using Core.Concrete.DTOs;
using System.Collections.Generic;

namespace Core.Abstracts.IServices
{
    public interface IPostService
    {
        IEnumerable<PostListItemDto> GetPostList();
        PostDetailDto GetPostDetail(int id);
    }
}
